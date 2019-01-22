namespace DBCopy.Win
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lb_sourceDB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comb_souceDBType = new System.Windows.Forms.ComboBox();
            this.comb_targetDBType = new System.Windows.Forms.ComboBox();
            this.txt_sourceDBConnStr = new System.Windows.Forms.TextBox();
            this.txt_targetDBConnStr = new System.Windows.Forms.TextBox();
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_startCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_sourceDB
            // 
            this.lb_sourceDB.AutoSize = true;
            this.lb_sourceDB.Location = new System.Drawing.Point(51, 17);
            this.lb_sourceDB.Name = "lb_sourceDB";
            this.lb_sourceDB.Size = new System.Drawing.Size(65, 12);
            this.lb_sourceDB.TabIndex = 0;
            this.lb_sourceDB.Text = "源数据库：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "源数据库连接串：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "目标数据库：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "目标数据库连接串：";
            // 
            // comb_souceDBType
            // 
            this.comb_souceDBType.FormattingEnabled = true;
            this.comb_souceDBType.Items.AddRange(new object[] {
            "sqlserver",
            "oracle"});
            this.comb_souceDBType.Location = new System.Drawing.Point(116, 15);
            this.comb_souceDBType.Name = "comb_souceDBType";
            this.comb_souceDBType.Size = new System.Drawing.Size(121, 20);
            this.comb_souceDBType.TabIndex = 4;
            // 
            // comb_targetDBType
            // 
            this.comb_targetDBType.FormattingEnabled = true;
            this.comb_targetDBType.Items.AddRange(new object[] {
            "sqlserver",
            "oracle"});
            this.comb_targetDBType.Location = new System.Drawing.Point(116, 127);
            this.comb_targetDBType.Name = "comb_targetDBType";
            this.comb_targetDBType.Size = new System.Drawing.Size(121, 20);
            this.comb_targetDBType.TabIndex = 5;
            // 
            // txt_sourceDBConnStr
            // 
            this.txt_sourceDBConnStr.Location = new System.Drawing.Point(116, 41);
            this.txt_sourceDBConnStr.Multiline = true;
            this.txt_sourceDBConnStr.Name = "txt_sourceDBConnStr";
            this.txt_sourceDBConnStr.Size = new System.Drawing.Size(439, 62);
            this.txt_sourceDBConnStr.TabIndex = 6;
            this.txt_sourceDBConnStr.Text = "server=10.16.90.157\\MSDEV;uid=aps;pwd=@midea2018@;database=apsdev;Connect Timeout" +
    "=3600";
            // 
            // txt_targetDBConnStr
            // 
            this.txt_targetDBConnStr.Location = new System.Drawing.Point(116, 153);
            this.txt_targetDBConnStr.Multiline = true;
            this.txt_targetDBConnStr.Name = "txt_targetDBConnStr";
            this.txt_targetDBConnStr.Size = new System.Drawing.Size(439, 58);
            this.txt_targetDBConnStr.TabIndex = 7;
            this.txt_targetDBConnStr.Text = resources.GetString("txt_targetDBConnStr.Text");
            // 
            // txt_Log
            // 
            this.txt_Log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_Log.Location = new System.Drawing.Point(0, 251);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Log.Size = new System.Drawing.Size(755, 124);
            this.txt_Log.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "日志输出：";
            // 
            // btn_startCopy
            // 
            this.btn_startCopy.Location = new System.Drawing.Point(604, 44);
            this.btn_startCopy.Name = "btn_startCopy";
            this.btn_startCopy.Size = new System.Drawing.Size(139, 59);
            this.btn_startCopy.TabIndex = 10;
            this.btn_startCopy.Text = "开始复制";
            this.btn_startCopy.UseVisualStyleBackColor = true;
            this.btn_startCopy.Click += new System.EventHandler(this.btn_startCopy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 375);
            this.Controls.Add(this.btn_startCopy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Log);
            this.Controls.Add(this.txt_targetDBConnStr);
            this.Controls.Add(this.txt_sourceDBConnStr);
            this.Controls.Add(this.comb_targetDBType);
            this.Controls.Add(this.comb_souceDBType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_sourceDB);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_sourceDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comb_souceDBType;
        private System.Windows.Forms.ComboBox comb_targetDBType;
        private System.Windows.Forms.TextBox txt_sourceDBConnStr;
        private System.Windows.Forms.TextBox txt_targetDBConnStr;
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_startCopy;
    }
}

