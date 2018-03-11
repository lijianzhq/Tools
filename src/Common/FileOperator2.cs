using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Common
{
    /// <summary>
    /// 2018-03-10新版本
    /// 文件处理器
    /// </summary>
    public class FileOperator2
    {
        #region "字段"

        private String m_dirpath;
        private String m_searchPattern;

        /// <summary>
        /// 最大并发线程数
        /// </summary>
        private UInt16 m_maxTaskCount = 10;

        /// <summary>
        /// 标志是否已经开始处理了，0未开始，1已开始
        /// </summary>
        private Int32 m_isStarting = 0;

        #endregion

        #region "属性/事件

        public event EventHandler<ExceptionEventArgs> Exception;

        /// <summary>
        /// 文件处理链，参数列表：
        /// 每一个文件路径
        /// 文件的编码格式
        /// </summary>
        public event Action<String, Encoding> FileOperatorChain;

        #endregion

        #region "public method"

        public FileOperator2(String dirPath, String searchPattern)
        {
            m_dirpath = dirPath;
            m_searchPattern = searchPattern;
        }

        /// <summary>
        /// 开始调用处理管道链去逐一处理文件
        /// </summary>
        public async void StartAsync()
        {
            try
            {
                if (FileOperatorChain == null) return;
                //只允许一个线程同时进行处理
                if (Interlocked.CompareExchange(ref m_isStarting, 1, 0) == 1) return;
                var files = await GetAllFilesAsync(m_dirpath, m_searchPattern);
                if (files == null || files.Count() == 0) return;
                List<Task> taskList = new List<Task>();
                AutoResetEvent resetEvent = new AutoResetEvent(false);
                foreach (String file in files)
                {
                    if (taskList.Count >= m_maxTaskCount)
                    {
                        do
                        {
                            for (var i = taskList.Count - 1; i >= 0; i--)
                            {
                                if (taskList[i].IsCompleted) taskList.RemoveAt(i);
                            }
                            //这里还会存在一个情况，就是当一个线程退出之后Set了信号量，最终waitone()第一次调用还是会收到信号量的
                        }
                        while (taskList.Count >= m_maxTaskCount && resetEvent.WaitOne());
                    }
                    Task tempTsk = DoOperatorFile(file);
                    taskList.Add(tempTsk);
                    tempTsk.ContinueWith(t => resetEvent.Set());
                }
                Interlocked.CompareExchange(ref m_isStarting, 0, 1);
            }
            catch (Exception ex)
            {
                FireExceptionEvent(null, ex);
            }
        }

        /// <summary>  
        /// 取得文件编码方式
        /// </summary>  
        /// <param name="filePath"></param>  
        /// <param name="fileEncoding"></param>  
        /// <returns></returns>  
        public virtual Encoding GetFileEncoding(String filePath)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                Encoding encoding;
                //获取文件的编码格式
                if (GetFileEncoding(fs, out encoding))
                    return encoding;
                else
                    throw new System.Exception(String.Format("get file [{0}] encode type fail!", filePath));
            }
        }

        /// <summary>  
        /// 取得文件编码方式
        /// </summary>  
        /// <param name="fs"></param>  
        /// <param name="fileEncoding"></param>  
        /// <returns></returns>  
        public virtual Boolean GetFileEncoding(FileStream fs, out Encoding fileEncoding)
        {
            Boolean find = false;
            fileEncoding = Encoding.Default;
            var buffer = new Byte[4];
            var read = fs.Read(buffer, 0, buffer.Length);
            if (read <= 0)
            {
                find = true;
                fileEncoding = Encoding.Default;
            }
            else if (buffer[0] < 239)
            //if (buffer.Length <= 0 || buffer[0] < 239)
            {
                find = true;
                fileEncoding = Encoding.Default;
            }
            else if (buffer[0] == 239 && buffer[1] == 187 && buffer[2] == 191)
            {
                find = true;
                fileEncoding = Encoding.UTF8;
            }
            else if (buffer[0] == 254 && buffer[1] == byte.MaxValue)
            {
                find = true;
                fileEncoding = Encoding.BigEndianUnicode;
            }
            else if (buffer[0] == byte.MaxValue && buffer[1] == 254)
            {
                find = true;
                fileEncoding = Encoding.Unicode;
            }
            fs.Seek(0, SeekOrigin.Begin);
            return find;
        }

        #endregion

        #region "protected method"

        /// <summary>
        /// 执行操作文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected virtual async Task DoOperatorFile(String path)
        {
            await Task.Run(() =>
            {
                FileOperatorChain?.Invoke(path, GetFileEncoding(path));
            });
        }

        /// <summary>
        /// 给定一个路径，获取路径的所有文件
        /// </summary>
        /// <param name="path">文件路径，或者是目录路径</param>
        /// <param name="fileType">文件类型</param>
        /// <returns>返回所有文件完整路径，如果指定的路径不存在，则返回null</returns>
        protected virtual async Task<IEnumerable<String>> GetAllFilesAsync(String path, String fileType)
        {
            if (String.IsNullOrEmpty(path)) return null;
            return await Task.Run<IEnumerable<String>>(() =>
            {
                try
                {
                    if (Directory.Exists(path))
                    {
                        List<String> fileList = new List<String>();
                        if (!String.IsNullOrEmpty(fileType))
                        {
                            String[] fileTypes = fileType.Split(',');
                            foreach (String item in fileTypes)
                            {
                                String[] files = Directory.GetFiles(path, item, System.IO.SearchOption.AllDirectories);
                                fileList.AddRange(files);
                            }
                        }
                        else
                        {
                            String[] files = Directory.GetFiles(path, "*", System.IO.SearchOption.AllDirectories);
                            fileList.AddRange(files);
                        }
                        return fileList;
                    }
                    else if (File.Exists(path))
                    {
                        return new String[] { path };
                    }
                }
                catch (Exception ex)
                {
                    FireExceptionEvent(null, ex);
                }
                return null;
            });
        }

        /// <summary>
        /// 触发异常的事件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ex"></param>
        protected virtual void FireExceptionEvent(String filePath, Exception ex)
        {
            try
            {
                if (Exception != null)
                {
                    Exception.Invoke(null, new ExceptionEventArgs()
                    {
                        FilePath = filePath,
                        Ex = ex,
                        Msg = ex.Message
                    });
                }
            }
            catch (Exception)
            {
                //本demo忽略此异常
                //throw;
            }
        }

        #endregion
    }
}
