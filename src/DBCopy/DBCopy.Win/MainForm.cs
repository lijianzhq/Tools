using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using DBCopy.BLL;
using Oracle.ManagedDataAccess.Client;

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
            var sourceDBType = comb_souceDBType.Text;
            var sourceDBConnectionStr = txt_sourceDBConnStr.Text;
            var targetDBType = comb_targetDBType.Text;
            var targetDBConnectionStr = txt_targetDBConnStr.Text;
            var sourceDB = BLL.DBFactory.CreateDB(sourceDBType, sourceDBConnectionStr);
            var targetDB = BLL.DBFactory.CreateDB(targetDBType, targetDBConnectionStr);

            Task.Factory.StartNew(new Action(() =>
            {
                CopyUniqueIndex(sourceDB, targetDB);
            })).ContinueWith(new Action<Task>((tsk) =>
            {
                this.Invoke(new Action(() =>
                {
                    ShowLogMsg("已经完成同步完成");
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
            //var tables = new List<DBTable>() { new DBTable() { TableName = "PS_RESOURCE" } };
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
                        }
                        catch (Exception ex)
                        {
                            var oraEx = ex as OracleException;
                            if (oraEx?.Number == 1452)
                            {
                                //数据重复了，执行删除重复数据逻辑
                                //执行删除重复数据
                                ShowLogMsg($"同步[{index.Name}]失败，数据重复。错误：[{ex.Message}]");
                                var rowCount = targetDB.DeleteDuplication(index);
                                ShowLogMsg($"删除重复数据[{rowCount}]条");
                                targetDB.CreateTableIndex(index);
                                ShowLogMsg($"同步[{index.Name}]成功");
                            }
                            else
                            {
                                ShowLogMsg($"同步[{index.Name}],[{cols}]失败，错误：[{ex.Message}]");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowLogMsg($"同步[{index.Name}],[{cols}]失败，错误：[{ex.Message}]");
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
    }
}
