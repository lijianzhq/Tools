using System;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

//自定义命名空间
using DreamCube.Framework.DataAccess.Basic;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    /// <summary>
    /// TableInstance和SelectCommandText两者配置一个属性即可
    /// </summary>
    [ToolboxItem(true)]
    public partial class DataGridViewCtrl_WinForm : BaseDataGridViewCtrl
    {
        #region "构造方法"

        public DataGridViewCtrl_WinForm()
        {
            InitializeComponent();
            this.OnConfigPageControl += new EventHandler(DataGridViewCtrl_WinForm_OnConfigPageControl);
        }

        /// <summary>
        /// 控制分页控件是否可见
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataGridViewCtrl_WinForm_OnConfigPageControl(Object sender, EventArgs e)
        {
            this.pageCtrl1.Visible = this.PageControlVisible;
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
            return new DataGridViewTextBoxColumn() { HeaderText = dbColumnName, Name=dbColumnName, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
        }

        #endregion

        #region "重写父类方法"

        protected override void ShowLoadingForm()
        {
            ControlHelper.ControlInvoke(this, new Action(() =>
            {
                //显示进度框
                loadingForm = new LoadingForm();
                ((LoadingForm)loadingForm).ShowDialog(this.dataGridView1);
            }));
        }

        protected override void CloseLoadingForm()
        {
            ControlHelper.ControlInvoke(this, new Action(() =>
            {
                if (ControlHelper.CanControlInvoke(loadingForm))
                    ((LoadingForm)loadingForm).Close();
            }));
        }

        protected override void RenderGridView(DataTable data)
        {
            if (data != null)
            {
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.Columns.Clear();
                if (this.ShowCheckBoxColumn)
                {
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.Width = 50;
                    dataGridView1.Columns.Add(checkBoxColumn);
                }

                //创建列
                for (Int32 i = 0; i < data.Columns.Count; i++)
                {
                    String dbColumnName = data.Columns[i].ColumnName;
                    DataGridViewColumn column = GetDataGridViewColumn(dbColumnName);
                    dataGridView1.Columns.Add(column);
                }
                Int32 totalRecordCount = data.Rows.Count;
                //创建行
                for (Int32 i = 0; i < totalRecordCount; i++)
                {
                    List<Object> values = new List<Object>();
                    //判断是否显示CheckBox列
                    if (this.ShowCheckBoxColumn) values.Add(false);
                    for (Int32 k = 0; k < data.Columns.Count; k++)
                        values.Add(FireFormatDataEvent(null,
                                new FormatDataEventArgs() { OriginalValue = data.Rows[i][k], ColumnIndex = k, RowIndex = i }));
                    dataGridView1.Rows.Add(values.ToArray());
                }
                DataGridViewCheckBoxHeaderHelper.CreateCheckBox(dataGridView1, 0);
            }
        }

        protected override Page.PageCP GetPageCP()
        {
            return this.pageCtrl1.PageCP;
        }

        public override DataGridViewSelectedRowCollection GetSelectedRows()
        {
            return dataGridView1.SelectedRows;
        }

        protected override DataGridView GetDataGridView()
        {
            return this.dataGridView1;
        }

        protected override ToolBar.IToolBar GetToolBar()
        {
            return this.ToolBarCtrl;
        }

        #endregion
    }
}
