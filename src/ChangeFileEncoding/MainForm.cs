using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeFileEncoding
{
    public partial class MainForm : Form
    {
        private EncodingConverter converter = null;

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMsg(String msg)
        {
            if (txt_Result.InvokeRequired)
            {
                txt_Result.Invoke(new Action(() =>
                {
                    txt_Result.Text += msg + Environment.NewLine + Environment.NewLine;
                }));
            }
            else
            {
                txt_Result.Text += msg + Environment.NewLine + Environment.NewLine;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取选择的编码
        /// </summary>
        /// <returns></returns>
        private Encoding GetSelectedEncoding()
        {
            switch (combo_EncodeType.Text.ToLower())
            {
                case "bigendianunicode":
                    return Encoding.BigEndianUnicode;
                case "ansi":
                    return Encoding.Default;
                case "unicode":
                    return Encoding.Unicode;
                case "utf32":
                    return Encoding.UTF32;
                case "utf7":
                    return Encoding.UTF7;
                case "utf8":
                    return Encoding.UTF8;
            }
            return Encoding.Default;
        }

        private Int32 theClickLock = 0;
        /// <summary>
        /// 开始转换按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Convert_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
            if (String.IsNullOrEmpty(txt_Path.Text))
            {
                btn.Enabled = true;
                return;
            }
            if (Interlocked.CompareExchange(ref theClickLock, 1, 0) == 0)
            {
                String txtPath = txt_Path.Text;
                String fileType = txt_FileType.Text;
                Encoding selectedEncoding = GetSelectedEncoding();
                lb_result.Text = "正在转换中...";
                Task.Run(() =>
                {
                    converter = new EncodingConverter(txtPath, fileType, selectedEncoding);
                    converter.ConvertedOne += Converter_Converted;
                    converter.Exception += Converter_Exception;
                    converter.Converted += Converter_Converted1;
                    converter.ConvertAsync();
                });
            }
        }

        private void Converter_Converted1(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                lb_result.Text = "已完成所有转换！";
                btn_Convert.Enabled = true;
                Interlocked.Exchange(ref theClickLock, 0);
            }));
        }

        private void Converter_Exception(object sender, ExceptionEventArgs e)
        {
            ShowMsg(String.Format("【异常】:{0}{1}【堆栈信息】：{2},【source】：{3}", e.Msg, Environment.NewLine, e.Ex.StackTrace, e.Ex.Source));
        }

        private void Converter_Converted(object sender, ConvertedEventArgs e)
        {
            ShowMsg(String.Format("【完成转换编码】：{0}", e.FilePath));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //测试数据
            txt_Path.Text = @"D:\99.临时文件资料\新建文件夹";
        }

        private void txt_Result_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null)
                return;
            if (e.KeyChar == (char)1)       // Ctrl-A 相当于输入了AscII=1的控制字符
            {
                textBox.SelectAll();
                e.Handled = true;      // 不再发出“噔”的声音
            }
        }
    }
}
