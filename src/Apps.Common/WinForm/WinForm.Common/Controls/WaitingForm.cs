using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace DreamCube.WinForm.Common.Controls
{
    internal partial class WaitingForm : Form
    {
        private Int32 waitingPointsCount = 5;
        private Int32 changePointsTimeLength = 1000; //更新等待字符的时长，ms为单位
        internal Boolean doNotAutoPoints = false;
        internal String msg = "您好，任务正在处理中,请稍后";

        public WaitingForm()
            : this(String.Empty, false)
        {
        }

        public WaitingForm(String msg)
            : this(msg, false)
        {
        }

        public WaitingForm(String msg, Boolean doNotAutoPoints)
            : this(msg, String.Empty, doNotAutoPoints)
        {
        }

        public WaitingForm(String msg, String title, Boolean doNotAutoPoints)
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(msg))
                this.msg = msg;
            if (!String.IsNullOrEmpty(title))
                this.Text = title;
            this.doNotAutoPoints = doNotAutoPoints;
        }

        /// <summary>
        /// 窗体加载完毕之后处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaitingForm_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) => {
                Int32 count = 0;
                while (true)
                {
                    if (MyControl.CanControlInvoke(this))
                    {
                        String tipsText = this.msg ;
                        for (Int32 j = 0; j <= count; j++)
                            tipsText += ".";
                        MyControl.ControlBeginInvoke(this, new Action<String>((inputWatingText) => { lb_waitingText.Text = inputWatingText; }), tipsText);
                        System.Threading.Thread.Sleep(changePointsTimeLength);
                        if (count >= waitingPointsCount) count = 0;
                        else count++;
                    }
                }
            }), null);
        }
    }
}
