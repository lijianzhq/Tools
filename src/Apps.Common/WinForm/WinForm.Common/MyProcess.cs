using System;
using System.Threading;
using System.Windows.Forms;

using DC = DreamCube.Foundation.Basic.Utility;

namespace DreamCube.WinForm.Common
{
    public static class MyProcess
    {
        public enum ProcessOperationResult
        {
            /// <summary>
            /// 进程正在运行ing
            /// </summary>
            Running,
            /// <summary>
            /// 所检查的进程不存在
            /// </summary>
            NotExists,
            /// <summary>
            /// 用户取消了操作
            /// </summary>
            Cancle
        }

        /// <summary>
        /// 根据进程名，检查是否存在指定的进程，如果存在，则退出
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="processCHName">进程的中文名，用于提示给客户看的</param>
        /// <param name="processExitsMsg">进程存在的时候提示的询问信息</param>
        /// <returns></returns>
        public static ProcessOperationResult QuitProcess(String processName, String processCHName, String processExitsMsg)
        {
            if (DC.MyProcess.IsExistProcess(processName))
            {
                System.Windows.Forms.DialogResult result = MessageBox.Show(processExitsMsg, "提醒", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    //等待IE进程退出
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                        DC.MyProcess.TryKillProcessByName(processName, 2000);
                        //隐藏窗体，让程序继续执行下去
                        MyWaitingForm.Hide();
                    }));
                    String msg = String.Format("正在关闭{0}进程，请稍后", processCHName);
                    String title = String.Format("关闭{0}进程", processCHName);
                    MyWaitingForm.Show(null, msg, title, false);
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    return ProcessOperationResult.Cancle;
                }
            }
            return DC.MyProcess.IsExistProcess(processName) ? ProcessOperationResult.Running : ProcessOperationResult.NotExists;
        }
    }
}
