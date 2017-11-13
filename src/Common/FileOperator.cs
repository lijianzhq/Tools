using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;

namespace Common
{
    public class FileOperator
    {
        public event EventHandler<ExceptionEventArgs> Exception;

        /// <summary>
        /// 给定一个路径，获取路径的所有文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<String>> GetAllFilesAsync(String path, String fileType)
        {
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
                    else
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

        /// <summary>
        /// 根据编码返回文件头的长度
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Int32 GetFileHeadByteLength(Encoding encoding)
        {
            if (encoding == Encoding.UTF8) return 3;
            if (encoding == Encoding.Unicode || encoding == Encoding.BigEndianUnicode) return 2;
            return 0;
        }

        public static void FileRename(String filePath, String newName)
        {
            Computer myComputer = new Computer();
            myComputer.FileSystem.RenameFile(filePath, newName);
        }

        public static void RemoveFileToRecycleBin(String filePath)
        {
            FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
        }
    }
}
