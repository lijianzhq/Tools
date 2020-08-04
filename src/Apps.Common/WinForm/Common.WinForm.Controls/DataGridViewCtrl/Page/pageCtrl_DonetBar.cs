using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page
{
    [ToolboxItem(true)]
    public partial class PageCtrl_DonetBar : UserControl
    {
        #region "公共方法"

        public PageCtrl_DonetBar()
        {
            InitializeComponent();
        }

        #endregion

        #region "按钮事件方法"

        /// <summary>
        /// 首页按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            PageCP.FirstPage(sender, e);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            PageCP.PrePage(sender, e);
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            PageCP.NextPage(sender, e);
        }

        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            PageCP.LastPage(sender, e);
        }

        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            PageCP.JumpTo(sender, e);
        }

        /// <summary>
        /// 选择每页显示不同的变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxItem1_TextChanged(object sender, EventArgs e)
        {
            PageCP.PageSizeChange(sender, e);
        }
        
        #endregion

        #region "分页模块的事件"

        private void PageCP_OnPageIndexChange(object sender, PageCtrlEventArgs e)
        {

        }

        private void PageCP_OnPageSizeChange(object sender, PageCtrlEventArgs e)
        {

        }

        private void PageCP_OnTotalRecordChange(object sender, PageCtrlEventArgs e)
        {

        }

        #endregion

        #region "私有方法"

        /// <summary>
        /// 更新控件的显示
        /// </summary>
        private void UpdateControl()
        {
            ControlHelper.ControlInvoke(this, new Action(() =>
            {
                //显示当前页码
                labelItem6.Text = String.Format("{0}/{1}", PageCP.PageIndex, PageCP.TotalPage);
                //显示总记录数
                labelItem4.Text = PageCP.TotalRecord.ToString();
            }));
        }

        #endregion
    }
}
