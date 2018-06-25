using System;

namespace SQLBuilder.BLL
{
    public class ColumnInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public Int32 Index
        {
            get; set;
        }

        /// <summary>
        /// 列名
        /// </summary>
        public String ColumnName
        {
            get; set;
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        public String DataType
        {
            get; set;
        }

        /// <summary>
        /// 约束
        /// </summary>
        public String Constraint
        {
            get; set;
        }

        /// <summary>
        /// 注释
        /// </summary>
        public String Comments
        {
            get;set;
        }
    }
}
