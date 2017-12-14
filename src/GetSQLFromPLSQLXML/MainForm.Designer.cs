namespace GetSQLFromPLSQLXML
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_inputXMLFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_outputPath = new System.Windows.Forms.TextBox();
            this.btn_startGet = new System.Windows.Forms.Button();
            this.btn_browseFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "xml文件路径：";
            // 
            // txt_inputXMLFilePath
            // 
            this.txt_inputXMLFilePath.Location = new System.Drawing.Point(100, 31);
            this.txt_inputXMLFilePath.Name = "txt_inputXMLFilePath";
            this.txt_inputXMLFilePath.Size = new System.Drawing.Size(331, 21);
            this.txt_inputXMLFilePath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "输出路径：";
            // 
            // txt_outputPath
            // 
            this.txt_outputPath.Location = new System.Drawing.Point(100, 85);
            this.txt_outputPath.Name = "txt_outputPath";
            this.txt_outputPath.Size = new System.Drawing.Size(331, 21);
            this.txt_outputPath.TabIndex = 3;
            // 
            // btn_startGet
            // 
            this.btn_startGet.Location = new System.Drawing.Point(222, 142);
            this.btn_startGet.Name = "btn_startGet";
            this.btn_startGet.Size = new System.Drawing.Size(75, 23);
            this.btn_startGet.TabIndex = 4;
            this.btn_startGet.Text = "开始抽取";
            this.btn_startGet.UseVisualStyleBackColor = true;
            this.btn_startGet.Click += new System.EventHandler(this.btn_startGet_Click);
            // 
            // btn_browseFile
            // 
            this.btn_browseFile.Location = new System.Drawing.Point(437, 30);
            this.btn_browseFile.Name = "btn_browseFile";
            this.btn_browseFile.Size = new System.Drawing.Size(75, 23);
            this.btn_browseFile.TabIndex = 5;
            this.btn_browseFile.Text = "浏览...";
            this.btn_browseFile.UseVisualStyleBackColor = true;
            this.btn_browseFile.Click += new System.EventHandler(this.btn_browseFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 188);
            this.Controls.Add(this.btn_browseFile);
            this.Controls.Add(this.btn_startGet);
            this.Controls.Add(this.txt_outputPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_inputXMLFilePath);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "根据PLSQL导出的xml文件抽取sql语句";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_inputXMLFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_outputPath;
        private System.Windows.Forms.Button btn_startGet;
        private System.Windows.Forms.Button btn_browseFile;
    }
}

