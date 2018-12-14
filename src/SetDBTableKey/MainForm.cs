﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetDBTableKey
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AppendLogMsg(String msg)
        {
            this.Invoke(new Action(() =>
            {
                this.txt_Log.Text += msg + Environment.NewLine;
            }));
        }

        /// <summary>
        /// 设置主键值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                AppendLogMsg($"start...");
                var db = new BLL.OracleDBDDL(connectionString);
                var tables = db.GetAllTables();
                var count = tables.Count;
                AppendLogMsg($"table count:[{count}]");
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
                                db.SetTablePrimaryKey(it.TableName, primaryKeyName);
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
                        AppendLogMsg($"when do with table[{tableName}],an error occur,message:{ex?.Message}");
                    }
                    finally
                    {
                        Interlocked.Increment(ref totalDoCount);
                        if (Interlocked.Read(ref totalDoCount) == count)
                        {
                            AppendLogMsg($"已处理完成，总表数：[{count}],已经有主键的表数：[{hasKeysTables.Count()}],成功新建主键表数：[{successTables.Count()}]");
                        }
                    }
                });
            }));
        }
    }
}