using System;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    public class FormatDataEventArgs : EventArgs
    {
        /// <summary>
        /// 格式化前的原始值
        /// </summary>
        public Object OriginalValue;

        /// <summary>
        /// 格式化的数据列序号
        /// </summary>
        public Int32 ColumnIndex;

        /// <summary>
        /// 格式化数据的行序号
        /// </summary>
        public Int32 RowIndex;
    }
}
