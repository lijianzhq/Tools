using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;

namespace DBCopy.BLL
{
    public abstract class BasicDBDDL
    {
        public String ConnectionString
        {
            get; set;
        }

        public abstract DbProviderFactory DbProviderFactory
        {
            get;
        }

        public BasicDBDDL(String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// 获取连接对象
        /// </summary>
        /// <param name="autoOpen"></param>
        /// <returns></returns>
        public virtual DbConnection GetConnection(Boolean autoOpen = false)
        {
            var conn = DbProviderFactory.CreateConnection();
            conn.ConnectionString = ConnectionString;
            if (autoOpen && conn.State != ConnectionState.Open)
                conn.Open();
            return conn;
        }

        /// <summary>
        /// 创建一个命令对象
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual DbCommand CreateCommand(String commandText, DbConnection conn = null, DbTransaction trans = null)
        {
            var cmd = DbProviderFactory.CreateCommand();
            cmd.Connection = conn;
            cmd.Transaction = trans;
            cmd.CommandText = commandText;
            return cmd;
        }

        /// <summary>
        /// 设置表主键列
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colName"></param>
        public virtual void CreateTablePrimaryKey(String tableName, String colName)
        {
            var sql = Get_CreateTablePrimaryKeySql(tableName, colName);
            using (var conn = GetConnection(true))
            {
                var cmd = CreateCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 获取所有table对象
        /// </summary>
        /// <returns></returns>
        public virtual IList<DBTable> GetAllTables()
        {
            var sql = Get_GetAllTablesSql();
            var list = new List<DBTable>();
            using (var conn = GetConnection(true))
            {
                var cmd = CreateCommand(sql, conn);
                var adapter = DbProviderFactory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                var dbset = new DataSet();
                adapter.Fill(dbset);
                if (dbset?.Tables != null && dbset?.Tables.Count > 0)
                {
                    var table = dbset?.Tables[0];
                    var tableNamesList = new List<String>();
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        var row = table.Rows[i];
                        var tableName = Convert.ToString(row["TablE_NAME"]);
                        tableNamesList.Add(tableName);
                    }
                    tableNamesList.AsParallel().ForAll(it =>
                    {
                        list.Add(new DBTable()
                        {
                            TableName = it,
                            Columns = GetTableAllCols(it)
                        });
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// 根据表名获取所有列信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual IList<DBTableCol> GetTableAllCols(String tableName)
        {
            var sql = Get_GetTableAllColsSql(tableName);
            if (String.IsNullOrEmpty(sql)) return null;
            var list = new List<DBTableCol>();
            using (var conn = GetConnection(true))
            {
                var cmd = CreateCommand(sql, conn);
                var adapter = DbProviderFactory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                var dbset = new DataSet();
                adapter.Fill(dbset);
                if (dbset?.Tables != null && dbset?.Tables.Count > 0)
                {
                    var table = dbset?.Tables[0];
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        var row = table.Rows[i];
                        var colName = Convert.ToString(row["column_name"]);
                        var isPrimaryKey = Convert.ToString(row["IsPrimaryKey"]) == "1";
                        list.Add(new DBTableCol()
                        {
                            Name = colName,
                            IsPrimaryKey = isPrimaryKey,
                        });
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取表的主键列
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual IList<String> GetTablePrimaryKeys(String tableName)
        {
            var sql = Get_GetTablePrimaryKeysSql(tableName);
            var list = new List<String>();
            using (var conn = GetConnection(true))
            {
                var cmd = CreateCommand(sql, conn);
                var adapter = DbProviderFactory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                var dbset = new DataSet();
                adapter.Fill(dbset);
                if (dbset?.Tables != null && dbset?.Tables.Count > 0)
                {
                    var table = dbset?.Tables[0];
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        var row = table.Rows[i];
                        var colName = Convert.ToString(row["column_name"]);
                        list.Add(colName);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取数据表索引
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual List<TableIndex> GetTableIndices(String tableName)
        {
            var sql = Get_GetTableIndexSql(tableName);
            var tbIndexList = new List<TableIndex>();
            var tbIndexListTemp = new List<TableIndex>();
            using (var conn = GetConnection(true))
            {
                var cmd = CreateCommand(sql, conn);
                var adapter = DbProviderFactory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                var dbset = new DataSet();
                adapter.Fill(dbset);
                if (dbset?.Tables != null && dbset?.Tables.Count > 0)
                {
                    var table = dbset?.Tables[0];
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        var row = table.Rows[i];
                        var indexName = Convert.ToString(row["indexname"]);
                        var tablename = Convert.ToString(row["tablename"]);
                        var indexcolumn = Convert.ToString(row["indexcolumn"]);
                        var indid = Convert.ToString(row["indid"]);
                        tbIndexListTemp.Add(new TableIndex()
                        {
                            ColumnNames = new List<string>() { indexcolumn },
                            IsUnique = true,
                            Name = indexName,
                            TableName = tablename,
                        });
                    }
                }
            }
            var groups = tbIndexListTemp.GroupBy(it => it.Name, it => it);
            foreach (var g in groups)
            {
                tbIndexList.Add(new TableIndex()
                {
                    IsUnique = true,
                    Name = g.Key,
                    TableName = g.FirstOrDefault()?.TableName,
                    ColumnNames = g.Select(it => it.ColumnNames[0]).ToList()
                });
            }
            return tbIndexList;
        }

        /// <summary>
        /// 创建表索引
        /// </summary>
        /// <param name="tbIndex"></param>
        /// <returns></returns>
        public virtual void CreateTableIndex(TableIndex tbIndex)
        {
            var sql = Get_CreateTableIndexSql(tbIndex);
            using (var conn = GetConnection(true))
            {
                var cmd = CreateCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 删除重复数据
        /// </summary>
        public virtual Int32 DeleteDuplication(TableIndex tableIndex)
        {
            //delete PS_RESOURCE t1
            //where id in (
            //select min(id) from PS_RESOURCE t2
            //group by PLANT_CODE,RESOURCE_CODE
            //  having(count(*)) > 1
            //);
            if (tableIndex == null || tableIndex.ColumnNames == null || tableIndex.ColumnNames.Count == 0) return 0;
            var conditions = String.Join(",", tableIndex.ColumnNames.Select(it => it));
            var sql = String.Format(@"delete {0} t1
                                      where id in (
                                      select min(id) from {0} t2
                                      group by {1}
                                        having(count(*)) > 1
                                      )", tableIndex.TableName, conditions);
            using (var conn = GetConnection(true))
            {
                var cmd = CreateCommand(sql, conn);
                return cmd.ExecuteNonQuery();
            }
        }

        #region "sql相关"

        /// <summary>
        /// 获取所有表的sql
        /// </summary>
        /// <returns></returns>
        public abstract String Get_GetAllTablesSql();

        /// <summary>
        /// 获取表主键的sql
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public abstract String Get_GetTablePrimaryKeysSql(String tableName);

        /// <summary>
        /// 获取数据库表索引
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public abstract String Get_GetTableIndexSql(String tableName);

        /// <summary>
        /// 创建表索引
        /// </summary>
        /// <param name="tbIndex"></param>
        /// <returns></returns>
        public abstract String Get_CreateTableIndexSql(TableIndex tbIndex);

        /// <summary>
        /// 设置表主键的sql
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        public abstract String Get_CreateTablePrimaryKeySql(String tableName, String colName);

        /// <summary>
        /// 获取表的所有列的sql
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public abstract String Get_GetTableAllColsSql(String tableName);

        #endregion
    }
}
