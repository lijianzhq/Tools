namespace BaiDuClick
{
    partial class GoogleWB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_restartWB = new System.Windows.Forms.Button();
            this.btn_clickAD = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tab_WB = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tab_WB.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_restartWB);
            this.panel1.Controls.Add(this.btn_clickAD);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 66);
            this.panel1.TabIndex = 0;
            // 
            // btn_restartWB
            // 
            this.btn_restartWB.Location = new System.Drawing.Point(260, 21);
            this.btn_restartWB.Name = "btn_restartWB";
            this.btn_restartWB.Size = new System.Drawing.Size(119, 23);
            this.btn_restartWB.TabIndex = 2;
            this.btn_restartWB.Text = "重启浏览器";
            this.btn_restartWB.UseVisualStyleBackColor = true;
            this.btn_restartWB.Click += new System.EventHandler(this.btn_restartWB_Click);
            // 
            // btn_clickAD
            // 
            this.btn_clickAD.Location = new System.Drawing.Point(121, 20);
            this.btn_clickAD.Name = "btn_clickAD";
            this.btn_clickAD.Size = new System.Drawing.Size(112, 23);
            this.btn_clickAD.TabIndex = 1;
            this.btn_clickAD.Text = "点击广告";
            this.btn_clickAD.UseVisualStyleBackColor = true;
            this.btn_clickAD.Click += new System.EventHandler(this.btn_clickAD_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(28, 21);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 352);
            this.panel2.TabIndex = 1;
            // 
            // tab_WB
            // 
            this.tab_WB.Controls.Add(this.tabPage1);
            this.tab_WB.Controls.Add(this.tabPage2);
            this.tab_WB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_WB.Location = new System.Drawing.Point(0, 0);
            this.tab_WB.Name = "tab_WB";
            this.tab_WB.SelectedIndex = 0;
            this.tab_WB.Size = new System.Drawing.Size(800, 450);
            this.tab_WB.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "浏览器";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_Log);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_Log
            // 
            this.txt_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Log.Location = new System.Drawing.Point(3, 3);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Log.Size = new System.Drawing.Size(786, 418);
            this.txt_Log.TabIndex = 0;
            // 
            // GoogleWB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tab_WB);
            this.Name = "GoogleWB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoogleWB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GoogleWB_Load);
            this.panel1.ResumeLayout(false);
            this.tab_WB.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TabControl tab_WB;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.Button btn_clickAD;
        private System.Windows.Forms.Button btn_restartWB;
    }
}