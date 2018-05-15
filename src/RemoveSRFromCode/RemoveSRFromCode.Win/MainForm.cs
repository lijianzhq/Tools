using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RemoveSRFromCode.Win

{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private CodeFileOperator m_codeFileOperator = new CodeFileOperator();
        private Common.FileOperator2 fileOperator = null;
        private void btn_Convert_Click(object sender, EventArgs e)
        {
            btn_Convert.Enabled = false;
            try
            {
                fileOperator = new Common.FileOperator2(txt_Path.Text, txt_FileType.Text);
                fileOperator.Exception += FileOperator_Exception;
                fileOperator.FileOperatorChain += RemoveSRCode;
                fileOperator.StartAsync();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ShowErrorMessage(ex.Message);
            }
            finally
            {
                btn_Convert.Enabled = true;
            }
        }

        /// <summary>
        /// 移除代码中所有包含SR的地方（注释）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        private void RemoveSRCode(string filePath, Encoding encoding)
        {
            try
            {
                String fileData = File.ReadAllText(filePath, encoding);
                fileData = m_codeFileOperator.RemoveSRCode(fileData);
                File.WriteAllText(filePath, fileData, encoding);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        private void ShowErrorMessage(String errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        private void FileOperator_Exception(object sender, Common.ExceptionEventArgs e)
        {
            ShowErrorMessage(String.Format("path:{0},message:{1}", e.FilePath, e.Msg));
            //MessageBox.Show(String.Format("path:{0},message:{1}", e.FilePath, e.Msg));
        }
    }
}
