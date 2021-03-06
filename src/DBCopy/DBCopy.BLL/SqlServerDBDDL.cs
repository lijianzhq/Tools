﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace DBCopy.BLL
{
    public class SqlServerDBDDL : BasicDBDDL
    {
        public override DbProviderFactory DbProviderFactory => SqlClientFactory.Instance;

        public SqlServerDBDDL(String connectionString) : base(connectionString) { }

        public override string Get_GetAllTablesSql()
        {
            return "select name AS TablE_NAME from sys.objects where type='U'";
        }

        public override string Get_GetTablePrimaryKeysSql(string tableName)
        {
            throw new NotImplementedException();
        }

        public override String Get_GetTableIndexSql(string tableName)
        {
            // sysindexes.status = 2 唯一索引，sysindexes.status = 0，非唯一索引，sysindexes.status = 2066，聚集索引
            return String.Format(@"SELECT  indexname = a.name , tablename = c. name , indexcolumn = d.name , a .indid
                                    FROM sysindexes a
                                         JOIN sysindexkeys b ON a .id = b.id  AND a .indid = b.indid
                                            JOIN sysobjects c ON b.id = c.id
                                            JOIN syscolumns d ON b.id = d.id  AND b .colid = d.colid
                                    WHERE a .indid NOT IN(0, 255)
                                    -- and c.xtype = 'U'   and c.status > 0-- 查所有用户表
                                    AND c.name = '{0}' AND a.status = 2--查指定表
                                    ORDER BY c. name ,
                                            a.name ,
                                            d.name", tableName);
        }

        public override string Get_CreateTablePrimaryKeySql(string tableName, string colName)
        {
            throw new NotImplementedException();
        }

        public override string Get_GetTableAllColsSql(string tableName)
        {
            return $@"SELECT
                        column_name = a.name,
                        IsPrimaryKey = case when exists(SELECT 1 FROM sysobjects where xtype = 'PK' and parent_obj = a.id and name in (
                                   SELECT name FROM sysindexes WHERE indid in(SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid))) then '1' else '0' end
                    FROM
                        syscolumns a
                    left join systypes b on a.xusertype = b.xusertype
                    inner join sysobjects d on a.id = d.id  and d.xtype = 'U' and d.name <> 'dtproperties'
                    left join syscomments e on a.cdefault = e.id
                    left join sys.extended_properties g on a.id = G.major_id and a.colid = g.minor_id
                    left join sys.extended_properties f on d.id = f.major_id and f.minor_id = 0
                    where d.name = '{tableName}'
                    order by a.id,a.colorder";
        }

        public override string Get_CreateTableIndexSql(TableIndex tbIndex)
        {
            var cols = String.Join(",", tbIndex.ColumnNames);
            return $"CREATE UNIQUE INDEX {tbIndex.Name} ON {tbIndex.TableName} ({cols})";
        }
    }
}
