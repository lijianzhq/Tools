using System;
using System.Windows.Forms;

using DreamCube.Foundation.Basic.Utility;

namespace DreamCube.WinForm.Common
{
    public static class MyComboBox
    {
        /// <summary>
        /// 选中指定的项
        /// </summary>
        /// <param name="combobox"></param>
        /// <param name="item"></param>
        public static void SelectItem(ComboBox combobox, Object item)
        {
            MyControl.ControlInvoke(combobox, new Action<ComboBox, Object>((inCombobox, inItem) =>
            {
                try
                {
                    ComboBox c = inCombobox;
                    for (Int32 i = 0, j = c.Items.Count; i < j; i++)
                    {
                        if (Convert.ToString(c.Items[i]) == Convert.ToString(inItem))
                        {
                            c.SelectedIndex = i;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MyLog.MakeLog(ex);
                }

            }), combobox, item);
        }

        /// <summary>
        /// 根据字符串，自动生成下拉选择项
        /// </summary>
        /// <param name="combobox">指定的combobox对象</param>
        /// <param name="items"></param>
        /// <param name="divChar"></param>
        public static void AddItems(ComboBox combobox, String items, String divChar = ";")
        {
            if (String.IsNullOrEmpty(items)) return;
            MyControl.ControlInvoke(combobox, new Action<ComboBox, String, String>((inCombobox, inItems, inDivChar) =>
            {
                try
                {
                    String[] itemList = MyString.SplitEx(inItems, inDivChar, StringSplitOptions.RemoveEmptyEntries);
                    for (Int32 i = 0, j = itemList.Length; i < j; i++)
                        inCombobox.Items.Add(itemList[i]);
                }
                catch (Exception ex)
                {
                    MyLog.MakeLog(ex);
                }
            }), combobox, items, divChar);
        }
    }
}
