using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCopy.BLL
{
    /// <summary>
    /// 表model
    /// </summary>
    public class DBTable
    {
        public String TableName { get; set; }

        public IList<DBTableCol> Columns { get; set; }
    }
}
