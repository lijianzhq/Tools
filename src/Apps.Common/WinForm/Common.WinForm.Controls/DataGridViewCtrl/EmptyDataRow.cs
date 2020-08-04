using System;
using System.Drawing;
using System.Windows.Forms;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    /// <summary>
    /// DataGridView的空数据行
    /// </summary>
    public class EmptyDataRow : DataGridViewRow
    {
        /// <summary>
        /// 空数据行时显示的文本
        /// </summary>
        public String EmptyText
        {
            get;
            set;
        }

        public EmptyDataRow() :
            this(null)
        { }

        public EmptyDataRow(String emptyText)
        {
            this.EmptyText = String.IsNullOrEmpty(emptyText) ? "没有可显示的记录" : emptyText;
        }

        protected override void Paint(System.Drawing.Graphics graphics,
                                      System.Drawing.Rectangle clipBounds,
                                      System.Drawing.Rectangle rowBounds,
                                      int rowIndex,
                                      DataGridViewElementStates rowState,
                                      bool isFirstDisplayedRow,
                                      bool isLastVisibleRow)
        {
            base.Paint(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow);
            var grid = this.DataGridView;
            Int32 rowHeadersWidth = grid.RowHeadersVisible ? grid.RowHeadersWidth : 0;
            Brush brush = SystemBrushes.Control;
            graphics.FillRectangle(brush, rowBounds);
            graphics.DrawString(this.EmptyText, grid.Font, Brushes.Black, grid.Width / 2 - (this.EmptyText.Length) * 4, rowBounds.Bottom - 18);
        }
    }
}
