﻿using System;
using System.Windows.Forms;

namespace DreamCube.Apps.Common.WinForm.Controls
{
    public static class TextBoxHelper
    {
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
