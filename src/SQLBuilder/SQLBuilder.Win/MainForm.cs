using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLBuilder.Win
{
    public partial class MainForm : Form
    {
        private BLL.ISqlBuilderService sqlBuild = new BLL.SqlServerSqlBuilderService();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 生成create脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_createScript_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_filePath.Text)) return;
            txt_outputSql.Text = sqlBuild.Build(txt_filePath.Text);
        }
    }
}
