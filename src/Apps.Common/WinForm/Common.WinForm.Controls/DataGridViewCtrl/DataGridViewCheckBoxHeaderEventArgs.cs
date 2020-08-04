using System;
using System.Windows.Forms;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    #region "委托"

    public delegate void DataGridViewCheckBoxHeaderEventHandler(Object sender, DataGridViewCheckBoxHeaderEventArgs e);

    #endregion

    /// <summary>
    /// 定义包含列头checkbox选择状态的事件参数类
    /// </summary>
    public class DataGridViewCheckBoxHeaderEventArgs : EventArgs
    {
        #region "字段"

        private Boolean checkedState = false;

        #endregion

        #region "属性"

        public Boolean CheckedState
        {
            get { return checkedState; }
            set { checkedState = value; }
        }

        /// <summary>
        /// 触发此事件的datagridview对象
        /// </summary>
        public DataGridView DataGridView
        {
            get;
            set;
        }

        /// <summary>
        /// 返回触发此事件的列序号
        /// </summary>
        public Int32 CellIndex
        {
            get;
            set;
        }

        #endregion
    }
}
