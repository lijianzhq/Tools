using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GetSQLFromPLSQLXML
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            txt_outputPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        /// <summary>
        /// 浏览文件按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_browseFile_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 执行抽取sql语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_startGet_Click(object sender, EventArgs e)
        {
            Task<Result> t = new Task<Result>((o) =>
            {
                String[] input = o as String[];
                return Do(input[0], input[1]);
            }, new String[] { txt_inputXMLFilePath.Text, txt_outputPath.Text });
            t.ContinueWith((res) =>
            {
                MessageBox.Show(String.Format("操作完成！操作结果：{0}，结果情况：{1}", res.Result.Status, res.Result.Msg));
            });
            t.Start();
        }

        /// <summary>
        /// 执行任务的方法
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <param name="outputPath"></param>
        private Result Do(String xmlFilePath, String outputPath)
        {
            Result res = new Result()
            {
                Status = false
            };
            if (String.IsNullOrEmpty(xmlFilePath))
                return res;
            try
            {
                String xmlFileName = Path.GetFileNameWithoutExtension(xmlFilePath);
                String outputFilePath = Path.Combine(outputPath, xmlFileName + ".sql");
                XDocument doc = XDocument.Load(xmlFilePath);
                IEnumerable<String> sqlList = doc.Descendants("SQLSTR").Select(e => e.Value);
                using (StreamWriter sw = new StreamWriter(File.Create(outputFilePath)))
                {
                    foreach (String item in sqlList)
                        sw.WriteLine(item);
                    sw.WriteLine("");
                }
                res.Status = true;
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Msg = ex.Message;
            }
            return res;
        }

        public class Result
        {
            public Boolean Status;
            public String Msg;
        }
    }
}
