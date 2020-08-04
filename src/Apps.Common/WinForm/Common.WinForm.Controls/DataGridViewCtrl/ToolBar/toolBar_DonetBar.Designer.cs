namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.ToolBar
{
    partial class ToolBar_DonetBar
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.buttonItem1});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(721, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAdd.Image = global::DreamCube.Apps.Common.WinForm.Controls.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEdit.Image = global::DreamCube.Apps.Common.WinForm.Controls.Properties.Resources.edit;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelete.Image = global::DreamCube.Apps.Common.WinForm.Controls.Properties.Resources.delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Image = global::DreamCube.Apps.Common.WinForm.Controls.Properties.Resources.refresh;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "刷新";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // ToolBar_DonetBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bar1);
            this.Name = "ToolBar_DonetBar";
            this.Size = new System.Drawing.Size(721, 26);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
    }
}
