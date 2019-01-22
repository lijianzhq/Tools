using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCopy.BLL
{
    public static class DBFactory
    {
        public static BasicDBDDL CreateDB(String type, String connectionStr)
        {
            if (type == "sqlserver") return new SqlServerDBDDL(connectionStr);
            else if (type == "oracle") return new OracleDBDDL(connectionStr);
            throw new Exception($"does not support dbtype[{type}]");
        }
    }
}
