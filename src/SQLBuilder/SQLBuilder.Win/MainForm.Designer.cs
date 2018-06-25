namespace SQLBuilder.Win
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
            this.txt_filePath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_outputSql = new System.Windows.Forms.TextBox();
            this.btn_createScript = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Excel文件路径：";
            // 
            // txt_filePath
            // 
            this.txt_filePath.Location = new System.Drawing.Point(113, 27);
            this.txt_filePath.Name = "txt_filePath";
            this.txt_filePath.Size = new System.Drawing.Size(526, 21);
            this.txt_filePath.TabIndex = 2;
            this.txt_filePath.Text = "templates\\01-create.xlsx";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_outputSql);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 253);
            this.panel1.TabIndex = 3;
            // 
            // txt_outputSql
            // 
            this.txt_outputSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_outputSql.Location = new System.Drawing.Point(0, 0);
            this.txt_outputSql.Multiline = true;
            this.txt_outputSql.Name = "txt_outputSql";
            this.txt_outputSql.Size = new System.Drawing.Size(651, 253);
            this.txt_outputSql.TabIndex = 0;
            // 
            // btn_createScript
            // 
            this.btn_createScript.Location = new System.Drawing.Point(14, 60);
            this.btn_createScript.Name = "btn_createScript";
            this.btn_createScript.Size = new System.Drawing.Size(93, 23);
            this.btn_createScript.TabIndex = 4;
            this.btn_createScript.Text = "创建脚本";
            this.btn_createScript.UseVisualStyleBackColor = true;
            this.btn_createScript.Click += new System.EventHandler(this.btn_createScript_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 342);
            this.Controls.Add(this.btn_createScript);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_filePath);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "SQLBuilder";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_filePath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_outputSql;
        private System.Windows.Forms.Button btn_createScript;
    }
}

