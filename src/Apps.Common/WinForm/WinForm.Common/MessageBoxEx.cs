using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/// <summary> 
/// MessageBox对话框，能够相对于父窗体居中
/// </summary>
namespace DreamCube.WinForm.Common
{
    public class MessageBoxEx
    {
        /// <summary>
        /// 显示文本内容
        /// </summary>
        /// <param name="text">显示文本内容</param>
        /// <returns></returns>
        public static DialogResult Show(String text)
        {
            var frm = Form.ActiveForm;
            _owner = frm.IsMdiContainer ? frm.ActiveMdiChild : frm;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(text);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">显示文本内容</param>
        /// <param name="caption">窗口标题</param>
        /// <returns></returns>
        public static DialogResult Show(String text, String caption)
        {
            var frm = Form.ActiveForm;
            _owner = frm.IsMdiContainer ? frm.ActiveMdiChild : frm;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(text, caption);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">显示文本内容</param>
        /// <param name="caption">窗口标题</param>
        /// <param name="buttons">显示的按钮</param>
        /// <returns></returns>
        public static DialogResult Show(String text, String caption, MessageBoxButtons buttons)
        {
            var frm = Form.ActiveForm;
            _owner = frm.IsMdiContainer ? frm.ActiveMdiChild : frm;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(text, caption, buttons);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">显示文本内容</param>
        /// <param name="caption">窗口标题</param>
        /// <param name="buttons">显示的按钮</param>
        /// <param name="icon">窗口图标</param>
        /// <returns></returns>
        public static DialogResult Show(String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            var frm = Form.ActiveForm;
            _owner = frm.IsMdiContainer ? frm.ActiveMdiChild : frm;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult Show(String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton)
        {
            var frm = Form.ActiveForm;
            _owner = frm.IsMdiContainer ? frm.ActiveMdiChild : frm;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(text, caption, buttons, icon, defButton);
        }

        public static DialogResult Show(String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, MessageBoxOptions options)
        {
            var frm = Form.ActiveForm;
            _owner = frm.IsMdiContainer ? frm.ActiveMdiChild : frm;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(text, caption, buttons, icon, defButton, options);
        }

        public static DialogResult Show(IWin32Window owner, String text)
        {
            _owner = owner;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(owner, text);
        }

        public static DialogResult Show(IWin32Window owner, String text, String caption)
        {
            _owner = owner;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(owner, text, caption);
        }

        public static DialogResult Show(IWin32Window owner, String text, String caption, MessageBoxButtons buttons)
        {
            _owner = owner;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(owner, text, caption, buttons);
        }

        public static DialogResult Show(IWin32Window owner, String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            _owner = owner;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(owner, text, caption, buttons, icon);
        }

        public static DialogResult Show(IWin32Window owner, String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton)
        {
            _owner = owner;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(owner, text, caption, buttons, icon, defButton);
        }

        public static DialogResult Show(IWin32Window owner, String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, MessageBoxOptions options)
        {
            _owner = owner;
            Initialize();
            return System.Windows.Forms.MessageBox.Show(owner, text, caption, buttons, icon, defButton, options);
        }

        #region 私有API

        private static IWin32Window _owner;
        private static HookProc _hookProc;
        private static IntPtr _hHook;

        delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        delegate void TimerProc(IntPtr hWnd, uint uMsg, UIntPtr nIDEvent, uint dwTime);

        const int WH_CALLWNDPROCRET = 12;

        enum CbtHookAction : int
        {
            HCBT_MOVESIZE = 0,
            HCBT_MINMAX = 1,
            HCBT_QS = 2,
            HCBT_CREATEWND = 3,
            HCBT_DESTROYWND = 4,
            HCBT_ACTIVATE = 5,
            HCBT_CLICKSKIPPED = 6,
            HCBT_KEYSKIPPED = 7,
            HCBT_SYSCOMMAND = 8,
            HCBT_SETFOCUS = 9
        }

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        static extern int UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        struct CWPRETSTRUCT
        {
            public IntPtr lResult;
            public IntPtr lParam;
            public IntPtr wParam;
            public uint message;
            public IntPtr hwnd;
        } ;

        static MessageBoxEx()
        {
            _hookProc = new HookProc(MessageBoxHookProc);
            _hHook = IntPtr.Zero;
        }

        private static void Initialize()
        {
            if (_hHook != IntPtr.Zero)
            {
                return;
            }

            if (_owner != null)
            {
                _hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, _hookProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
            }
        }

        private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return CallNextHookEx(_hHook, nCode, wParam, lParam);
            }

            CWPRETSTRUCT msg = (CWPRETSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPRETSTRUCT));
            IntPtr hook = _hHook;

            if (msg.message == (int)CbtHookAction.HCBT_ACTIVATE)
            {
                try
                {
                    CenterWindow(msg.hwnd);
                }
                finally
                {
                    UnhookWindowsHookEx(_hHook);
                    _hHook = IntPtr.Zero;
                }
            }

            return CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private static void CenterWindow(IntPtr hChildWnd)
        {
            Rectangle recChild = new Rectangle(0, 0, 0, 0);
            bool success = GetWindowRect(hChildWnd, ref recChild);

            int width = recChild.Width - recChild.X;
            int height = recChild.Height - recChild.Y;

            Rectangle recParent = new Rectangle(0, 0, 0, 0);
            success = GetWindowRect(_owner.Handle, ref recParent);

            Point ptCenter = new Point(0, 0);
            ptCenter.X = recParent.X + ((recParent.Width - recParent.X) / 2);
            ptCenter.Y = recParent.Y + ((recParent.Height - recParent.Y) / 2);


            Point ptStart = new Point(0, 0);
            ptStart.X = (ptCenter.X - (width / 2));
            ptStart.Y = (ptCenter.Y - (height / 2));

            ptStart.X = (ptStart.X < 0) ? 0 : ptStart.X;
            ptStart.Y = (ptStart.Y < 0) ? 0 : ptStart.Y;

            int result = MoveWindow(hChildWnd, ptStart.X, ptStart.Y, width, height, false);
        }
        #endregion
    }
}