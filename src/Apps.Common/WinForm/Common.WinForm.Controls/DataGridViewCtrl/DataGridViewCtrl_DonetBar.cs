using System;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;

//自定义命名空间
using DevComponents.DotNetBar.Controls;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    /// <summary>
    /// TableInstance和SelectCommandText两者配置一个属性即可
    /// </summary>
    [ToolboxItem(true)]
    public partial class DataGridViewCtrl_DonetBar : BaseDataGridViewCtrl
    {
        public DataGridViewCtrl_DonetBar()
        {
            InitializeComponent();
            this.OnConfigPageControl += new EventHandler(DataGridViewCtrl_DonetBar_OnConfigPageControl);
            this.toolBarCtrl = ToolBarCtrl;
        }

        #region "父类的事件"

        /// <summary>
        /// 控制分页控件是否可见
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataGridViewCtrl_DonetBar_OnConfigPageControl(object sender, EventArgs e)
        {
            this.pageCtrl_DonetBar1.Visible = this.PageControlVisible;
        }

        #endregion
        
        #region "私有方法"

        /// <summary>
        /// 根据数据库列名创建对应的datagridview列
        /// </summary>
        /// <param name="dbColumnName"></param>
        /// <returns></returns>
        private DataGridViewColumn GetDataGridViewColumn(String dbColumnName)
        {
            if (DataGridViewCtrlColumns == null) return new DataGridViewTextBoxColumn() { HeaderText = dbColumnName, Name = dbColumnName, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            for (Int32 i = 0; i < DataGridViewCtrlColumns.Count; i++)
            {
                if (String.Compare(DataGridViewCtrlColumns[i].DBColumnName, dbColumnName, true) == 0)
                {
                    DataGridViewColumn column = null;
                    switch (DataGridViewCtrlColumns[i].ColumnType)
                    {
                        case ColumnType.DataGridViewButtonColumn:
                            column = new DataGridViewButtonColumn();
                            break;
                        case ColumnType.DataGridViewCheckBoxColumn:
                            column = new DataGridViewCheckBoxColumn();
                            break;
                        case ColumnType.DataGridViewComboBoxColumn:
                            column = new DataGridViewComboBoxColumn();
                            break;
                        case ColumnType.DataGridViewImageColumn:
                            column = new DataGridViewImageColumn();
                            break;
                        case ColumnType.DataGridViewLinkColumn:
                            column = new DataGridViewLinkColumn();
                            break;
                        case ColumnType.DataGridViewTextBoxColumn:
                            column = new DataGridViewTextBoxColumn();
                            break;
                        default:
                            column = new DataGridViewTextBoxColumn();
                            break;
                    }
                    if (column != null)
                    {
                        column.AutoSizeMode = DataGridViewCtrlColumns[i].AutoSizeMode;
                        column.HeaderText = DataGridViewCtrlColumns[i].HeaderText;
                        column.ToolTipText = DataGridViewCtrlColumns[i].ToolTipText;
                        column.Width = DataGridViewCtrlColumns[i].Width;
                        column.Name = dbColumnName;
                        return column;
                    }
                }
            }
            return new DataGridViewTextBoxColumn() { HeaderText = dbColumnName, Name = dbColumnName, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
        }

        #endregion

        #region "重写父类方法"

        protected override void ShowLoadingForm()
        {
            ControlHelper.ControlInvoke(this, new Action(() =>
            {
                //显示进度框
                this.circularProgress1.Show();
            }));
        }

        protected override void CloseLoadingForm()
        {
            ControlHelper.ControlInvoke(this, new Action(() =>
            {
                if (ControlHelper.CanControlInvoke(this.circularProgress1))
                    this.circularProgress1.Hide();
            }));
        }

        protected override void RenderGridView(DataTable data)
        {
            if (data != null)
            {
                this.dataGridViewX1.Rows.Clear();
                this.dataGridViewX1.Columns.Clear();
                if (this.ShowCheckBoxColumn)
                {
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.Width = 50;
                    dataGridViewX1.Columns.Add(checkBoxColumn);
                }

                //创建列
                for (Int32 i = 0; i < data.Columns.Count; i++)
                {
                    String dbColumnName = data.Columns[i].ColumnName;
                    DataGridViewColumn column = GetDataGridViewColumn(dbColumnName);
                    dataGridViewX1.Columns.Add(column);
                }
                Int32 totalRecordCount = data.Rows.Count;
                //创建行
                for (Int32 i = 0; i < totalRecordCount; i++)
                {
                    List<Object> values = new List<Object>();
                    //判断是否显示CheckBox列
                    if (this.ShowCheckBoxColumn) values.Add(false);
                    for (Int32 k = 0; k < data.Columns.Count; k++)
                        values.Add(data.Rows[i][k]);
                    dataGridViewX1.Rows.Add(values.ToArray());
                }
                DataGridViewCheckBoxHeaderHelper.CreateCheckBox(dataGridViewX1, 0);
            }
        }

        protected override Page.PageCP GetPageCP()
        {
            return this.pageCtrl_DonetBar1.PageCP;
        }

        public override DataGridViewSelectedRowCollection GetSelectedRows()
        {
            return dataGridViewX1.SelectedRows;
        }

        protected override ToolBar.IToolBar GetToolBar()
        {
            return this.ToolBarCtrl;
        }

        protected override DataGridView GetDataGridView()
        {
            return this.dataGridViewX1;
        }

        #endregion
    }
}
