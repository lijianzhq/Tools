using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page
{
    [ToolboxItem(true)]
    public partial class PageCtrl_WinForm : UserControl
    {
        public PageCtrl_WinForm()
        {
            InitializeComponent();
        }

        private void 首页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageCP.FirstPage(sender, e);
        }

        private void 上一页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageCP.PrePage(sender, e);
        }

        private void 下一页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageCP.NextPage(sender, e);
        }

        private void 尾页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageCP.LastPage(sender, e);
        }

        private void 跳转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageCP.JumpTo(sender, e);
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            PageCP.PageSizeChange(sender, e);
        }

        /// <summary>
        /// 页码变化的时候触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageCP_OnPageIndexChange(object sender, PageCtrlEventArgs e)
        {
            UpdateControl();
        }

        /// <summary>
        /// 页面大小变化触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageCP_OnPageSizeChange(Object sender, PageCtrlEventArgs e)
        {
            UpdateControl();
        }

        private void PageCP_OnTotalRecordChange(Object sender, PageCtrlEventArgs e)
        {
            UpdateControl();
        }

        /// <summary>
        /// 更新控件的显示
        /// </summary>
        private void UpdateControl()
        {
            ControlHelper.ControlInvoke(this, new Action(() =>
            {
                //显示当前页码
                toolStripMenuItem2.Text = String.Format("{0}/{1}", PageCP.PageIndex, PageCP.TotalPage);
                //显示总记录数
                toolStripMenuItem1.Text = PageCP.TotalRecord.ToString();
            }));
        }
    }
}
