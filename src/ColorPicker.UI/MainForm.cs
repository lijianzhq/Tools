using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

//自定义命名空间
using DreamCube.Foundation.Basic.Win32API.API;
using DreamCube.Foundation.Basic.Win32API.Enums;
//using DreamCube.WinForm.Common;

namespace ColorPicker.UI
{
    public partial class MainForm : Form
    {
        #region "私有字段"

        private System.Threading.Timer timer = null;

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 处理窗体消息的方法
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键     
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 81:    //按下的是CTRL+F     
                            textBox4.Text = textBox6.Text.Trim();
                            Clipboard.SetText(textBox6.Text.Trim());
                            break;
                        case 82:
                            textBox7.Text = textBox5.Text.Trim();
                            Clipboard.SetText(textBox5.Text.Trim());
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 获取鼠标焦点颜色
        /// </summary>
        /// <returns></returns>
        private Color GetPointColor(Point screenPoint)
        {
            IntPtr displayDC = gdi32.CreateDC("DISPLAY", null, null, IntPtr.Zero);
            uint colorref = gdi32.GetPixel(displayDC, screenPoint.X, screenPoint.Y);
            gdi32.DeleteDC(displayDC);
            byte Red = GetRValue(colorref);
            byte Green = GetGValue(colorref);
            byte Blue = GetBValue(colorref);
            return Color.FromArgb(Red, Green, Blue);
        }

        /// <summary>
        /// 不断获取鼠标所在位置的颜色
        /// </summary>
        private void PickeMousePointColor()
        {
            var delegateItem = new Action<String>((s) =>
            {
                textBox1.Text = String.Format("{0},{1}", Control.MousePosition.X.ToString(), Control.MousePosition.Y.ToString());
                Point pt = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                Color cl = GetPointColor(pt);
                panel1.BackColor = cl;
                textBox5.Text = cl.R + "," + cl.G + "," + cl.B;
                textBox6.Text = ColorTranslator.ToHtml(cl).ToString();
                user32.RegisterHotKey(Handle, 81, KeyModifiers.Ctrl, Keys.F);
                user32.RegisterHotKey(Handle, 82, KeyModifiers.Ctrl, Keys.G);
                if (timer != null) timer.Change(100, Timeout.Infinite);
            });
            if (this.InvokeRequired)
            {
                this.Invoke(delegateItem, "");
            }
            else
            {
                delegateItem.Invoke("");
            }
        }

        /// <summary>
        /// 退出按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗体关闭前触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "确定退出程序吗？", "退出提醒", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer = new System.Threading.Timer(new TimerCallback((o) => { PickeMousePointColor(); }), null, 100, Timeout.Infinite);
        }

        #region "静态方法"

        static public byte GetRValue(uint color)
        {
            return (byte)color;
        }
        static public byte GetGValue(uint color)
        {
            return ((byte)(((short)(color)) >> 8));
        }
        static public byte GetBValue(uint color)
        {
            return ((byte)((color) >> 16));
        }
        static public byte GetAValue(uint color)
        {
            return ((byte)((color) >> 24));
        }

        #endregion
    }
}
