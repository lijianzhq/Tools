using System;
using System.Windows.Forms;

//自定义命名空间
using DreamCube.Foundation.Basic.Utility;

namespace DreamCube.Apps.Common.WinForm.Controls
{
    /// <summary>
    /// 封装一些datagridview常用的方法
    /// </summary>
    public static class MyDataGridView
    {
        /// <summary>
        /// 判断datagridview
        /// </summary>
        /// <param name="grid">需要查找的目标datagridview</param>
        /// <param name="cellIndex">需要查找的列序号</param>
        /// <param name="value">需要查找的值</param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static Boolean Contains(DataGridView grid, Int32[] cellIndex, String value, StringComparison stringComparison)
        {
            if (grid == null || grid.Rows.Count == 0) return false;
            if (String.IsNullOrEmpty(value)) return false;
            Int32 rowCount = grid.Rows.Count;
            Int32 cellCount = grid.ColumnCount;
            for (Int32 i = 0; i < rowCount; i++)
            {
                for (Int32 j = 0; j < cellIndex.Length; j++)
                {
                    if (cellIndex[j] >= 0 && cellIndex[j] < cellCount)
                    {
                        if (String.Compare(MyObject.ToStringEx(grid.Rows[i].Cells[cellIndex[j]].Value), value, stringComparison) == 0)
                            return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 移动datagridview的行
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="rowIndex">要移动的行序号</param>
        /// <param name="targetIndex">移动到的目标行序号</param>
        /// <returns></returns>
        public static void MoveRow(DataGridView grid, Int32 rowIndex, Int32 targetIndex)
        {
            if (grid == null || rowIndex < 0 || grid.Rows.Count <= rowIndex || targetIndex < 0 || grid.Rows.Count <= targetIndex) return;
            Int32 index = grid.Rows.Add();
            for (Int32 i = 0; i < grid.ColumnCount; i++)
            {
                Object tempValue = grid.Rows[rowIndex].Cells[i].Value;
                grid.Rows[rowIndex].Cells[i].Value = grid.Rows[targetIndex].Cells[i].Value;
                grid.Rows[targetIndex].Cells[i].Value = tempValue;
            }
        }
    }
}
