using System;

namespace DreamCube.Apps.Common.WinForm.Controls.Progress
{
    /// <summary>
    /// 进度条对话框的样式
    /// </summary>
    public class ProgressFormStyle 
    {
        /// <summary>
        /// 滚动条的最大长度
        /// </summary>
        public Int32 BarMaxLength
        {
            get;
            set;
        }

        /// <summary>
        /// 滚动条的步长
        /// </summary>
        public Int32 BarStep
        {
            get;
            set;
        }

        /// <summary>
        /// 标志是否自动运行进度条
        /// </summary>
        public Boolean AutoRunProgressBar
        {
            get;
            set;
        }

        /// <summary>
        /// 窗体的标题
        /// </summary>
        public String FormTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 标签显示的文字
        /// </summary>
        public String LabelText
        {
            get;
            set;
        }

        /// <summary>
        /// 窗体的宽度
        /// </summary>
        public Int32 Width
        {
            get;
            set;
        }

        /// <summary>
        /// 窗体的高度
        /// </summary>
        public Int32 Height
        {
            get;
            set;
        }

        /// <summary>
        /// 标志是否显示取消按钮
        /// true表示显示，false表示隐藏
        /// </summary>
        public Boolean ShowCancleBtn
        {
            get;
            set;
        }

        /// <summary>
        /// 计划操作的大概所需时长（按秒算的）
        /// </summary>
        public Int32 TimeLength
        {
            get;
            set;
        }
    }
}
