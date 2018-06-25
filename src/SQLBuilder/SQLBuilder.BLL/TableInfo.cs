using System;
using System.Collections.Generic;

namespace SQLBuilder.BLL
{
    public class TableInfo
    {
        public String TableName
        { get; set; }

        private List<ColumnInfo> _columns = new List<ColumnInfo>();
        public List<ColumnInfo> Columns
        {
            get { return _columns; }
        }

        /// <summary>
        /// 注释
        /// </summary>
        public String Comments
        {
            get; set;
        }
    }
}
