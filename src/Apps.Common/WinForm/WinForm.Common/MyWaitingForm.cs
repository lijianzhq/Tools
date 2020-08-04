using System;
using System.Windows.Forms;

using DreamCube.Foundation.Basic.Utility;

namespace DreamCube.WinForm.Common
{
    /// <summary>
    /// 显示/隐藏等待框
    /// </summary>
    public static class MyWaitingForm
    {
        private static Controls.WaitingForm waitingForm = null;

        /// <summary>
        /// 获取等待窗体的对象
        /// </summary>
        public static Form WaitingForm
        {
            get 
            {
                return waitingForm;
            }
        }

        /// <summary>
        /// 显示等待框
        /// </summary>
        /// <param name="msg"></param>
        public static void Show(String msg)
        {
            Show(null, msg, false);
        }

        /// <summary>
        /// 显示等待框
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="doNotAutoPoints"></param>
        public static void Show(String msg, Boolean doNotAutoPoints)
        {
            Show(null, msg, doNotAutoPoints);
        }

        /// <summary>
        /// 显示等待框
        /// </summary>
        public static void Show()
        {
            Show(null, String.Empty, false);
        }

        /// <summary>
        /// 显示等待框
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="msg"></param>
        public static void Show(IWin32Window parent, String msg)
        {
            Show(parent, msg, false);
        }

        /// <summary>
        /// 显示等待框
        /// </summary>
        /// <param name="parent"></param>
        public static void Show(IWin32Window parent)
        {
            Show(parent, String.Empty, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <param name="doNotAutoPoints"></param>
        public static void Show(IWin32Window parent, String msg, String title, Boolean doNotAutoPoints)
        {
            Show(parent, msg, title, doNotAutoPoints, null);
        }

        /// <summary>
        /// 显示等待框
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="msg">等待窗体的提醒语言</param>
        /// <param name="title">等待窗体的标题</param>
        /// <param name="doNotAutoPoints">不要自动显示动态的点字符</param>
        /// <param name="winShown">等待窗口显示之后回调的方法</param>
        public static void Show(IWin32Window parent, String msg, String title, Boolean doNotAutoPoints, EventHandler winShown)
        {

            if (waitingForm == null || waitingForm.IsDisposed)
            {
                //当前的线程创建 的窗体
                waitingForm = new Controls.WaitingForm(msg, title, doNotAutoPoints);
                if (winShown != null)
                {
                    waitingForm.Shown += new EventHandler(winShown);
                }
                waitingForm.ShowDialog(parent);
            }
            else
            {
                //这里有可能不是当前线程创建的窗体
                MyControl.ControlBeginInvoke(waitingForm, new Action<Object>((o) =>
                {
                    if (!String.IsNullOrEmpty(title))
                        waitingForm.Text = title;
                    waitingForm.msg = msg;
                    waitingForm.doNotAutoPoints = doNotAutoPoints;
                    if (!waitingForm.Visible)
                    {
                        waitingForm.ShowDialog(parent);
                    }
                }), "");
            }
        }

        /// <summary>
        /// 显示等待框
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="msg">等待窗体的提醒语言</param>
        /// <param name="doNotAutoPoints">不要自动显示动态的点字符</param>
        public static void Show(IWin32Window parent, String msg, Boolean doNotAutoPoints)
        {
            Show(parent, msg, String.Empty, doNotAutoPoints);
        }

        /// <summary>
        /// 隐藏等待框
        /// </summary>
        public static void Hide()
        {
            Hide(null);
        }

        /// <summary>
        /// 隐藏等待框
        /// </summary>
        /// <param name="parentForm">隐藏等待窗体之后，设置对应窗体的焦点</param>
        public static void Hide(Form parentForm)
        {
            if (waitingForm != null)
            {
                MyControl.ControlBeginInvoke(waitingForm, new Action<Object>((o) =>
                {
                    waitingForm.Hide();
                    if (parentForm != null)
                    {
                        //让主窗体获得焦点
                        if (MyControl.CanControlInvoke(parentForm))
                        {
                            MyControl.ControlInvoke(parentForm, new Action<Object>((inputForm) =>
                            {
                                try
                                {
                                    ((Form)inputForm).Activate();
                                }
                                catch (Exception ex)
                                {
                                    MyLog.MakeLog(ex);
                                }
                            }), parentForm);
                        }
                    }
                }), parentForm);
            }
        }
    }
}
