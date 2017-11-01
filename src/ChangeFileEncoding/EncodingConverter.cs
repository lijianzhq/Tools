using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

using DreamCube.Foundation.Log;

namespace ChangeFileEncoding
{
    class EncodingConverter
    {
        /// <summary>
        /// 依赖文件操作对象
        /// </summary>
        private FileOperator FileOperator;

        /// <summary>
        /// 完成编码一个文件上报的事件
        /// </summary>
        public event EventHandler<ConvertedEventArgs> ConvertedOne;
        public event EventHandler<ExceptionEventArgs> Exception;
        /// <summary>
        /// 完成编码所有文件上报的事件
        /// </summary>
        public event EventHandler<EventArgs> Converted;

        public String Path { get; protected set; }
        public Encoding TargetEncoding { get; protected set; }
        public String FileType { get; protected set; }

        /// <summary>
        /// 转换某个目录下面所有文件的格式
        /// </summary>
        /// <param name="path">等待转换的路径</param>
        /// <param name="targetEncoding">目标格式</param>
        public EncodingConverter(String path, String fileType, Encoding targetEncoding)
        {
            this.Path = path;
            this.FileType = fileType;
            this.TargetEncoding = targetEncoding;
            this.FileOperator = new FileOperator();
            this.FileOperator.Exception += FileOperator_Exception;
            this.FileOperator.Converted += FileOperator_Converted;
        }

        /// <summary>
        /// 异步方法
        /// </summary>
        /// <returns></returns>
        public async Task ConvertAsync()
        {
            try
            {
                //异步获取所有的IO文件
                IEnumerable<String> files = await this.FileOperator.GetAllFilesAsync(this.Path, this.FileType);
                Int32 maxParallelThreads = 10;//最大并行处理任务数
                if (files != null)
                {
                    List<Task> taskList = new List<Task>();
                    AutoResetEvent resetEvent = new AutoResetEvent(false);
                    //运行的时候会有异常，新创建的文件总是提示文件正在被其他线程使用中，文件名应该不会重复的
                    //以下是测试代码
                    IEnumerable<String> sameNameFiles = files.Where((s) =>
                    {
                        IEnumerable<String> tempSameNameFiles = files.Where((s2) =>
                        {
                            if (String.Equals(s, s2, StringComparison.CurrentCultureIgnoreCase))
                                return true;
                            return false;
                        });
                        return tempSameNameFiles.Count() > 1;
                    });
                    if (sameNameFiles.Count() > 0)
                    {
                        foreach (String item in sameNameFiles)
                        {
                            FireExceptionEvent(item, new System.Exception()
                            {
                                Source = "同名文件。。。。。。。。。。。"
                            });
                        }
                    }
                    //测试代码 end
                    foreach (String item in files)
                    {
                        //同时处理任务数不能太多，否则机器内存都会暴涨
                        if (taskList.Count >= maxParallelThreads)
                        {
                            do
                            {
                                for (var i = taskList.Count - 1; i >= 0; i--)
                                {
                                    if (taskList[i].IsCompleted) taskList.RemoveAt(i);
                                }
                                //如果一个任务都没完成，则先等待有一个任务完成的信号量，才再继续循环
                            } while (taskList.Count >= maxParallelThreads && resetEvent.WaitOne());
                        }
                        //这里并行处理，不要每调用一次就await
                        Log.Root.LogDebugFormat("call ChangeEncoding file:{0}", item);
                        Task tempTsk = this.FileOperator.ChangeEncoding(item, this.TargetEncoding);
                        taskList.Add(tempTsk);
                        tempTsk.ContinueWith((t) =>
                        {
                            resetEvent.Set();
                        });
                    }
                    //等待所有任务处理完成
                    foreach (Task t in taskList)
                    {
                        t.Wait();
                    }
                }
            }
            catch (Exception ex)
            {
                FireExceptionEvent(String.Empty, ex);
            }
            FireConvertedEvent();
        }

        /// <summary>
        /// 触发转换结果对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="result"></param>
        protected virtual void FireConvertedOneEvent(String filePath, Boolean result)
        {
            try
            {
                if (ConvertedOne != null)
                {
                    ConvertedOne.Invoke(null, new ConvertedEventArgs()
                    {
                        FilePath = filePath,
                        Result = result
                    });
                }
            }
            catch (Exception ex)
            {
                FireExceptionEvent(filePath, ex);
            }
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
        /// 触发异常的事件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ex"></param>
        protected virtual void FireConvertedEvent()
        {
            try
            {
                if (Converted != null)
                {
                    Converted.Invoke(null, null);
                }
            }
            catch (Exception)
            {
                //本demo忽略此异常
                //throw;
            }
        }

        /// <summary>
        /// 转换成功的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOperator_Converted(object sender, ConvertedEventArgs e)
        {
            this.FireConvertedOneEvent(e.FilePath, e.Result);
        }

        /// <summary>
        /// 文件操作对象发出的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOperator_Exception(object sender, ExceptionEventArgs e)
        {
            this.FireExceptionEvent(e.FilePath, e.Ex);
        }
    }
}
