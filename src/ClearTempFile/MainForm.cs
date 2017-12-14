using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

using Common;
using DreamCube.Foundation.Log;

namespace ClearTempFile
{
    public partial class MainForm : Form
    {
        private ClearTempFileFileOperator fileOperator = null;
        private IEnumerable<String> waitForDeleteFiles = null;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开始查找按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StartWork_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
            if (String.IsNullOrEmpty(txt_Path.Text))
            {
                btn.Enabled = true;
                return;
            }
            String btnTag = Convert.ToString(btn.Tag);
            if (btnTag == "find")
            {
                //移除所有项
                dataGrid.Rows.Clear();
                DoFindAllFile();
            }
            else if (btnTag == "delete")
            {
                DoDeleteAllFile();
            }
        }

        /// <summary>
        /// 执行删除所有文件
        /// </summary>
        private void DoDeleteAllFile()
        {
            Task.Run(() =>
            {
                foreach (var item in waitForDeleteFiles)
                {
                    try
                    {
                        //System.IO.File.Delete(item);
                        //采用移回到回收站的方案
                        FileOperator.RemoveFileToRecycleBin(item);
                        UpdateoDataGrid(item, "remove success!");
                    }
                    catch (Exception ex)
                    {
                        UpdateoDataGrid(item, String.Format("remove faile!{0}", ex.Message));
                        Log.Root.LogError(ex);
                    }
                }
            });
            ChangeButton();
        }

        private void UpdateoDataGrid(String filePath, String result)
        {
            this.BeginInvoke(new Action(() =>
            {
                foreach (DataGridViewRow item in dataGrid.Rows)
                {
                    if (Convert.ToString(item.Cells[0].Value) == filePath)
                    {
                        item.Cells[1].Value = result;
                        break;
                    }
                }
            }));
        }

        /// <summary>
        /// 查找所有office的临时文件
        /// </summary>
        private void DoFindAllFile()
        {
            String txtPath = txt_Path.Text;
            String configFileExtesion = ConfigurationManager.AppSettings["tempFileExtention"];
            String[] regexItems = configFileExtesion.Split(';');
            List<Regex> regexList = new List<Regex>();
            foreach (String item in regexItems)
            {
                regexList.Add(new Regex(item));
            }
            Task.Run(() =>
            {
                try
                {
                    fileOperator = new ClearTempFile.ClearTempFileFileOperator(txtPath);
                    Task<IEnumerable<String>> fileList = fileOperator.GetAllFilesAsync();
                    fileList.Wait();
                    AddToDataGrid(fileList.Result.Where((n) =>
                    {
                        //return Path.GetFileName(n).StartsWith("~$");
                        String fileName = Path.GetFileName(n);
                        //~开始的是office的一些碎片文件
                        //.suo文件是vs解决方案生成的一些本地缓存文件
                        //0.tmp文件是svn生成的一些版本文件
                        //return fileName.StartsWith("~") || fileName.EndsWith(".suo") || fileName.EndsWith("0.tmp");
                        Boolean isMatch = false;
                        foreach (Regex regexItem in regexList)
                        {
                            if (regexItem.IsMatch(n))
                            {
                                isMatch = true;
                                break;
                            }
                        }
                        return isMatch;
                    }));
                    ChangeButton();
                }
                catch (Exception ex)
                {
                    Log.Root.LogError(ex);
                }
            });
        }

        private void ChangeButton()
        {
            this.BeginInvoke(new Action(() =>
            {
                String btnTag = Convert.ToString(btn_StartWork.Tag);
                if (btnTag == "delete")
                {
                    btn_StartWork.Enabled = true;
                    btn_StartWork.Text = "开始查找";
                    btn_StartWork.Tag = "find";
                }
                else
                {
                    btn_StartWork.Enabled = true;
                    btn_StartWork.Text = "删除所有";
                    btn_StartWork.Tag = "delete";
                }
            }));
        }

        /// <summary>
        /// 把所有临时文件添加到界面上
        /// </summary>
        /// <param name="fileList"></param>
        private void AddToDataGrid(IEnumerable<String> fileList)
        {
            waitForDeleteFiles = fileList;
            if (fileList != null && fileList.Count() > 0)
            {
                this.BeginInvoke(new Action(() =>
                {
                    foreach (String item in fileList)
                    {
                        dataGrid.Rows.Add(item, "等待删除");
                    }
                }));
            }
            else
            {
                ChangeButton();
            }
        }
    }
}
