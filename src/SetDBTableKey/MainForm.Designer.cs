namespace SetDBTableKey
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_connectionStr = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_setTableKey = new System.Windows.Forms.Button();
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "连接字符串：";
            // 
            // txt_connectionStr
            // 
            this.txt_connectionStr.Location = new System.Drawing.Point(126, 30);
            this.txt_connectionStr.Multiline = true;
            this.txt_connectionStr.Name = "txt_connectionStr";
            this.txt_connectionStr.Size = new System.Drawing.Size(644, 49);
            this.txt_connectionStr.TabIndex = 1;
            this.txt_connectionStr.Text = "DATA SOURCE=10.16.40.171:1521/apsweb.midea.com;PASSWORD=aps;PERSIST SECURITY INFO" +
    "=True;USER ID=aps";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(126, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "表名：";
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(314, 93);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(100, 21);
            this.txt_ID.TabIndex = 5;
            this.txt_ID.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "字段名：";
            // 
            // btn_setTableKey
            // 
            this.btn_setTableKey.Location = new System.Drawing.Point(431, 91);
            this.btn_setTableKey.Name = "btn_setTableKey";
            this.btn_setTableKey.Size = new System.Drawing.Size(75, 23);
            this.btn_setTableKey.TabIndex = 6;
            this.btn_setTableKey.Text = "设置为主键";
            this.btn_setTableKey.UseVisualStyleBackColor = true;
            this.btn_setTableKey.Click += new System.EventHandler(this.btn_setTableKey_Click);
            // 
            // txt_Log
            // 
            this.txt_Log.Location = new System.Drawing.Point(126, 152);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Log.Size = new System.Drawing.Size(644, 57);
            this.txt_Log.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 221);
            this.Controls.Add(this.txt_Log);
            this.Controls.Add(this.btn_setTableKey);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_connectionStr);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置数据库表主键";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_connectionStr;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_setTableKey;
        private System.Windows.Forms.TextBox txt_Log;
    }
}

