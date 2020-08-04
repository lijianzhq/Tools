using System;
using System.Windows.Forms;

namespace DreamCube.Apps.Common.WinForm.Controls.Progress
{
    internal class ProgressBarWrapper
    {
        #region "属性"

        /// <summary>
        /// 对应的进度条控件
        /// </summary>
        public ProgressBar Bar
        {
            get;
            private set;
        }

        #endregion

        /// <summary>
        /// 创建进度条控件的封装对象
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="timeLength">模拟时长</param>
        public ProgressBarWrapper(ProgressBar bar, Int32 timeLength = 10000)
        {
            this.Bar = bar;
            this.Bar.Maximum = timeLength;
            this.Bar.Minimum = 1;
            this.Bar.Value = 1;
        }

        /// <summary>
        /// 增加进度条的进度
        /// </summary>
        public void PerformStep()
        {
            ControlHelper.ControlInvoke(this.Bar, new Action(() =>
            {
                if (!ControlHelper.CanControlInvoke(this.Bar)) return;
                if (this.Bar.Value < this.Bar.Maximum)
                    this.Bar.PerformStep();
            }));
        }

        /// <summary>
        /// 判断对象是否相等的
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Boolean Equals(Object obj)
        {
            if (obj == null || (obj.GetType().ToString() != this.GetType().ToString()))
                return false;
            Boolean result = false;
            ControlHelper.ControlInvoke(this.Bar, new Action(() =>
            {
                if (!ControlHelper.CanControlInvoke(this.Bar)) return;
                result = this.Bar.Equals(((ProgressBarWrapper)obj).Bar);
            }));
            return result;
        }

        /// <summary>
        /// 重写Equals方法必须重写此方法
        /// </summary>
        /// <returns></returns>
        public override Int32 GetHashCode()
        {
            Int32 result =- 1;
            ControlHelper.ControlInvoke(this.Bar, new Action(() => {
                if (!ControlHelper.CanControlInvoke(this.Bar)) return;
                result = this.Bar.GetHashCode();
            }));
            return result;
        }
    }
}
