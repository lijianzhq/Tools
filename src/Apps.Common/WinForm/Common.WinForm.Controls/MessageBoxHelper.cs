using System;
using System.Windows.Forms;

//DotNetBar
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace DreamCube.Apps.Common.WinForm.Controls
{
    /// <summary>
    /// 提示框
    /// </summary>
    public static class MessageBoxHelper
    {
        #region "字段"

        private static MessageBoxStyle msgBoxtyle = MessageBoxStyle.DotnetBar;

        #endregion

        #region "静态构造方法"

        /// <summary>
        /// 类型构造方法
        /// </summary>
        static MessageBoxHelper()
        {
            try
            {
                if (System.Environment.OSVersion.Version.Major >= 6)
                    msgBoxtyle = MessageBoxStyle.Windows;
                if (msgBoxtyle == MessageBoxStyle.DotnetBar)
                    MessageBoxEx.UseSystemLocalizedString = true;
            }
            catch (Exception)
            { msgBoxtyle = MessageBoxStyle.Windows; }
        }

        #endregion

        #region "公共静态方法"

        /// <summary>
        /// Error对话框
        /// </summary>
        /// <param name="owner">所属父窗体</param>
        /// <param name="text">提示内容</param>
        /// <returns></returns>
        public static DialogResult Error(IWin32Window owner, String text)
        {
            return Error(owner, text, "错误");
        }

        /// <summary>
        /// Error对话框
        /// </summary>
        /// <param name="owner">所属父窗体</param>
        /// <param name="text">提示内容</param>
        /// <param name="caption">窗体的标题</param>
        /// <returns></returns>
        public static DialogResult Error(IWin32Window owner, String text, String caption)
        {
            if (msgBoxtyle == MessageBoxStyle.Windows)
                return MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (msgBoxtyle == MessageBoxStyle.DotnetBar)
                return MessageBoxEx.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return DialogResult.OK;
        }

        /// <summary>
        /// Information对话框
        /// </summary>
        /// <param name="owner">所属父窗体</param>
        /// <param name="text">提示内容</param>
        /// <returns></returns>
        public static DialogResult Information(IWin32Window owner, String text)
        {
            return Information(owner, text, "提示");
        }

        /// <summary>
        /// Information对话框
        /// </summary>
        /// <param name="owner">所属父窗体</param>
        /// <param name="text">提示内容</param>
        /// <param name="caption">窗体的标题</param>
        /// <returns></returns>
        public static DialogResult Information(IWin32Window owner, String text, String caption)
        {
            if (msgBoxtyle == MessageBoxStyle.Windows)
                return MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (msgBoxtyle == MessageBoxStyle.DotnetBar)
                return MessageBoxEx.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return DialogResult.OK;
        }

        /// <summary>
        /// YesNo对话框
        /// </summary>
        /// <param name="owner">所属父窗体</param>
        /// <param name="text">提示内容</param>
        /// <returns></returns>
        public static DialogResult YesNo(IWin32Window owner, String text)
        {
            return YesNo(owner, text, "提示");
        }

        /// <summary>
        /// YesNo对话框
        /// </summary>
        /// <param name="owner">所属父窗体</param>
        /// <param name="text">提示内容</param>
        /// <param name="caption">窗体的标题</param>
        /// <returns></returns>
        public static DialogResult YesNo(IWin32Window owner, String text,String caption)
        {
            if (msgBoxtyle == MessageBoxStyle.Windows)
                return MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else if (msgBoxtyle == MessageBoxStyle.DotnetBar) 
                return MessageBoxEx.Show(owner, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return DialogResult.No;
        }

        #endregion

        #region "内部枚举类型"

        /// <summary>
        /// 消息框模式
        /// </summary>
        public enum MessageBoxStyle
        {
            /// <summary>
            /// Windows模式
            /// </summary>
            Windows,

            /// <summary>
            /// DotNetBar 模式
            /// </summary>
            DotnetBar
        }

        #endregion
    }
}
