using System;
using System.Net;

//DonetBar
using DevComponents.Editors;

namespace DreamCube.Apps.Common.WinForm.Controls
{
    public partial class IpAddressInput : DevComponents.Editors.IpAddressInput
    {
        public IpAddressInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定事件
        /// </summary>
        private void BindEvent()
        {
            this.ConvertFreeTextEntry += new FreeTextEntryConversionEventHandler(IpAddressInput_ConvertFreeTextEntry);
        }

        /// <summary>
        /// 自定义验证IP输入是否合法比空间自带的验证快很多
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void IpAddressInput_ConvertFreeTextEntry(object sender, FreeTextEntryConversionEventArgs e)
        {
            DevComponents.Editors.IpAddressInput source = sender as IpAddressInput;
            IPAddress address = null;
            if (IPAddress.TryParse(e.ValueEntered, out address))
            {
                e.ControlValue = e.ValueEntered;
                e.IsValueConverted = true;
            }
        }
    }
}
