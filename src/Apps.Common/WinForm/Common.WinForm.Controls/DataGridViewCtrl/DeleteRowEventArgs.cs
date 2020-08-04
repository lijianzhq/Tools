using System;
using System.Windows.Forms;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    /// <summary>
    /// 删除行时触发的事件
    /// </summary>
    public class DeleteRowEventArgs : EventArgs
    {
        public DataGridViewRow Row;
    }
}
