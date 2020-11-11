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
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Conflict_Log = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_startCopy = new System.Windows.Forms.Button();
            this.txt_targetDBConnStr = new System.Windows.Forms.TextBox();
            this.txt_sourceDBConnStr = new System.Windows.Forms.TextBox();
            this.comb_targetDBType = new System.Windows.Forms.ComboBox();
            this.comb_souceDBType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_sourceDB = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_connectionStr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_setTableKey = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Log
            // 
            this.txt_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Log.Location = new System.Drawing.Point(0, 12);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Log.Size = new System.Drawing.Size(1172, 95);
            this.txt_Log.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "日志输出：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_Log);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_Conflict_Log);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1172, 204);
            this.panel1.TabIndex = 11;
            // 
            // txt_Conflict_Log
            // 
            this.txt_Conflict_Log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_Conflict_Log.Location = new System.Drawing.Point(0, 107);
            this.txt_Conflict_Log.Multiline = true;
            this.txt_Conflict_Log.Name = "txt_Conflict_Log";
            this.txt_Conflict_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Conflict_Log.Size = new System.Drawing.Size(1172, 97);
            this.txt_Conflict_Log.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_startCopy);
            this.panel2.Controls.Add(this.txt_targetDBConnStr);
            this.panel2.Controls.Add(this.txt_sourceDBConnStr);
            this.panel2.Controls.Add(this.comb_targetDBType);
            this.panel2.Controls.Add(this.comb_souceDBType);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lb_sourceDB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1172, 216);
            this.panel2.TabIndex = 12;
            // 
            // btn_startCopy
            // 
            this.btn_startCopy.Location = new System.Drawing.Point(896, 39);
            this.btn_startCopy.Name = "btn_startCopy";
            this.btn_startCopy.Size = new System.Drawing.Size(139, 59);
            this.btn_startCopy.TabIndex = 19;
            this.btn_startCopy.Text = "同步唯一索引";
            this.btn_startCopy.UseVisualStyleBackColor = true;
            this.btn_startCopy.Click += new System.EventHandler(this.btn_startCopy_Click);
            // 
            // txt_targetDBConnStr
            // 
            this.txt_targetDBConnStr.Location = new System.Drawing.Point(120, 148);
            this.txt_targetDBConnStr.Multiline = true;
            this.txt_targetDBConnStr.Name = "txt_targetDBConnStr";
            this.txt_targetDBConnStr.Size = new System.Drawing.Size(757, 58);
            this.txt_targetDBConnStr.TabIndex = 18;
            this.txt_targetDBConnStr.Text = "server=222.187.215.123;uid=aps;pwd=@midea2018@;database=APSDEV;Connect Timeout=36" +
    "00";
            // 
            // txt_sourceDBConnStr
            // 
            this.txt_sourceDBConnStr.Location = new System.Drawing.Point(120, 36);
            this.txt_sourceDBConnStr.Multiline = true;
            this.txt_sourceDBConnStr.Name = "txt_sourceDBConnStr";
            this.txt_sourceDBConnStr.Size = new System.Drawing.Size(757, 62);
            this.txt_sourceDBConnStr.TabIndex = 17;
            this.txt_sourceDBConnStr.Text = resources.GetString("txt_sourceDBConnStr.Text");
            // 
            // comb_targetDBType
            // 
            this.comb_targetDBType.FormattingEnabled = true;
            this.comb_targetDBType.Items.AddRange(new object[] {
            "sqlserver",
            "oracle"});
            this.comb_targetDBType.Location = new System.Drawing.Point(120, 122);
            this.comb_targetDBType.Name = "comb_targetDBType";
            this.comb_targetDBType.Size = new System.Drawing.Size(121, 20);
            this.comb_targetDBType.TabIndex = 16;
            // 
            // comb_souceDBType
            // 
            this.comb_souceDBType.FormattingEnabled = true;
            this.comb_souceDBType.Items.AddRange(new object[] {
            "sqlserver",
            "oracle"});
            this.comb_souceDBType.Location = new System.Drawing.Point(120, 10);
            this.comb_souceDBType.Name = "comb_souceDBType";
            this.comb_souceDBType.Size = new System.Drawing.Size(121, 20);
            this.comb_souceDBType.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "目标数据库连接串：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "目标数据库：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "源数据库连接串：";
            // 
            // lb_sourceDB
            // 
            this.lb_sourceDB.AutoSize = true;
            this.lb_sourceDB.Location = new System.Drawing.Point(55, 12);
            this.lb_sourceDB.Name = "lb_sourceDB";
            this.lb_sourceDB.Size = new System.Drawing.Size(65, 12);
            this.lb_sourceDB.TabIndex = 11;
            this.lb_sourceDB.Text = "源数据库：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1186, 452);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1178, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "同步唯一索引";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1178, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置主键";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_connectionStr);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btn_setTableKey);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txt_ID);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1172, 133);
            this.panel3.TabIndex = 10;
            // 
            // txt_connectionStr
            // 
            this.txt_connectionStr.Location = new System.Drawing.Point(110, 12);
            this.txt_connectionStr.Multiline = true;
            this.txt_connectionStr.Name = "txt_connectionStr";
            this.txt_connectionStr.Size = new System.Drawing.Size(644, 49);
            this.txt_connectionStr.TabIndex = 1;
            this.txt_connectionStr.Text = "DATA SOURCE=10.16.40.171:1521/apsweb.midea.com;PASSWORD=aps;PERSIST SECURITY INFO" +
    "=True;USER ID=aps";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "连接字符串：";
            // 
            // btn_setTableKey
            // 
            this.btn_setTableKey.Location = new System.Drawing.Point(415, 73);
            this.btn_setTableKey.Name = "btn_setTableKey";
            this.btn_setTableKey.Size = new System.Drawing.Size(75, 23);
            this.btn_setTableKey.TabIndex = 6;
            this.btn_setTableKey.Text = "设置为主键";
            this.btn_setTableKey.UseVisualStyleBackColor = true;
            this.btn_setTableKey.Click += new System.EventHandler(this.btn_setTableKey_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "表名：";
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(298, 75);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(100, 21);
            this.txt_ID.TabIndex = 5;
            this.txt_ID.Text = "ID";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(110, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "字段名：";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1172, 420);
            this.textBox1.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 452);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_startCopy;
        private System.Windows.Forms.TextBox txt_targetDBConnStr;
        private System.Windows.Forms.TextBox txt_sourceDBConnStr;
        private System.Windows.Forms.ComboBox comb_targetDBType;
        private System.Windows.Forms.ComboBox comb_souceDBType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_sourceDB;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_connectionStr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_setTableKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txt_Conflict_Log;
    }
}

