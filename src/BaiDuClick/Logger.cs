using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiDuClick
{
    public class Logger
    {
        private TextBox _logTextBox = null;

        public Logger(TextBox txtBox)
        {
            this._logTextBox = txtBox;
        }

        public void Debug(String text)
        {
            this._logTextBox.Invoke(new Action(() =>
            {
                this._logTextBox.Text += text + Environment.NewLine;
            }));
        }
    }
}
