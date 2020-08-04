namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    partial class DataGridViewCtrl_WinForm
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGridViewCtrl_WinForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pageCtrl1 = new DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page.PageCtrl_WinForm();
            this.ToolBarCtrl = new DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.ToolBar.ToolBarCtrl_WinForm();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(812, 288);
            this.dataGridView1.TabIndex = 0;
            // 
            // pageCtrl1
            // 
            this.pageCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageCtrl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageCtrl1.Location = new System.Drawing.Point(0, 316);
            this.pageCtrl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageCtrl1.Name = "pageCtrl1";
            this.pageCtrl1.Size = new System.Drawing.Size(812, 26);
            this.pageCtrl1.TabIndex = 1;
            // 
            // ToolBarCtrl
            // 
            this.ToolBarCtrl.AddBtnText = "添加";
            this.ToolBarCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToolBarCtrl.DeleteBtnText = "删除";
            this.ToolBarCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBarCtrl.EditBtnText = "编辑";
            this.ToolBarCtrl.Location = new System.Drawing.Point(0, 0);
            this.ToolBarCtrl.Name = "ToolBarCtrl";
            this.ToolBarCtrl.RefreshBtnText = "刷新";
            this.ToolBarCtrl.ShowAddBtn = true;
            this.ToolBarCtrl.ShowDeleteBtn = true;
            this.ToolBarCtrl.ShowEditBtn = true;
            this.ToolBarCtrl.ShowRefreshBtn = true;
            this.ToolBarCtrl.Size = new System.Drawing.Size(812, 28);
            this.ToolBarCtrl.TabIndex = 2;
            // 
            // DataGridViewCtrl_WinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ToolBarCtrl);
            this.Controls.Add(this.pageCtrl1);
            this.Name = "DataGridViewCtrl_WinForm";
            this.Size = new System.Drawing.Size(812, 342);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Page.PageCtrl_WinForm pageCtrl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        public ToolBar.ToolBarCtrl_WinForm ToolBarCtrl;
    }
}
