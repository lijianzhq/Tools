using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.ToolBar
{
    public partial class ToolBar_DonetBar : UserControl, IToolBar
    {
        #region "事件"

        public event EventHandler Add;

        public event EventHandler Delete;

        public event EventHandler Edit;

        public event EventHandler Refresh;

        #endregion

        #region "属性"

        #region "控制按钮文本"

        /// <summary>
        /// 添加按钮文本
        /// </summary>
        public String AddBtnText
        {
            get { return btnAdd.Text; }
            set { btnAdd.Text = value; }
        }

        /// <summary>
        /// 编辑按钮的文本
        /// </summary>
        public String EditBtnText
        {
            get { return btnEdit.Text; }
            set { btnEdit.Text = value; }
        }

        /// <summary>
        /// 删除按钮的文本
        /// </summary>
        public String DeleteBtnText
        {
            get { return btnDelete.Text; }
            set { btnDelete.Text = value; }
        }

        public String RefreshBtnText
        {
            get { return buttonItem1.Text; }
            set { buttonItem1.Text = value; }
        }

        #endregion

        #region "控制按钮可见性"

        /// <summary>
        /// 是否显示添加按钮（默认都是显示）
        /// </summary>
        public Boolean ShowAddBtn
        {
            get { return btnAdd.Visible; }
            set { btnAdd.Visible = value; }
        }

        /// <summary>
        /// 是否显示删除按钮（默认都是显示）
        /// </summary>
        public Boolean ShowDeleteBtn
        {
            get { return btnDelete.Visible; }
            set { btnDelete.Visible = value; }
        }

        /// <summary>
        /// 是否显示编辑按钮（默认都是显示）
        /// </summary>
        public Boolean ShowEditBtn
        {
            get { return btnEdit.Visible; }
            set { btnEdit.Visible = value; }
        }

        /// <summary>
        /// 是否显示刷新按钮
        /// </summary>
        public Boolean ShowRefreshBtn
        {
            get { return buttonItem1.Visible; }
            set { buttonItem1.Visible = value; }
        }

        #endregion

        #endregion

        #region "公共方法"

        public ToolBar_DonetBar()
        {
            InitializeComponent();
        }

        #endregion

        #region "私有方法"

        /// <summary>
        /// 刷新按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (Refresh != null) Refresh(sender, e);
        }

        /// <summary>
        /// 添加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Add != null) Add(sender, e);
        }

        /// <summary>
        /// 编辑按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (Edit != null) Edit(sender, e);
        }

        /// <summary>
        /// 删除按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (Delete != null) Delete(sender, e);
        }

        #endregion
    }
}
