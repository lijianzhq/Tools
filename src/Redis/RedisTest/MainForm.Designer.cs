namespace RedisTest
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_connectionString = new System.Windows.Forms.TextBox();
            this.btn_setval = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.btn_getval = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(397, 26);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "连接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP端口：";
            // 
            // txt_connectionString
            // 
            this.txt_connectionString.Location = new System.Drawing.Point(73, 26);
            this.txt_connectionString.Name = "txt_connectionString";
            this.txt_connectionString.Size = new System.Drawing.Size(300, 21);
            this.txt_connectionString.TabIndex = 2;
            this.txt_connectionString.Text = "127.0.0.1:6379";
            // 
            // btn_setval
            // 
            this.btn_setval.Location = new System.Drawing.Point(397, 106);
            this.btn_setval.Name = "btn_setval";
            this.btn_setval.Size = new System.Drawing.Size(75, 23);
            this.btn_setval.TabIndex = 3;
            this.btn_setval.Text = "SetValue";
            this.btn_setval.UseVisualStyleBackColor = true;
            this.btn_setval.Click += new System.EventHandler(this.btn_setval_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "KEY：";
            // 
            // txt_key
            // 
            this.txt_key.Location = new System.Drawing.Point(73, 68);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(300, 21);
            this.txt_key.TabIndex = 5;
            // 
            // txt_value
            // 
            this.txt_value.Location = new System.Drawing.Point(73, 108);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(300, 21);
            this.txt_value.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "VALUE：";
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(73, 163);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_log.Size = new System.Drawing.Size(300, 173);
            this.txt_log.TabIndex = 8;
            // 
            // btn_getval
            // 
            this.btn_getval.Location = new System.Drawing.Point(397, 66);
            this.btn_getval.Name = "btn_getval";
            this.btn_getval.Size = new System.Drawing.Size(75, 23);
            this.btn_getval.TabIndex = 9;
            this.btn_getval.Text = "GetValue";
            this.btn_getval.UseVisualStyleBackColor = true;
            this.btn_getval.Click += new System.EventHandler(this.btn_getval_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "LOG：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 348);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_getval);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_setval);
            this.Controls.Add(this.txt_connectionString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_connect);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_connectionString;
        private System.Windows.Forms.Button btn_setval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_getval;
        private System.Windows.Forms.Label label4;
    }
}

