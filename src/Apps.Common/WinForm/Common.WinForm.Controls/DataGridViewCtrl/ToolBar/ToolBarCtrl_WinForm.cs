using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.ToolBar
{
    public partial class ToolBarCtrl_WinForm : UserControl,IToolBar
    {
        public ToolBarCtrl_WinForm()
        {
            InitializeComponent();
        }

        #region "属性"

        public string AddBtnText
        {
            get { return 添加ToolStripMenuItem.Text; }
            set { 添加ToolStripMenuItem.Text = value; }
        }

        public string EditBtnText
        {
            get { return 编辑ToolStripMenuItem.Text; }
            set { 编辑ToolStripMenuItem.Text = value; }
        }

        public string DeleteBtnText
        {
            get { return 删除ToolStripMenuItem.Text; }
            set { 删除ToolStripMenuItem.Text = value; }
        }

        public string RefreshBtnText
        {
            get { return 刷新ToolStripMenuItem.Text; }
            set { 刷新ToolStripMenuItem.Text = value; }
        }

        public bool ShowAddBtn
        {
            get { return 添加ToolStripMenuItem.Visible; }
            set { 添加ToolStripMenuItem.Visible = value; }
        }

        public bool ShowDeleteBtn
        {
            get { return 删除ToolStripMenuItem.Visible; }
            set { 删除ToolStripMenuItem.Visible = value; }
        }

        public bool ShowEditBtn
        {
            get { return 编辑ToolStripMenuItem.Visible; }
            set { 编辑ToolStripMenuItem.Visible = value; }
        }

        public bool ShowRefreshBtn
        {
            get { return 刷新ToolStripMenuItem.Visible; }
            set { 刷新ToolStripMenuItem.Visible = value; }
        }

        #endregion

        public event EventHandler Add;
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler Refresh;


        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Refresh != null) Refresh(sender, e);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Delete != null) Delete(sender, e);
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Edit != null) Edit(sender, e);
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Add != null) Add(sender, e);
        }
    }
}
