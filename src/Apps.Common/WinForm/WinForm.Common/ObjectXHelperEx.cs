using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

using DreamCube.Foundation.Serialization;
using DreamCube.Foundation.Basic.Utility;
using DreamCube.Framework.Utilities.BasicObject;

namespace DreamCube.WinForm.Common
{
    /// <summary>
    /// ObjectX的辅助类
    /// </summary>
    public static class ObjectXHelperEx
    {
        /// <summary>
        /// 根据存储对象JSON数据文件直接读取数据写入到form上面（配置的时候常用）
        /// </summary>
        /// <param name="json">json数据</param>
        /// <param name="form">目标的form</param>
        public static void WriteObjToFormByJSON(String json, Form form)
        {
            ObjectX obj = ObjectXHelper.CreateObjFromJSON(json);
            WriteObjToForm(obj, form);
        }

        /// <summary>
        /// 根据存储对象JSON数据文件直接读取数据写入到form上面（配置的时候常用）
        /// </summary>
        /// <param name="filePath">存储ObjectX对象的json数据的文件路径</param>
        /// <param name="form"></param>
        public static void WriteObjToFormByJSONFile(String filePath, Form form)
        {
            ObjectX obj = ObjectXHelper.CreateObjFromJSONFile(filePath);
            WriteObjToForm(obj, form);
        }

        /// <summary>
        /// 把对象数据写到Form上面
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="form">目标Form</param>
        public static void WriteObjToForm(ObjectX obj, Form form)
        {
            if (obj == null || obj.ItemCount == 0) return;
            List<Control> controls = MyControl.GetAllChildControls(form);
            for (Int32 i = 0, j = controls.Count; i < j; i++)
            {
                //TextBox
                TextBox tb = controls[i] as TextBox;
                if (tb != null)
                {
                    tb.Text = obj.GetItemValue<String>(tb.Name, "");
                    continue;
                }
                //ComboBox
                ComboBox cb = controls[i] as ComboBox;
                if (cb != null)
                {
                    Model.ComboBoxModel model = null;
                    MyJson.TryDeserialize<Model.ComboBoxModel>(obj.GetItemValue<String>(cb.Name, ""), out model);
                    if (model != null) model.SetComboBox(cb);
                    continue;
                }
                //RadioButton
                RadioButton radioBtn = controls[i] as RadioButton;
                if (radioBtn != null)
                {
                    radioBtn.Checked = obj.GetItemValue<Boolean>(radioBtn.Name);
                    continue;
                }
                //checkbox
                CheckBox chk = controls[i] as CheckBox;
                if (chk != null)
                {
                    chk.Checked = obj.GetItemValue<Boolean>(chk.Name);
                    continue;
                }
            }
        }

        /// <summary>
        /// 从文本文件中获取json数据创建一个对象
        /// </summary>
        /// <param name="form">Form窗体对象</param>
        /// <returns></returns>
        public static ObjectX CreateObjFromForm(Form form)
        {
            ObjectX obj = ObjectXHelper.CreateEmptyObj();
            List<Control> controls = MyControl.GetAllChildControls(form);
            for (Int32 i = 0, j = controls.Count; i < j; i++)
            {
                //TextBox
                TextBox tb = controls[i] as TextBox;
                if (tb != null)
                {
                    obj.SetItemValue(tb.Name, tb.Text);
                    continue;
                }
              
                //ComboBox
                ComboBox cb = controls[i] as ComboBox;
                if (cb != null)
                {
                    obj.SetItemValue(cb.Name, MyJson.Serialize(new Model.ComboBoxModel(cb)));
                    continue;
                }
                //RadioButton
                RadioButton radioBtn = controls[i] as RadioButton;
                if (radioBtn != null)
                {
                    obj.SetItemValue(radioBtn.Name, radioBtn.Checked);
                    continue;
                }
                //checkbox
                CheckBox chk = controls[i] as CheckBox;
                if (chk != null)
                {
                    obj.SetItemValue(chk.Name, chk.Checked);
                    continue;
                }
            }
            return obj;
        }
    }
}
