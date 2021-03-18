using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiDuClickWrapper
{
    public partial class MainForm : Form
    {
        private String _appUrl = @"E:\01.Work\MyGithub\Tools\src\BaiDuClick\bin\Debug\BaiDuClick.exe";

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = _appUrl;
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Maximized;
            Process pro = Process.Start(info);
            pro.WaitForExit();
        }
    }
}
