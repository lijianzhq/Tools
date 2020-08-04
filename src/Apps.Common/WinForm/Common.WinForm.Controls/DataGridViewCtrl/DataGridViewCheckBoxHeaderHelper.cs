using System;
using System.Windows.Forms;

//DotNetBar
using DevComponents.DotNetBar.Controls;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    public static class DataGridViewCheckBoxHeaderHelper
    {
        /// <summary>
        /// 在gridview列头创建一个CheckBox
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="cellIndex">在哪一列创建复选框</param>
        /// <param name="handler">单击列头的CheckBox的选中状态</param>
        /// <param name="checkstated">起始状态是否选中</param>
        public static void CreateCheckBox(DataGridView grid, 
                                          Int32 cellIndex,
                                          DataGridViewCheckBoxHeaderEventHandler handler = null, 
                                          Boolean checkstated = false)
        {
            DataGridViewCheckboxHeaderCell cell = new DataGridViewCheckboxHeaderCell(grid, cellIndex);
            cell.Checked = checkstated;
            DataGridViewCheckBoxColumn column = grid.Columns[cellIndex] as DataGridViewCheckBoxColumn;
            if (column != null)
            {
                column.HeaderCell = cell;
                column.HeaderCell.Value = String.Empty;
                cell.OnCheckBoxClicked += handler;
                cell.OnCheckBoxClicked += new DataGridViewCheckBoxHeaderEventHandler(cell_OnCheckBoxClicked);
            }
        }

        /// <summary>
        /// 当选中列头的checkbox时，则应用于所有的行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void cell_OnCheckBoxClicked(Object sender, DataGridViewCheckBoxHeaderEventArgs e)
        {
            if (e.DataGridView != null && e.CellIndex >= 0 && e.DataGridView.ColumnCount > e.CellIndex)
            {
                DataGridView gridView = e.DataGridView;
                for (Int32 i = 0, j = gridView.Rows.Count; i < j; i++)
                    gridView.Rows[i].Cells[e.CellIndex].Value = e.CheckedState;
                gridView.EndEdit();
            }
        }
    }
}
