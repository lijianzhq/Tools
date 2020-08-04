using System;
using System.Collections.Generic;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.ToolBar
{
    public interface IToolBar
    {
        #region "事件"

        /// <summary>
        /// 添加按钮单击事件
        /// </summary>
        event EventHandler Add;

        /// <summary>
        /// 删除按钮单击事件
        /// </summary>
        event EventHandler Delete;

        /// <summary>
        /// 编辑按钮单击事件
        /// </summary>
        event EventHandler Edit;

        /// <summary>
        /// 刷新按钮单击事件
        /// </summary>
        event EventHandler Refresh;

        #endregion

        #region "属性"

        #region "控制按钮文本"

        /// <summary>
        /// 添加按钮文本
        /// </summary>
        String AddBtnText
        {
            get;
            set;
        }

        /// <summary>
        /// 编辑按钮的文本
        /// </summary>
        String EditBtnText
        {
            get;
            set;
        }

        /// <summary>
        /// 删除按钮的文本
        /// </summary>
        String DeleteBtnText
        {
            get;
            set;
        }

        /// <summary>
        /// 刷新按钮的文本
        /// </summary>
        String RefreshBtnText
        {
            get;
            set;
        }

        #endregion

        #region "控制按钮可见性"

        /// <summary>
        /// 是否显示添加按钮（默认都是显示）
        /// </summary>
        Boolean ShowAddBtn
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示删除按钮（默认都是显示）
        /// </summary>
        Boolean ShowDeleteBtn
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示编辑按钮（默认都是显示）
        /// </summary>
        Boolean ShowEditBtn
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示刷新按钮（默认都是显示）
        /// </summary>
        Boolean ShowRefreshBtn
        {
            get;
            set;
        }

        #endregion

        #endregion
    }
}
