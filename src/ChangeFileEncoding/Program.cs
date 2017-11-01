using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeFileEncoding
{
    static class Program
    {

        private static MainForm _mainWin = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            _mainWin = new MainForm();
            Application.Run(_mainWin);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //throw new NotImplementedException();
            _mainWin.ShowMsg(String.Format("Application_ThreadException:{0}", e.Exception.Message));
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //throw new NotImplementedException();
            _mainWin.ShowMsg(String.Format("CurrentDomain_UnhandledException:{0}", e.ExceptionObject.ToString()));
        }
    }
}
