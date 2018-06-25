using System;
using System.Data;
using System.Text;

using Mini.Foundation.Office;

namespace SQLBuilder.BLL
{
    public class SqlServerSqlBuilderService : ISqlBuilderService
    {
        private CellIndex _tableNameCellIndex = new CellIndex(0, 2);
        protected CellIndex TableNameCellIndex
        {
            get { return _tableNameCellIndex; }
        }

        /// <summary>
        /// 根据excel文件路径执行生成操作，并返回生成的sql
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <returns></returns>
        public virtual String Build(String excelFilePath)
        {
            var excelHelper = new ExcelToDataTable();
            excelHelper.Init(excelFilePath);
            using (var ds = excelHelper.GetDataTables())
            {
                var sb = new StringBuilder();
                for (var i = 0; i < ds.Tables.Count; i++)
                {
                    sb.Append(BuildOne(ds.Tables[i]));
                }
                return sb.ToString();
            }
        }

        protected virtual String BuildOne(DataTable table)
        {
            if (!IsTableDataValidated(table)) return String.Empty;
            var tableInfo = ResolveTableInfo(table);
            return BuildCreateScript(tableInfo);
        }

        protected virtual String BuildCreateScript(TableInfo tableInfo)
        {
            //{0}表名,{1}列信息,{2}注释
            String tbTemplate = @"CREATE TABLE {0}(
                                    {1}
                                  ){2};";

            var itemSB = new StringBuilder();
            var commentsSB = new StringBuilder();
            commentsSB.AppendLine();
            for (var i = 0; i < tableInfo.Columns.Count; i++)
            {
                var c = tableInfo.Columns[i];
                itemSB.AppendFormat("{0} {1} {2} {3} {4}", c.ColumnName, c.DataType, c.Constraint);
                commentsSB.AppendFormat("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{0}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{1}', @level2type=N'COLUMN',@level2name=N'{2}'", c.Comments, tableInfo.TableName, c.ColumnName);
                if (i != tableInfo.Columns.Count - 1)
                {
                    itemSB.Append(",");
                    itemSB.AppendLine();

                    commentsSB.Append(",");
                    commentsSB.AppendLine();
                }
            }
            commentsSB.AppendFormat("EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{0}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{1}'", tableInfo.Comments, tableInfo.TableName);
            return String.Format(tbTemplate, tableInfo.TableName, commentsSB.ToString(), itemSB.ToString());
        }

        protected virtual TableInfo ResolveTableInfo(DataTable table)
        {
            var tableInfo = new TableInfo()
            {
                TableName = Convert.ToString(table.Rows[TableNameCellIndex.X][TableNameCellIndex.Y])
            };
            for (var i = 3; i < table.Rows.Count; i++)
            {
                tableInfo.Columns.Add(new ColumnInfo()
                {
                    Index = Convert.ToInt32(table.Rows[i][0]),
                    ColumnName = Convert.ToString(table.Rows[i][1]),
                    DataType = Convert.ToString(table.Rows[i][2]),
                    Constraint = Convert.ToString(table.Rows[i][3]),
                    Comments = Convert.ToString(table.Rows[i][34]),
                });
            }
            return tableInfo;
        }

        protected virtual Boolean IsTableDataValidated(DataTable table)
        {
            if (table == null) return false;
            //校验
            if (table.Rows.Count <= 5 || table.Columns.Count <= 3) return false;
            return true;
        }
    }
}
