using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedisTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                var csredis = new CSRedis.CSRedisClient(txt_connectionString.Text);
                RedisHelper.Initialization(csredis);//初始化
                AppendLog("连接成功！");
            }
            catch (Exception ex)
            {
                AppendLog($"连接失败！异常信息：{ex.Message}");
            }
        }

        private void AppendLog(String msg)
        {
            txt_log.Text += msg + Environment.NewLine;
        }

        private void btn_getval_Click(object sender, EventArgs e)
        {
            var value = RedisHelper.Get<String>(txt_key.Text);
            AppendLog($"KEY：{txt_key.Text},VALUE：{value}");
        }

        private void btn_setval_Click(object sender, EventArgs e)
        {
            try
            {
                RedisHelper.Set(txt_key.Text, txt_value.Text);
                AppendLog("设置值成功！");
            }
            catch (Exception ex)
            {
                AppendLog($"设置值失败！异常信息：{ex.Message}");
            }
        }
    }
}
