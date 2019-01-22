using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCopy.BLL
{
    /// <summary>
    /// 表索引model对象
    /// </summary>
    public class TableIndex
    {
        /// <summary>
        /// 是否唯一索引
        /// </summary>
        public Boolean IsUnique { get; set; }

        /// <summary>
        /// 索引名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 所属的表名
        /// </summary>
        public String TableName { get; set; }

        /// <summary>
        /// 索引所在的列名
        /// </summary>
        public List<String> ColumnNames { get; set; }
    }
}
