using System;
using System.Drawing;
using System.Windows.Forms;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    /// <summary>
    /// 显示Checkbox的dataGridView列头
    /// </summary>
    public class DataGridViewCheckboxHeaderCell : DataGridViewColumnHeaderCell
    {
        #region "事件"

        public event DataGridViewCheckBoxHeaderEventHandler OnCheckBoxClicked;

        #endregion

        #region "字段"

        /// <summary>
        /// 单元格的序号
        /// </summary>
        Int32 cellIndex;

        /// <summary>
        /// 所属的datagridview对象
        /// </summary>
        DataGridView datagrid;

        /// <summary>
        /// checkbox显示的位置
        /// </summary>
        Point checkBoxLocation;

        /// <summary>
        /// checkbox显示的大小
        /// </summary>
        Size checkBoxSize;

        /// <summary>
        /// 标志是否选中
        /// </summary>
        Boolean isChecked = false;

        /// <summary>
        /// 单元格的位置
        /// </summary>
        Point cellLocation = new Point();

        System.Windows.Forms.VisualStyles.CheckBoxState cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;

        #endregion

        #region "属性"

        /// <summary>
        /// 表示是否选中
        /// </summary>
        public Boolean Checked
        {
            get { return this.isChecked; }
            set { this.isChecked = value; }
        }

        #endregion

        #region "构造方法"

        public DataGridViewCheckboxHeaderCell(DataGridView grid, Int32 cellIndex)
            : base()
        {
            this.datagrid = grid;
            this.cellIndex = cellIndex;
        }

        #endregion

        #region "重新基类方法"

        protected override void Paint(Graphics graphics,
                                        Rectangle clipBounds,
                                        Rectangle cellBounds,
                                        Int32 rowIndex,
                                        DataGridViewElementStates dataGridViewElementState,
                                        Object value,
                                        Object formattedValue,
                                        String errorText,
                                        DataGridViewCellStyle cellStyle,
                                        DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                        DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics, System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            //计算居中位置
            p.X = cellBounds.Location.X + (cellBounds.Width / 2) - (s.Width / 2) - 1;//列头checkbox的X坐标
            p.Y = cellBounds.Location.Y + (cellBounds.Height / 2) - (s.Height / 2);//列头checkbox的Y坐标
            cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (isChecked)
                cbState = System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal;
            else
                cbState = System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox(graphics, checkBoxLocation, cbState);
        }

        /// <summary>
        /// 点击列头checkbox单击事件
        /// </summary>
        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + cellLocation.X, e.Y + cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
                checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
                checkBoxLocation.Y + checkBoxSize.Height)
            {
                isChecked = !isChecked;
                //获取列头checkbox的选择状态
                DataGridViewCheckBoxHeaderEventArgs args = new DataGridViewCheckBoxHeaderEventArgs();
                args.CheckedState = isChecked;
                args.DataGridView = this.datagrid;
                args.CellIndex = this.cellIndex;

                Object sender = new Object();//此处不代表选择的列头checkbox，只是作为参数传递。应该列头checkbox是绘制出来的，无法获得它的实例
                if (OnCheckBoxClicked != null)
                {
                    //触发单击事件
                    OnCheckBoxClicked(sender, args);
                    this.DataGridView.InvalidateCell(this);
                }
            }
            base.OnMouseClick(e);
        }

        #endregion
    }
}
