using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using DBCopy.BLL;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Concurrent;
using System.Threading;
using System.Data.SqlClient;

namespace DBCopy.Win
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_startCopy_Click(object sender, EventArgs e)
        {
            btn_startCopy.Enabled = false;
            var sourceDBType = comb_souceDBType.Text;
            var sourceDBConnectionStr = txt_sourceDBConnStr.Text;
            var targetDBType = comb_targetDBType.Text;
            var targetDBConnectionStr = txt_targetDBConnStr.Text;
            var sourceDB = BLL.DBFactory.CreateDB(sourceDBType, sourceDBConnectionStr);
            var targetDB = BLL.DBFactory.CreateDB(targetDBType, targetDBConnectionStr);

            Task.Factory.StartNew(new Action(() =>
            {
                ShowLogMsg("开始同步数据库...");
                CopyUniqueIndex(sourceDB, targetDB);
            })).ContinueWith(new Action<Task>((tsk) =>
            {
                this.Invoke(new Action(() =>
                {
                    ShowLogMsg("已经完成同步完成");
                    btn_startCopy.Enabled = true;
                }));
            }));
        }

        /// <summary>
        /// 复制唯一索引
        /// </summary>
        /// <param name="sourceDB"></param>
        /// <param name="targetDB"></param>
        private void CopyUniqueIndex(BLL.BasicDBDDL sourceDB, BLL.BasicDBDDL targetDB)
        {
            var tables = sourceDB.GetAllTables();
            //var tables = new List<DBTable>() { new DBTable() { TableName = "PS_CALENDAR_RESOURCE_SHIFTS" } };
            this.Invoke(new Action(() =>
            {
                ShowLogMsg($"从源数据库成功获取到[{tables.Count()}]表");
            }));
            tables?.ToList().ForEach(it =>
            {
                var tbList = sourceDB.GetTableIndices(it.TableName);
                tbList.ForEach(index =>
                {
                    var cols = String.Join(",", index.ColumnNames);
                    try
                    {
                        try
                        {
                            targetDB.CreateTableIndex(index);
                            ShowLogMsg($"同步[{index.Name}]成功");
                            //ShowLogMsg(targetDB.Get_CreateTableIndexSql(index) + ";");
                        }
                        catch (Exception ex)
                        {
                            var oraEx = ex as OracleException;
                            var sqlEx = ex as SqlException;
                            if (oraEx?.Number == 1452 || sqlEx.Number ==  1505)
                            {
                                //数据重复了，执行删除重复数据逻辑
                                //执行删除重复数据
                                ShowConflictLogMsg($"同步[{index.Name}]失败，数据重复。错误：[{ex.Message}]");
                                var rowCount = targetDB.DeleteDuplication(index);
                                ShowConflictLogMsg($"删除重复数据[{rowCount}]条");
                                targetDB.CreateTableIndex(index);
                                ShowConflictLogMsg($"【重复】同步[{index.Name}]成功");
                            }
                            else
                            {
                                ShowLogMsg($"同步[{index.Name}],[{cols}]失败，错误：[{ex.Message}]");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowLogMsg($"【重复】同步[{index.Name}],[{cols}]失败，错误：[{ex.Message}]");
                    }
                });
            });
        }

        private void ShowLogMsg(String msg)
        {
            this.Invoke(new Action(() =>
            {
                txt_Log.Text += msg + Environment.NewLine;
            }));
        }

        private void ShowConflictLogMsg(String msg)
        {
            this.Invoke(new Action(() =>
            {
                txt_Conflict_Log.Text += msg + Environment.NewLine;
            }));
        }

        private void btn_setTableKey_Click(object sender, EventArgs e)
        {
            var connectionString = txt_connectionStr.Text;
            var primaryKeyName = txt_ID.Text;
            btn_setTableKey.Enabled = false;

            Int64 totalDoCount = 0;//总处理数
            var successTables = new ConcurrentBag<String>();
            var hasKeysTables = new ConcurrentBag<String>();
            Task.Factory.StartNew(new Action(() =>
            {
                ShowLogMsg($"start...");
                var db = new BLL.OracleDBDDL(connectionString);
                var tables = db.GetAllTables();
                var count = tables.Count;
                ShowLogMsg($"table count:[{count}]");
                //并行处理所有表即可
                tables?.AsParallel().ForAll(it =>
                {
                    var tableName = it.TableName;
                    try
                    {
                        var tablePrimarykeys = db.GetTablePrimaryKeys(it.TableName);
                        //判断表是否已经有主键了
                        if (tablePrimarykeys == null || tablePrimarykeys.Count == 0)
                        {
                            var allColumns = db.GetTableAllCols(it.TableName);
                            //判断指定的主键列是否存在
                            if (allColumns.Where(col => String.Equals(col.Name, primaryKeyName, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault() != null)
                            {
                                db.CreateTablePrimaryKey(it.TableName, primaryKeyName);
                                successTables.Add(it.TableName);
                            }
                        }
                        else
                        {
                            hasKeysTables.Add(it.TableName);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowLogMsg($"when do with table[{tableName}],an error occur,message:{ex?.Message}");
                    }
                    finally
                    {
                        Interlocked.Increment(ref totalDoCount);
                        if (Interlocked.Read(ref totalDoCount) == count)
                        {
                            ShowLogMsg($"已处理完成，总表数：[{count}],已经有主键的表数：[{hasKeysTables.Count()}],成功新建主键表数：[{successTables.Count()}]");
                        }
                    }
                });
            }));
        }
    }
}
