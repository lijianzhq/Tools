using System;
using System.ComponentModel;

//DonetBar
using DevComponents.DotNetBar;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page
{
    [ToolboxItem(false)]
    public class PageCP_DonetBar : PageCP
    {
        public ComboBoxItem PageSizeComboBoxItem
        {
            get;
            set;
        }

        public ComboBoxItem PageIndexComboBoxItem
        {
            get;
            set;
        }

        public override int GetPageSize()
        {
            Int32 result = 0;
            if (PageSizeComboBoxItem != null)
                Int32.TryParse(PageSizeComboBoxItem.Text, out result);
            return result;
        }

        public override int GetPageIndex()
        {
            Int32 result = 0;
            if (PageIndexComboBoxItem != null)
                Int32.TryParse(PageIndexComboBoxItem.Text, out result);
            return result;
        }
    }
}
