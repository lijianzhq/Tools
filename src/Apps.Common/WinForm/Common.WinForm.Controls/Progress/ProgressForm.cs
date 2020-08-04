using System;
using System.Windows.Forms;

namespace DreamCube.Apps.Common.WinForm.Controls.Progress
{
    public partial class ProgressForm : Form
    {
        #region "私有字段"

        /// <summary>
        /// 需要执行的耗时的操作
        /// </summary>
        private Action a;

        /// <summary>
        /// 窗体的样式
        /// </summary>
        private ProgressFormStyle style;

        /// <summary>
        /// 时长
        /// </summary>
        private Int32 timeLength = 10;

        #endregion

        #region "公共方法"

        public ProgressForm()
            : this(null)
        { }

        public ProgressForm(ProgressFormStyle style)
            : this(style, null)
        { }

        public ProgressForm(ProgressFormStyle style, Action a)
        {
            InitializeComponent();
            if (this.style == null) style = new ProgressFormStyle();
            this.style = style;
            this.a = a;
            if (style != null)
            {
                this.Width = style.Width == 0 ? this.Width : style.Width;
                this.Height = style.Height == 0 ? this.Height : style.Height;
                this.btn_cancle.Visible = style.ShowCancleBtn;
                this.timeLength = style.TimeLength == 0 ? this.timeLength : style.TimeLength;
                this.Text = String.IsNullOrEmpty(style.FormTitle) ? this.Text : style.FormTitle;
                this.progressBar1.Maximum = style.BarMaxLength == 0 ? this.progressBar1.Maximum : style.BarMaxLength;
                this.progressBar1.Step = style.BarStep == 0 ? this.progressBar1.Step : style.BarStep;
                this.label1.Text = String.IsNullOrEmpty(style.LabelText) ? this.label1.Text : style.LabelText;
            }

            this.Shown += new EventHandler(ProgressForm_Shown);        

            //绑定事件
            BindEvent();
        }

        /// <summary>
        /// 显示窗体的时候，自动执行耗时操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProgressForm_Shown(object sender, EventArgs e)
        {
            if (a != null) a.BeginInvoke(null, null);
        }

        /// <summary>
        /// 使进度条更近一步
        /// </summary>
        public void PerformStep()
        {
            ControlHelper.ControlInvoke(this, new Action(() =>
            {
                if (ControlHelper.CanControlInvoke(this))
                    this.progressBar1.PerformStep();
            }));
        }

        #endregion

        #region "私有方法"

        /// <summary>
        /// 绑定事件
        /// </summary>
        private void BindEvent()
        {
            this.Load += new EventHandler(ProgressForm_Load);
            this.FormClosing += new FormClosingEventHandler(ProgressForm_FormClosing);
            this.btn_cancle.Click += new EventHandler(btn_cancle_Click);
        }

        /// <summary>
        /// 窗体关闭前触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.progressBar1.Dispose();
        }

        /// <summary>
        /// 取消按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btn_cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 窗体加载的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProgressForm_Load(object sender, EventArgs e)
        {
            if(style.AutoRunProgressBar)
                ProgressBarHelper.StartBar(progressBar1, this.timeLength);
        }

        #endregion
    }
}
