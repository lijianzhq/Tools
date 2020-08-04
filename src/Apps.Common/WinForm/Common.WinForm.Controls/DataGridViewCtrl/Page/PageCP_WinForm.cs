using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page
{
    [ToolboxItem(false)]
    public class PageCP_WinForm : PageCP
    {
        public ToolStripItem PageSizeToolStripItem
        {
            get;
            set;
        }

        public ToolStripItem PageIndexToolStripItem
        {
            get;
            set;
        }

        public override Int32 GetPageSize()
        {
            Int32 result = 0;
            if (PageSizeToolStripItem != null)
                Int32.TryParse(PageSizeToolStripItem.Text, out result);
            return result;
        }

        public override Int32 GetPageIndex()
        {
            Int32 result = 0;
            if (PageIndexToolStripItem != null)
                Int32.TryParse(PageIndexToolStripItem.Text, out result);
            return result;
        }
    }
}
