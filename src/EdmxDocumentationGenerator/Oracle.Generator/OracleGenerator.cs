using System;
using System.Data.OracleClient;

using Generator;

namespace Oracle.Generator
{
    public class OracleGenerator : BasicGenerator
    {
        protected OracleConnection _connection;

        public OracleGenerator(String edmxFileFullPath, String dbConnectionString, String outputFileFullPath = "")
            : base(edmxFileFullPath, dbConnectionString, outputFileFullPath)
        {
            OpenConn();
        }

        protected virtual void OpenConn()
        {
            this._connection = new OracleConnection(DBConnectionString);
            this._connection.Open();
        }

        protected override string GetTableDocumentation(string tableName)
        {
            String sql = "select comments from user_tab_comments where table_name = :TABLENAME";
            using (OracleCommand command = new OracleCommand(sql, this._connection))
            {
                command.Parameters.AddWithValue("TABLENAME", tableName);
                return command.ExecuteScalar() as String;
            }
        }

        protected override string GetColumnDocumentation(string tableName, string columnName)
        {
            String sql = "select comments from user_col_comments where table_name = :TABLENAME and column_name = :COLUMNNAME";
            using (OracleCommand command = new OracleCommand(sql, this._connection))
            {
                command.Parameters.AddWithValue("TABLENAME", tableName);
                command.Parameters.AddWithValue("COLUMNNAME", columnName);
                return command.ExecuteScalar() as String;
            }
        }
    }
}
