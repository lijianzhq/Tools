using System;
using System.Collections.Generic;
using System.Windows.Forms;

//自定义命名空间
using DreamCube.Foundation.Basic.Utility;
using DreamCube.Foundation.Basic.Objects;

namespace DreamCube.Apps.Common.WinForm.Controls
{
    public static class ComboBoxHelper
    {
        /// <summary>
        /// 对应EnumItem类的三个属性
        /// </summary>
        public enum EnumItemProperty
        {
            Description,
            EnumValue,
            IdentityValue
        }

        /// <summary>
        /// 绑定枚举值到ComboBox上面
        /// 可以自定义显示字段和值字段，默认是显示字段为：Description；值字段是：EnumValue
        /// </summary>
        /// <param name="targetCtrl"></param>
        /// <param name="enumType"></param>
        public static void BindEnum<T>(ComboBox targetCtrl, EnumItemProperty? dislayMember = null, EnumItemProperty? valueMember = null)
            where T : struct
        {
            //List<EnumItem<T>> enumItems = MyEnum.GetEnumItems<T>();
            //targetCtrl.DataSource = enumItems;
            //targetCtrl.DisplayMember = dislayMember == null ? "Description" : dislayMember.Value.ToString();
            //targetCtrl.ValueMember = valueMember == null ? "EnumValue" : valueMember.Value.ToString();
        }
    }
}
