using System;
using System.Windows.Forms;

namespace DreamCube.WinForm.Common.Model
{
    /// <summary>
    /// ComboBox的数据模型对象
    /// </summary>
    class ComboBoxModel
    {
        public Object SelectedItem;
        public String SelectedText;
        public Int32 SelectedIndex;
        public Object SelectedValue;
        public String Text;

        public ComboBoxModel(ComboBox combobox)
        {
            this.SelectedItem = combobox.SelectedItem;
            this.SelectedText = combobox.SelectedText;
            this.SelectedValue = combobox.SelectedValue;
            this.SelectedIndex = combobox.SelectedIndex;
            this.Text = combobox.Text;
        }

        /// <summary>
        /// 把值设置到对应的combobox上面
        /// </summary>
        /// <param name="combobox"></param>
        public void SetComboBox(ComboBox combobox)
        {
            combobox.SelectedItem = this.SelectedItem;
            combobox.SelectedText = this.SelectedText;
            combobox.SelectedValue = this.SelectedValue;
            combobox.SelectedIndex = this.SelectedIndex;
            combobox.Text = this.Text;
        }
    }
}
