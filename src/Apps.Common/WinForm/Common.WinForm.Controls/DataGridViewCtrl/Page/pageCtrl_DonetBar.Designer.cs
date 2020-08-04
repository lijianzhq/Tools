namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page
{
    partial class PageCtrl_DonetBar
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
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.textBoxItem1 = new DevComponents.DotNetBar.TextBoxItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem6 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.comboBoxItem1 = new DevComponents.DotNetBar.ComboBoxItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.PageCP = new DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page.PageCP_DonetBar();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2,
            this.buttonItem3,
            this.buttonItem4,
            this.textBoxItem1,
            this.buttonItem5,
            this.labelItem5,
            this.labelItem6,
            this.labelItem1,
            this.comboBoxItem1,
            this.labelItem2,
            this.labelItem3,
            this.labelItem4});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(755, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Image = global::DreamCube.Apps.Common.WinForm.Controls.Properties.Resources.up;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "首页";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Image = global::DreamCube.Apps.Common.WinForm.Controls.Properties.Resources.left;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "上一页";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.Image = global::DreamCube.Apps.Common.WinForm.Controls.Properties.Resources.right;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "下一页";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // buttonItem4
            // 
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.Image = global::DreamCube.Apps.Common.WinForm.Controls.Properties.Resources.down;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "尾页";
            this.buttonItem4.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // textBoxItem1
            // 
            this.textBoxItem1.Name = "textBoxItem1";
            this.textBoxItem1.Tooltip = "输入跳转页码";
            this.textBoxItem1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // buttonItem5
            // 
            this.buttonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem5.Image = global::DreamCube.Apps.Common.WinForm.Controls.Properties.Resources._goto;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "跳转";
            this.buttonItem5.Click += new System.EventHandler(this.buttonItem5_Click);
            // 
            // labelItem5
            // 
            this.labelItem5.Name = "labelItem5";
            this.labelItem5.Text = "页码：";
            // 
            // labelItem6
            // 
            this.labelItem6.ForeColor = System.Drawing.Color.Red;
            this.labelItem6.Name = "labelItem6";
            this.labelItem6.Text = "0/0";
            // 
            // labelItem1
            // 
            this.labelItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "每页显示";
            // 
            // comboBoxItem1
            // 
            this.comboBoxItem1.DropDownHeight = 106;
            this.comboBoxItem1.ItemHeight = 17;
            this.comboBoxItem1.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6});
            this.comboBoxItem1.Name = "comboBoxItem1";
            this.comboBoxItem1.Text = "20";
            this.comboBoxItem1.TextChanged += new System.EventHandler(this.comboBoxItem1_TextChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "10";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "15";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "20";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "40";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "60";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "100";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "条";
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "总数：";
            // 
            // labelItem4
            // 
            this.labelItem4.ForeColor = System.Drawing.Color.Red;
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "0";
            // 
            // PageCP
            // 
            this.PageCP.PageIndex = 1;
            this.PageCP.PageIndexComboBoxItem = null;
            this.PageCP.PageSize = 20;
            this.PageCP.PageSizeComboBoxItem = null;
            this.PageCP.TotalRecord = 0;
            this.PageCP.OnPageIndexChange += new System.EventHandler<DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page.PageCtrlEventArgs>(this.PageCP_OnPageIndexChange);
            this.PageCP.OnPageSizeChange += new System.EventHandler<DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page.PageCtrlEventArgs>(this.PageCP_OnPageSizeChange);
            this.PageCP.OnTotalRecordChange += new System.EventHandler<DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page.PageCtrlEventArgs>(this.PageCP_OnTotalRecordChange);
            // 
            // PageCtrl_DonetBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bar1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PageCtrl_DonetBar";
            this.Size = new System.Drawing.Size(755, 28);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ComboBoxItem comboBoxItem1;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.LabelItem labelItem5;
        private DevComponents.DotNetBar.LabelItem labelItem6;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        internal PageCP_DonetBar PageCP;
    }
}
