using System;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page
{
    /// <summary>
    /// 事件参数
    /// </summary>
    public class PageCtrlEventArgs : EventArgs
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public Int32 TotalRecord
        {
            get;
            set;
        }

        /// <summary>
        /// 页码
        /// </summary>
        public Int32 PageIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 页面大小（每页显示多少条记录）
        /// </summary>
        public Int32 PageSize
        {
            get;
            set;
        }
    }
}
