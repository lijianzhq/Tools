using System;
using System.Data.SqlClient;

using Generator;

namespace SqlServer.Generator
{
    public class SqlServer2016Generator : BasicGenerator
    {
        protected SqlConnection _connection;

        public SqlServer2016Generator(String edmxFileFullPath, String dbConnectionString, String outputFileFullPath = "")
            : base(edmxFileFullPath, dbConnectionString, outputFileFullPath)
        {
            OpenConn();
        }

        protected virtual void OpenConn()
        {
            this._connection = new SqlConnection(DBConnectionString);
            this._connection.Open();
        }

        public override string GetTableDocumentation(string tableName)
        {
            using (SqlCommand command = new SqlCommand(@"SELECT [value] 
                                                          FROM fn_listextendedproperty (
                                                                NULL, 
                                                                'schema', 'dbo', 
                                                                'table',  @TableName, 
                                                                NULL, NULL)", this._connection))
            {

                command.Parameters.AddWithValue("TableName", tableName);

                return command.ExecuteScalar() as String;
            }
        }

        public override string GetColumnDocumentation(string tableName, string columnName)
        {
            using (SqlCommand command = new SqlCommand(@"SELECT [value] 
                                                         FROM fn_listextendedproperty (
                                                                NULL, 
                                                                'schema', 'dbo', 
                                                                'table', @TableName, 
                                                                'column', @columnName)", this._connection))
            {

                command.Parameters.AddWithValue("TableName", tableName);
                command.Parameters.AddWithValue("ColumnName", columnName);

                return command.ExecuteScalar() as String;
            }
        }
    }
}
