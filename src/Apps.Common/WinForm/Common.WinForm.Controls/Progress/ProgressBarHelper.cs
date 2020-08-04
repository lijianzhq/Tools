using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace DreamCube.Apps.Common.WinForm.Controls.Progress
{
    /// <summary>
    /// 进度条的帮助类
    /// </summary>
    public static class ProgressBarHelper
    {
        #region "字段"

        /// <summary>
        /// 执行缓存区
        /// </summary>
        private static List<ProgressBarWrapper> runningCachePool = null;

        /// <summary>
        /// 添加缓冲区
        /// </summary>
        private static List<ProgressBarWrapper> addCachePool = null;

        /// <summary>
        /// 读写锁
        /// </summary>
#if NET2
        private static ReaderWriterLock locker = new ReaderWriterLock();
#elif NET4
        private static ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
#endif

        /// <summary>
        /// 标志是否在运行中
        /// 0表示停止中，1表示运行中
        /// </summary>
        private static Int32 isRunning = 0;

        /// <summary>
        /// 定时器
        /// </summary>
        private static System.Threading.Timer timer = null;

        #endregion

        #region "公共方法"

        /// <summary>
        /// 模拟进度条开始走动；（此方法不可以由ProgressBar UI线程之外的线程调用）
        /// 不要对于同一个progressbar多次此方法，只有首次调用的才有效果，后续调用的会被忽略
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="timeLength">模拟时长（按s计算）</param>
        public static void StartBar(ProgressBar bar, Int32 timeLength = 10)
        {
            if (addCachePool == null)
                addCachePool = new List<ProgressBarWrapper>();
            if (runningCachePool == null)
                runningCachePool = new List<ProgressBarWrapper>();
            //把bar添加到缓冲区中
            AddToCachePool(bar, timeLength);
            StartUpdateProgress();
        }

        /// <summary>
        /// 重置滚动条(必须由UI线程调用的)
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="timeLength">重置时长（按s计算）</param>
        public static void ResetBar(ProgressBar bar, Int32 timeLength = 10)
        {
            bar.Maximum = timeLength * 100;
            bar.Minimum = 1;
            bar.Value = 1;
        }

        /// <summary>
        /// 创建进度条窗口，并返回给客户端去呈现以及控制
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="a"></param>
        /// <param name="timeout"></param>
        /// <param name="formStyle"></param>
        /// <returns></returns>
        public static ProgressForm ShowSelfProgressDialog(IWin32Window owner, Action a, ProgressFormStyle formStyle = null)
        {
            if (formStyle != null) formStyle.AutoRunProgressBar = false;
            ProgressForm form = new ProgressForm(formStyle, a);
            return form;
        }

        /// <summary>
        /// 启动进度条模式对话框(自动启动滚动条的窗口)
        /// 显示此对话框，只是一种模拟的，没有真正实现互操作的取消动作
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="a"></param>
        /// <param name="timeout">表示超时时间（按秒算，默认为60秒，60秒如果传入的委托还没执行完毕，则强行关闭等待窗口）</param>
        /// <param name="formStyle">进度条框的样式</param>
        /// <returns>
        /// 单击取消按钮时：返回DialogResult.Cancel；
        /// 执行超时时：返回DialogResult.Abort；
        /// 当传入的委托执行完毕之后，返回：DialogResult.OK
        /// </returns>
        public static DialogResult ShowAutoProgressDialog(IWin32Window owner,
                                                    Action a,
                                                    Int32 timeout = 60,
                                                    ProgressFormStyle formStyle = null)
        {
            if (a != null)
            {
                ProgressForm form = new ProgressForm(formStyle);
                //用于控制超时的timer对象
                System.Threading.Timer timer =
                    new System.Threading.Timer(new TimerCallback((oForm) =>
                    {
                        Form tempForm = oForm as Form;
                        if (tempForm != null)
                            ControlHelper.ControlInvoke(tempForm, new Action(() =>
                            {
                                tempForm.DialogResult = DialogResult.Abort;
                                tempForm.Close();
                            }));
                    }), form, timeout * 1000, Timeout.Infinite);
                a.BeginInvoke(ShowProgressDialogCallBack, new Object[] { a, form, timer });
                return form.ShowDialog(owner);
            }
            return DialogResult.Cancel;
        }

        #endregion

        #region "私有方法"

        /// <summary>
        /// 把项添加到缓冲区中
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="timeLength"></param>
        private static void AddToCachePool(ProgressBar bar, Int32 timeLength = 10)
        {
#if NET2
            //时长按10分之一s计算，100毫秒更新一次进度条
            locker.AcquireWriterLock(1000);
            try
            {
                for (Int32 i = 0, j = addCachePool.Count; i < j; i++)
                    if (addCachePool[i].Bar == bar) return;
                addCachePool.Add(new ProgressBarWrapper(bar, timeLength * 100));
            }
            finally
            { locker.ReleaseWriterLock(); }
#elif NET4
            //时长按10分之一s计算，100毫秒更新一次进度条
            if (locker.TryEnterWriteLock(1000))
            {
                try
                {
                    for (Int32 i = 0, j = addCachePool.Count; i < j; i++)
                        if (addCachePool[i].Bar == bar) return;
                    addCachePool.Add(new ProgressBarWrapper(bar, timeLength * 100));
                }
                finally
                { locker.ExitWriteLock(); }
            }
#endif
        }

        /// <summary>
        /// 回调方法
        /// </summary>
        /// <param name="result"></param>
        private static void ShowProgressDialogCallBack(IAsyncResult result)
        {
            Object[] values = result.AsyncState as Object[];
            if (values != null && values.Length == 3)
            {
                //停止超时定时器
                System.Threading.Timer timer = values[2] as System.Threading.Timer;
                if (timer != null) timer.Dispose();

                //执行EndInvoke
                Action a = values[0] as Action;
                if (a != null) a.EndInvoke(result);

                //关闭进度条窗体
                ProgressForm form = values[1] as ProgressForm;
                if (form != null)
                    ControlHelper.ControlInvoke(form,
                        new Action(() =>
                        {
                            form.DialogResult = DialogResult.OK;
                            form.Close();
                        }));
            }
        }

        /// <summary>
        /// 执行更新进度条的方法
        /// </summary>
        private static void StartUpdateProgress()
        {
            Int32 result = Interlocked.CompareExchange(ref isRunning, 1, 0);
            if (result == 0) //如果result的原始值为0，即表示原始是停止状态的，则新建一个timer对象
                timer = new System.Threading.Timer(
                    new TimerCallback((o) => { UpdateProgress(); }), null, 100, Timeout.Infinite);
        }

        /// <summary>
        /// 把添加缓冲区中的记录拿到执行缓冲区
        /// </summary>
        private static void CopyToRunningCachePool()
        {
#if NET2
            locker.AcquireWriterLock(1000);
            try
            {
                runningCachePool.AddRange(addCachePool);
                addCachePool.Clear();
            }
            finally
            { locker.ReleaseWriterLock(); }
#elif NET4
            //时长按10分之一s计算，100毫秒更新一次进度条
            if (locker.TryEnterWriteLock(1000))
            {
                try
                {
                    runningCachePool.AddRange(addCachePool);
                    addCachePool.Clear();
                }
                finally
                { locker.ExitWriteLock(); }
            }
#endif
        }

        /// <summary>
        /// 更新进度条的内部方法
        /// </summary>
        private static void UpdateProgress()
        {
            //先把添加缓冲区的工作项复制过来
            CopyToRunningCachePool();            

            //如果没有需要更新的进度条控件，则取消定时器
            if (runningCachePool.Count <= 0)
            {
                timer = null;
                runningCachePool = null;
                addCachePool = null;
                Interlocked.CompareExchange(ref isRunning, 0, 1);
                return;
            }

            //循环更新所有进度条（此循环的j变量的写法必须的，因为在循环内部有移除集合项，如何每次循环计算j的值，则会出现问题）
            for (Int32 i = 0, j = runningCachePool.Count; i < j; i++)
            {
                ProgressBarWrapper bar = runningCachePool[i];
                if (bar.Bar.IsDisposed || bar.Bar.Disposing)
                    runningCachePool.RemoveAt(i);
                else
                    runningCachePool[i].PerformStep();
            }
            //调整定时器，下100毫秒继续执行
            timer.Change(100, Timeout.Infinite);
        }

        #endregion
    }
}
