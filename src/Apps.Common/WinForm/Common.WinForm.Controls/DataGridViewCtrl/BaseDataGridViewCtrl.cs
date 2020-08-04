using System;
using System.Data;
using System.Drawing.Design;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

//自定义命名空间
using DreamCube.Apps.Common.WinForm.Controls.Progress;
using DreamCube.Framework.DataAccess.Basic;
using DreamCube.Foundation.Basic.Utility;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl
{
    [ToolboxItem(false)]
    public class BaseDataGridViewCtrl : UserControl
    {
        #region "字段"

        private List<DataGridViewCtrlColumn> dataGridViewCtrlColumns = new List<DataGridViewCtrlColumn>();

        private Boolean pageControlVisible;

        /// <summary>
        /// 进度条框
        /// </summary>
        protected Control loadingForm;

        /// <summary>
        /// 分页控件
        /// </summary>
        protected Page.PageCP pageCP;

        /// <summary>
        /// 工具栏
        /// </summary>
        protected ToolBar.IToolBar toolBarCtrl;

        /// <summary>
        /// 分页控件
        /// </summary>
        protected Page.PageCP PageCP
        {
            get
            {
                if (pageCP == null) pageCP = GetPageCP();
                return pageCP;
            }
        }

        /// <summary>
        /// 分页控件
        /// </summary>
        protected ToolBar.IToolBar ToolBarCtrl
        {
            get
            {
                if (toolBarCtrl == null) toolBarCtrl = GetToolBar();
                return toolBarCtrl;
            }
        }

        #endregion

        #region "控件公开的事件"

        public delegate Object FormatDataHandler(Object sender, FormatDataEventArgs e);

        public event FormatDataHandler FormatData;

        public event EventHandler<DeleteRowEventArgs> DeleteRow;

        #endregion

        #region "受保护的事件"

        /// <summary>
        /// 当改变分页控件的配置信息时，像子控件传出此事件
        /// </summary>
        protected event EventHandler OnConfigPageControl;

        #endregion

        #region "控件公开的属性"

        #region "工具栏控件的属性"

        #region "控制按钮文本"

        /// <summary>
        /// 添加按钮文本
        /// </summary>
        [Category("自定义属性"), Description("添加按钮文本")]
        public String AddBtnText
        {
            get { return this.ToolBarCtrl.AddBtnText; }
            set { this.ToolBarCtrl.AddBtnText = value; }
        }

        /// <summary>
        /// 编辑按钮的文本
        /// </summary>
        [Category("自定义属性"), Description("编辑按钮的文本")]
        public String EditBtnText
        {
            get { return this.ToolBarCtrl.EditBtnText; }
            set { this.ToolBarCtrl.EditBtnText = value; }
        }

        /// <summary>
        /// 删除按钮的文本
        /// </summary>
        [Category("自定义属性"), Description("删除按钮的文本")]
        public String DeleteBtnText
        {
            get { return this.ToolBarCtrl.DeleteBtnText; }
            set { this.ToolBarCtrl.DeleteBtnText = value; }
        }

        /// <summary>
        /// 刷新按钮的文本
        /// </summary>
        [Category("自定义属性"), Description("刷新按钮的文本")]
        public String RefreshBtnText
        {
            get { return this.ToolBarCtrl.RefreshBtnText; }
            set { this.ToolBarCtrl.RefreshBtnText = value; }
        }

        #endregion

        #region "控制按钮可见性"

        /// <summary>
        /// 是否显示添加按钮（默认都是显示）
        /// </summary>
        [Category("自定义属性"), Description("是否显示添加按钮（默认都是显示）")]
        public Boolean ShowAddBtn
        {
            get { return this.ToolBarCtrl.ShowAddBtn; }
            set { this.ToolBarCtrl.ShowAddBtn = value; }
        }

        /// <summary>
        /// 是否显示删除按钮（默认都是显示）
        /// </summary>
        [Category("自定义属性"), Description("是否显示删除按钮（默认都是显示）")]
        public Boolean ShowDeleteBtn
        {
            get { return this.ToolBarCtrl.ShowDeleteBtn; }
            set { this.ToolBarCtrl.ShowDeleteBtn = value; }
        }

        /// <summary>
        /// 是否显示编辑按钮（默认都是显示）
        /// </summary>
        [Category("自定义属性"), Description("是否显示编辑按钮（默认都是显示）")]
        public Boolean ShowEditBtn
        {
            get { return this.ToolBarCtrl.ShowEditBtn; }
            set { this.ToolBarCtrl.ShowEditBtn = value; }
        }

        /// <summary>
        /// 是否显示刷新按钮（默认都是显示）
        /// </summary>
        [Category("自定义属性"), Description("是否显示刷新按钮（默认都是显示）")]
        public Boolean ShowRefreshBtn
        {
            get
            {
                return this.ToolBarCtrl.ShowRefreshBtn;
            }
            set
            {
                this.ToolBarCtrl.ShowRefreshBtn = value;
            }
        }

        #endregion

        #endregion

        #region "控件本身的属性"

        /// <summary>
        /// 控制是否显示分页控件
        /// </summary>
        [Category("自定义属性"), Description("是否显示分页控件")]
        public Boolean PageControlVisible
        {
            get { return this.pageControlVisible; }
            set
            {
                this.pageControlVisible = value;
                if (OnConfigPageControl != null) OnConfigPageControl(null, null);
            }
        }

        /// <summary>
        /// 表名或视图名（可以只指定表名，不需要指定sql文本）
        /// </summary>
        [Category("自定义属性"), Description("表名或视图名（可以只指定表名，不需要指定sql文本）")]
        public String TableName
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库实例
        /// </summary>
        [Category("自定义属性"), Description("数据库实例"), Browsable(false)]
        public Database Database
        {
            get;
            set;
        }

        /// <summary>
        /// 配置数据库名
        /// </summary>
        [Category("自定义属性"), Description("配置数据库名")]
        public String DBName
        {
            get;
            set;
        }

        /// <summary>
        /// 配置数据库连接字符串
        /// </summary>
        [Category("自定义属性"), Description("配置数据库连接字符串")]
        public String DBConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库类型（枚举值对应的字符串形式，例如：Sqlclient）
        /// </summary>
        [Category("自定义属性"), Description("数据库类型（枚举值对应的字符串形式，例如：Sqlclient）")]
        public String DbProviderTypeString
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库类型（枚举值）
        /// </summary>
        [Category("自定义属性"), Description("数据库类型（枚举值）")]
        public DBProviderType DBProviderType
        {
            get;
            set;
        }

        /// <summary>
        /// 主键列
        /// </summary>
        [Category("自定义属性"), Description("对应数据库的主键列")]
        public String PrimaryKey
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库列名与显示的列名信息的映射关系
        /// Key值对应数据库列名，Value值对应datagridview的数据列的信息对象实例
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [Category("自定义属性"), Description("datagridview的列"), NotifyParentProperty(true)]
        public List<DataGridViewCtrlColumn> DataGridViewCtrlColumns
        {
            get { return dataGridViewCtrlColumns; }
            set { dataGridViewCtrlColumns = value; }
        }

        /// <summary>
        /// 查询命令对应的文本
        /// </summary>
        [Category("自定义属性"), Description("查询命令对应的文本")]
        public String SelectCommandText
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示CheckBox列
        /// </summary>
        [Category("自定义属性"), Description("是否显示CheckBox列")]
        public Boolean ShowCheckBoxColumn
        {
            get;
            set;
        }

        #endregion

        #endregion

        #region "内部类"

        [Serializable]
        public class DataGridViewCtrlColumn
        {
            #region "字段"

            /// <summary>
            /// 对应的数据库列名
            /// </summary>
            public String dBColumnName;

            /// <summary>
            /// 列宽度
            /// </summary>
            public Int32 width;

            /// <summary>
            /// 此列自动调整宽度的模式
            /// </summary>
            public DataGridViewAutoSizeColumnMode autoSizeMode;

            /// <summary>
            /// DataGridViewColumn的类型
            /// </summary>
            public ColumnType columnType;

            /// <summary>
            /// 列的标题文本
            /// </summary>
            public String headerText;

            public String toolTipText;

            #endregion

            #region "属性"

            /// <summary>
            /// 对应的数据库列名
            /// </summary>
            public String DBColumnName
            {
                get { return dBColumnName; }
                set { dBColumnName = value; }
            }

            /// <summary>
            /// 列宽度
            /// </summary>
            public Int32 Width
            {
                get { return width; }
                set { width = value; }
            }

            /// <summary>
            /// 此列自动调整宽度的模式
            /// </summary>
            public DataGridViewAutoSizeColumnMode AutoSizeMode
            {
                get { return autoSizeMode; }
                set { autoSizeMode = value; }
            }

            /// <summary>
            /// DataGridViewColumn的类型
            /// </summary>
            public ColumnType ColumnType
            {
                get { return columnType; }
                set { columnType = value; }
            }

            /// <summary>
            /// 列的标题文本
            /// </summary>
            public String HeaderText
            {
                get { return headerText; }
                set { headerText = value; }
            }

            public String ToolTipText
            {
                get { return toolTipText; }
                set { toolTipText = value; }
            }

            #endregion
        }

        #endregion

        #region "派生类需要重写的虚方法"

        /// <summary>
        /// 获取选中的行
        /// </summary>
        /// <returns></returns>
        public virtual DataGridViewSelectedRowCollection GetSelectedRows() { return null; }

        /// <summary>
        /// 获取datagridview对象
        /// </summary>
        /// <returns></returns>
        protected virtual DataGridView GetDataGridView() { return null; }

        /// <summary>
        /// 获取分页控件
        /// </summary>
        /// <returns></returns>
        protected virtual Page.PageCP GetPageCP() { return null; }

        /// <summary>
        /// 获取工具栏控件
        /// </summary>
        /// <returns></returns>
        protected virtual ToolBar.IToolBar GetToolBar() { return null; }

        /// <summary>
        /// 显示进度条框
        /// </summary>
        protected virtual void ShowLoadingForm() {  }

        /// <summary>
        /// 关闭显示进度条框
        /// </summary>
        protected virtual void CloseLoadingForm() {  }

        /// <summary>
        /// 渲染DataGridView
        /// </summary>
        protected virtual void RenderGridView(DataTable data) {  }

        #endregion

        #region "受保护方法"

        protected DreamCube.Framework.DataAccess.Basic.DBProviderType GetDbProviderType()
        {
            switch (this.DBProviderType)
            {
                case DataGridViewCtrl.DBProviderType.Access:
                    return DreamCube.Framework.DataAccess.Basic.DBProviderType.Access;
                case DataGridViewCtrl.DBProviderType.MySQL:
                    return DreamCube.Framework.DataAccess.Basic.DBProviderType.MySQL;
                case DataGridViewCtrl.DBProviderType.Oracle:
                    return DreamCube.Framework.DataAccess.Basic.DBProviderType.Oracle;
                case DataGridViewCtrl.DBProviderType.SqlCe:
                    return DreamCube.Framework.DataAccess.Basic.DBProviderType.SqlCe;
                case DataGridViewCtrl.DBProviderType.SqlClient:
                    return DreamCube.Framework.DataAccess.Basic.DBProviderType.SqlClient;
            }
            throw new ArgumentException("DBProviderType");
        }

        protected Object FireFormatDataEvent(Object sender, FormatDataEventArgs e)
        {
            if (FormatData != null) return FormatData(sender, e);
            return e.OriginalValue;
        }

        #endregion

        #region "公共方法"

        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadData()
        {
            Action a = new Action(DoLoadData);
            a.BeginInvoke(LoadDataCallBack, null);
            //显示进度框
            Action show = new Action(() =>
            {
                ShowLoadingForm();
            });
            show.BeginInvoke(null, null);
        }

        #endregion

        #region "私有方法"

        /// <summary>
        /// 刷新按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ToolBarCtrl_Refresh(object sender, EventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// 删除按钮单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ToolBarCtrl_Delete(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = this.GetSelectedRows();
            if (selectedRows == null || selectedRows.Count == 0) return;
            if (MessageBoxHelper.YesNo(this, "确定删除选中的记录吗？") != DialogResult.Yes) return;
            ProgressFormStyle pgStyle = new ProgressFormStyle()
            {
                AutoRunProgressBar = true,
                FormTitle = "正在删除...",
                LabelText = "正在删除...",
                ShowCancleBtn = true
            };
            ProgressBarHelper.ShowAutoProgressDialog(this, new Action(() =>
            {
                List<Object> primaryKeys = new List<Object>();
                List<Int32> indexs = new List<Int32>();
                Database db = GetDatabase();
                String tableName = null;
                String where = "{0}={1}";
                DataGridView gridView = GetDataGridView();
                //先收集所有选中的主键值
                ControlHelper.ControlInvoke(this, new Action(() =>
                {
                    tableName = this.SelectCommandText.Right("from").SplitEx(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        primaryKeys.Add(row.Cells[this.PrimaryKey].Value);
                        indexs.Add(row.Index);
                    }
                }));

                //从数据库中删除所有记录
                for (Int32 i = primaryKeys.Count - 1; i >= 0; i--)
                {
                    if (DBObject.DeleteEx(tableName, db, String.Format(where, this.PrimaryKey, primaryKeys[i])) > 0)
                    {
                        //删除gridview控件的对应行
                        ControlHelper.ControlInvoke(this, new Action(() =>
                        {
                            if (DeleteRow != null) DeleteRow(gridView, new DeleteRowEventArgs() { Row = gridView.Rows[indexs[i]] });
                            gridView.Rows.RemoveAt(indexs[i]);
                        }));
                    }
                }
            }), 60, pgStyle);
        }

        /// <summary>
        /// 重新加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ReloadData(object sender, Page.PageCtrlEventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// 加载数据完毕
        /// </summary>
        /// <param name="result"></param>
        private void LoadDataCallBack(IAsyncResult result)
        {
            CloseLoadingForm();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void DoLoadData()
        {
            if (String.IsNullOrEmpty(this.SelectCommandText)) return;
            Int32 totalRecord = 0;
            DataTable data = GetData(out totalRecord);
            if (data != null)
            {
                ControlHelper.ControlInvoke(this, new Action(() =>
                {
                    PageCP.TotalRecord = totalRecord;
                    RenderGridView(data);
                }));
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="totalRecord"></param>
        /// <returns></returns>
        private DataTable GetData(out Int32 totalRecord)
        {
            totalRecord = 0;
            if (String.IsNullOrEmpty(this.SelectCommandText)) return null;
            Database db = GetDatabase();
            String sql = this.SelectCommandText.ToLower();
            String tableName = sql.Right("from").SplitEx(" ", StringSplitOptions.RemoveEmptyEntries)[0];
            String where = sql.RightOfLast(" where"); //左边必须有一个空格，因为where如果是某个列名的一部分，会出现bug
            String orderby = sql.RightOfLast(" order").Right("by");
            return DBObject.GetEx(tableName, db, PageCP.PageIndex, PageCP.PageSize, this.PrimaryKey, out totalRecord, "", where, orderby);
        }

        /// <summary>
        /// 获取数据库实例
        /// </summary>
        /// <returns></returns>
        private Database GetDatabase()
        {
            if (this.Database != null) return this.Database;
            Database db = null;
            if (!String.IsNullOrEmpty(this.DBConnectionString))
            {
                if (!String.IsNullOrEmpty(this.DbProviderTypeString))
                    db = DbManager.GetDBByConnectionString(DBConnectionString, this.DbProviderTypeString);
                else
                {
                    if (Enum.IsDefined(typeof(DBProviderType), this.DBProviderType))
                    {
                        db = DbManager.GetDBByConnectionString(DBConnectionString, this.GetDbProviderType());
                    }
                    else
                    {
                        db = DbManager.GetDBByConnectionString(DBConnectionString, this.GetDbProviderType());
                    }
                }
            }
            else db = DbManager.GetDBByName(this.DBName);
            return db;
        }

        protected BaseDataGridViewCtrl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化模块方法
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseDataGridViewCtrl
            // 
            this.Name = "BaseDataGridViewCtrl";
            this.Load += new System.EventHandler(this.BaseDataGridViewCtrl_Load);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// 模块的load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseDataGridViewCtrl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                PageCP.OnPageSizeChange += new EventHandler<Page.PageCtrlEventArgs>(ReloadData);
                PageCP.OnPageIndexChange += new EventHandler<Page.PageCtrlEventArgs>(ReloadData);
                ToolBarCtrl.Delete += new EventHandler(ToolBarCtrl_Delete);
                ToolBarCtrl.Refresh += new EventHandler(ToolBarCtrl_Refresh);
            }
        }

        #endregion
    }
}
