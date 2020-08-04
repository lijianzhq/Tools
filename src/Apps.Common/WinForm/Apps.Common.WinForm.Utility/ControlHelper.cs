using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace DreamCube.Apps.Common.WinForm.Utility
{
    public static class ControlHelper
    {
        /// <summary>
        /// 判断控件是否可以执行方法（被释放或者没有创建完毕，都不可以调用空间的invoke方法了）
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Boolean CanControlInvoke(Control c)
        {
            return !(c.Disposing || c.IsDisposed || !c.Created);
        }

        /// <summary>
        /// 通过UI线程去访问UI元素(支持线程安全访问)；
        /// 注意：在deletegate委托里面，必须先调用此方法CanControlInvoke()判断是否可以调用空间的UI线程执行方法，否则可能会报错
        /// </summary>
        /// <param name="c"></param>
        /// <param name="method"></param>
        public static void ControlInvoke(Control c, Delegate method, params Object[] args)
        {
            if (c.InvokeRequired) c.Invoke(method, args);
            else method.DynamicInvoke(args);
        }

        /// <summary>
        /// 增加Ctrl + A 全选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBoxCtrlA(Object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                tb.SelectAll();
        }
    }
}
