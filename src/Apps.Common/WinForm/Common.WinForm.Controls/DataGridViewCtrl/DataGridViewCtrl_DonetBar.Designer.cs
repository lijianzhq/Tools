namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    partial class DataGridViewCtrl_DonetBar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ToolBarCtrl = new DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.ToolBar.ToolBar_DonetBar();
            this.pageCtrl_DonetBar1 = new DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page.PageCtrl_DonetBar();
            this.circularProgress1 = new DevComponents.DotNetBar.Controls.CircularProgress();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 26);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(792, 259);
            this.dataGridViewX1.TabIndex = 1;
            // 
            // ToolBarCtrl
            // 
            this.ToolBarCtrl.AddBtnText = "添加";
            this.ToolBarCtrl.DeleteBtnText = "删除";
            this.ToolBarCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBarCtrl.EditBtnText = "编辑";
            this.ToolBarCtrl.Location = new System.Drawing.Point(0, 0);
            this.ToolBarCtrl.Name = "ToolBarCtrl";
            this.ToolBarCtrl.ShowAddBtn = true;
            this.ToolBarCtrl.ShowDeleteBtn = true;
            this.ToolBarCtrl.ShowEditBtn = true;
            this.ToolBarCtrl.Size = new System.Drawing.Size(792, 26);
            this.ToolBarCtrl.TabIndex = 0;
            // 
            // pageCtrl_DonetBar1
            // 
            this.pageCtrl_DonetBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageCtrl_DonetBar1.Location = new System.Drawing.Point(0, 257);
            this.pageCtrl_DonetBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageCtrl_DonetBar1.Name = "pageCtrl_DonetBar1";
            this.pageCtrl_DonetBar1.Size = new System.Drawing.Size(792, 28);
            this.pageCtrl_DonetBar1.TabIndex = 2;
            // 
            // circularProgress1
            // 
            this.circularProgress1.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.circularProgress1.BackgroundStyle.Class = "";
            this.circularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress1.Location = new System.Drawing.Point(335, 103);
            this.circularProgress1.Name = "circularProgress1";
            this.circularProgress1.Size = new System.Drawing.Size(95, 67);
            this.circularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress1.TabIndex = 4;
            this.circularProgress1.Visible = false;
            // 
            // DataGridViewCtrl_DonetBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.circularProgress1);
            this.Controls.Add(this.pageCtrl_DonetBar1);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.ToolBarCtrl);
            this.Name = "DataGridViewCtrl_DonetBar";
            this.Size = new System.Drawing.Size(792, 285);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private Page.PageCtrl_DonetBar pageCtrl_DonetBar1;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress1;
        public ToolBar.ToolBar_DonetBar ToolBarCtrl;
    }
}
