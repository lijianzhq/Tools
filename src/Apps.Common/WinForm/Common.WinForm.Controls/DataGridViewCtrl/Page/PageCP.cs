using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace DreamCube.Apps.Common.WinForm.Controls.DataGridViewCtrl.Page
{
    public abstract class PageCP : Component
    {
        #region "事件"

        /// <summary>
        /// 页面改变的事件
        /// (同步触发的，所以在此事件不可以做耗时的操作，否则会导致UI卡死)
        /// </summary>
        public event EventHandler<PageCtrlEventArgs> OnPageIndexChange;

        /// <summary>
        /// 页码大小改变时触发事件
        /// (同步触发的，所以在此事件不可以做耗时的操作，否则会导致UI卡死)
        /// </summary>
        public event EventHandler<PageCtrlEventArgs> OnPageSizeChange;

        /// <summary>
        /// 改变总记录数属性时触发此事件
        /// (同步触发的，所以在此事件不可以做耗时的操作，否则会导致UI卡死)
        /// </summary>
        public event EventHandler<PageCtrlEventArgs> OnTotalRecordChange;

        #endregion

        #region "字段"

        /// <summary>
        /// 总记录数
        /// </summary>
        private Int32 totalRecord = 0;

        /// <summary>
        /// 当前页码
        /// </summary>
        private Int32 pageIndex = 1;

        /// <summary>
        /// 当前页面大小
        /// </summary>
        private Int32 pageSize = 20;

        #endregion

        #region "属性"

        /// <summary>
        /// 总页数
        /// </summary>
        public Int32 TotalPage
        {
            get 
            {
                if (TotalRecord == 0) return 1;
                return (Int32)Math.Ceiling((Double)((Double)TotalRecord / (Double)PageSize)); 
            }
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public Int32 PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public Int32 TotalRecord
        {
            get { return totalRecord; }
            set
            {
                if (totalRecord != value)
                {
                    if (totalRecord == 0 && value != 0) this.pageIndex = 1;
                    totalRecord = value;
                    FireTotalRecordChangeEvent();
                }
            }
        }

        /// <summary>
        /// 每页显示多少条记录
        /// </summary>
        public Int32 PageSize
        {
            get { return pageSize; }
            set
            {
                if (pageSize != value)
                    pageIndex = 1;
                pageSize = value;
            }
        }

        #endregion

        #region "方法"

        /// <summary>
        /// 跳转值首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FirstPage(Object sender, EventArgs e)
        {
            if (this.PageIndex <= 1) return;
            this.PageIndex = 1;
            FirePageIndexChangeEvent();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PrePage(Object sender, EventArgs e)
        {
            if (this.PageIndex <= 1) return;
            this.PageIndex -= 1;
            FirePageIndexChangeEvent();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NextPage(Object sender, EventArgs e)
        {
            if (this.PageIndex >= this.TotalPage) return;
            this.PageIndex += 1;
            FirePageIndexChangeEvent();
        }

        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LastPage(Object sender, EventArgs e)
        {
            if (this.PageIndex >= this.TotalPage) return;
            this.PageIndex = this.TotalPage;
            FirePageIndexChangeEvent();
        }

        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void JumpTo(Object sender, EventArgs e)
        {
            Int32 pageIndex = GetPageIndex();
            if (pageIndex > this.TotalPage || pageIndex < 1) return;
            this.PageIndex = pageIndex;
            FirePageIndexChangeEvent();
        }

        /// <summary>
        /// 改变页码大小的时候触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PageSizeChange(Object sender, EventArgs e)
        {
            this.PageSize = GetPageSize();
            FirePageSizeChangeEvent();
        }

        /// <summary>
        /// 返回当前的页大小，由派生类根据不同的控件而重写
        /// </summary>
        /// <returns></returns>
        public abstract Int32 GetPageSize();

        /// <summary>
        /// 获取页面跳转时，输入的页码
        /// </summary>
        /// <returns></returns>
        public abstract Int32 GetPageIndex();

        #endregion

        #region "私有方法"

        /// <summary>
        /// 触发总记录数改变的事件
        /// </summary>
        private void FireTotalRecordChangeEvent()
        {
            if (OnTotalRecordChange != null)
            {
                PageCtrlEventArgs args = new PageCtrlEventArgs();
                args.PageIndex = this.PageIndex;
                args.PageSize = this.PageSize;
                args.TotalRecord = this.TotalRecord;
                OnTotalRecordChange(null, args);
            }
        }

        /// <summary>
        /// 触发页码改变的事件
        /// </summary>
        private void FirePageIndexChangeEvent()
        {
            if (OnPageIndexChange != null)
            {
                PageCtrlEventArgs args = new PageCtrlEventArgs();
                args.PageIndex = this.PageIndex;
                args.PageSize = this.PageSize;
                args.TotalRecord = this.TotalRecord;
                OnPageIndexChange(null, args);
            }
        }

        /// <summary>
        /// 触发页面大小改变的事件
        /// </summary>
        private void FirePageSizeChangeEvent()
        {
            if (OnPageSizeChange != null)
            {
                PageCtrlEventArgs args = new PageCtrlEventArgs();
                args.PageIndex = this.PageIndex;
                args.PageSize = this.PageSize;
                args.TotalRecord = this.TotalRecord;
                OnPageSizeChange(null, args);
            }
        }

        #endregion
    }
}
