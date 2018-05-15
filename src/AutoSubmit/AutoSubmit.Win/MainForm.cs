using AutoSubmit.Win.Properties;
using System;
using System.Windows.Forms;

namespace AutoSubmit.Win
{
    public partial class MainForm : Form
    {
        private BrowserWrapper _browserWrapper = null;
        private String _mainPageUrl = "http://210.76.66.109:7006/gdweb/ggfw/web/pub/ggfwldl.do";
        private String _submitPageUrl = "http://210.76.66.109:7006/gdweb/ggfw/web/wsyw/wsyw.do";
        private String _submitFramePageURL = "http://210.76.66.109:7006/gdweb/ggfw/web/wsyw/app/ldlzy/gryw/grbtsb/btxx.do?MenuId=170201&systype=P_LDL";

        public MainForm()
        {
            InitializeComponent();
            _browserWrapper = new BrowserWrapper(this.main_browser);
            _browserWrapper.DocumentCompleted += MainPageDocumentCompleted;
            _browserWrapper.DocumentCompleted += SubmitPageDocumentCompleted;
            _browserWrapper.DocumentCompleted += SubmitFramePageURLDocumentCompleted;
            _browserWrapper.Navigated += SubmitPageNavigated;
            _browserWrapper.Navigated += SubmitFramePageNavigated;
        }

        private void main_browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            _browserWrapper.InvokeNavigated(e.Url.ToString());
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void SubmitPageNavigated(String url)
        {
            if (url != _submitPageUrl) return;
            //InjectAlertBlocker();
        }
        private void SubmitFramePageNavigated(String url)
        {
            if (url != _submitFramePageURL) return;
            InjectAlertBlocker();
        }


        /// <summary>
        /// 登陆页面加载完毕事件
        /// </summary>
        /// <param name="url">登陆网址</param>
        public void SubmitPageDocumentCompleted(String url)
        {
            if (url != _submitPageUrl) return;
            RemoveScript();
            DoSubmit();
        }
        public void SubmitFramePageURLDocumentCompleted(String url)
        {
            if (url != _submitFramePageURL) return;
            RemoveScript();
            DoSubmit();
        }

        private void RemoveScript()
        {
            var doc = main_browser.Document.Window.Frames["wsyw_main_content_iframe"]?.Document;
            var elementCollection = doc.GetElementsByTagName("script");
            for (var i = 0; i < elementCollection.Count; i++)
            {
                var e = elementCollection[0];
                var node = e.DomElement as mshtml.IHTMLDOMNode;
                var html = e.InnerText;
                node.parentNode.removeChild(node);
            }

        }

        private void DoSubmit()
        {
            //var btn = main_browser.Document.Window.Frames["wsyw_main_content_iframe"]?
            //    .Document?.GetElementById("submitBtn");
            //if (btn == null) return;
            //btn.SetAttribute("disabled", "false");
            //btn.InvokeMember("click");
            var doc = main_browser.Document.Window.Frames["wsyw_main_content_iframe"]?.Document;
            if (doc == null) return;
            doc.InvokeScript("ldlzy_subbefor");
        }

        //private void CancelAlertWin()
        //{
        //    var doc = main_browser.Document.Window.Frames["wsyw_main_content_iframe"]?.Document;
        //    HtmlElement head = doc.GetElementsByTagName("head")[0];
        //    HtmlElement scriptEl = doc.CreateElement("script");
        //    mshtml.IHTMLScriptElement element = (mshtml.IHTMLScriptElement)scriptEl.DomElement;
        //    string alertBlocker = "window.alert = function () { }";
        //    element.text = alertBlocker;
        //    head.AppendChild(scriptEl);
        //    wbNav.ScriptErrorsSuppressed = true;
        //}

        private void InjectAlertBlocker()
        {
            //var doc = main_browser.Document.Window.Frames["wsyw_main_content_iframe"]?.Document;
            //HtmlElement head = doc.GetElementsByTagName("head")[0];
            //HtmlElement scriptEl = doc.CreateElement("script");
            ////string alertBlocker = "window.alert = function () { }";
            //string alertBlocker = "CFW.oWin.fnAlert = function () { };window.alert = function () { }";
            ////string alertBlocker = "alert(1);";
            //scriptEl.SetAttribute("text", alertBlocker);
            //head.AppendChild(scriptEl);
            //doc.Body.AppendChild(scriptEl);
            //main_browser.Document.Body.AppendChild(scriptEl);


            var doc = main_browser.Document.Window.Frames["wsyw_main_content_iframe"]?.Document;
            //HtmlElement head = doc.GetElementsByTagName("head")[0];
            var head = doc.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = doc.CreateElement("script");
            mshtml.IHTMLScriptElement element = (mshtml.IHTMLScriptElement)scriptEl.DomElement;
            string alertBlocker = "CFW.oWin.fnAlert = function () { };window.alert = function () { }";
            element.text = alertBlocker;
            head.AppendChild(scriptEl);
            doc.Body.AppendChild(scriptEl);
            main_browser.ScriptErrorsSuppressed = true;
        }

        /// <summary>
        /// 登陆页面加载完毕事件
        /// </summary>
        /// <param name="url">登陆网址</param>
        public void MainPageDocumentCompleted(String url)
        {
            if (url != _mainPageUrl) return;

            var loginidCount = main_browser.Document.Window.Frames["main_content_iframe"]?.Document?.All.GetElementsByName("loginid").Count;
            if (loginidCount == 0)
            {
                //main_browser.Navigate(_submitPageUrl);
                GoToSubmitPage();
            }
            else
            {
                SetUserNameAndPassword();
                SetValidateCode();
            }
            //String postData = GetLoginPostData();
            //DoLogin();
            //ExecDoLoginJS();
        }

        private void GoToSubmitPage()
        {
            //var doc = main_browser.Document.Window.Frames["main_content_iframe"]?.Document;
            var doc = main_browser.Document;
            if (doc == null) return;
            var div = doc.CreateElement("div");
            div.SetAttribute("innerHTML", Resources.GoToSubmitPageHTML);
            doc.Body.AppendChild(div);

            var script = doc.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.SetAttribute("text", Resources.GotoSubmitPageJS);
            HtmlElement head = doc.Body.AppendChild(script);
            doc.InvokeScript("goToSubmitPage");
        }

        private void ExecDoLoginJS()
        {
            var doc = main_browser.Document.Window.Frames["main_content_iframe"]?.Document;
            if (doc == null) return;
            var script = doc.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.SetAttribute("text", Resources.DoLoginJS);
            HtmlElement head = doc.Body.AppendChild(script);
            //MessageBox.Show(Convert.ToString(doc.InvokeScript("getLoginPostData")));
            doc.InvokeScript("doLogin");
        }

        /// <summary>
        /// 加入登陆的辅助js脚本
        /// </summary>
        private String GetLoginPostData()
        {
            var doc = main_browser.Document.Window.Frames["main_content_iframe"]?.Document;
            if (doc == null) return String.Empty;
            var script = doc.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.SetAttribute("text", Resources.GetLoginPostDataJS);
            HtmlElement head = doc.Body.AppendChild(script);
            //MessageBox.Show(Convert.ToString(doc.InvokeScript("getLoginPostData")));
            return Convert.ToString(doc.InvokeScript("getLoginPostData"));
        }

        /// <summary>
        /// 执行登陆操作
        /// </summary>
        public void DoLogin()
        {
            main_browser.Document.Window.Frames["main_content_iframe"]?
                .Document?.GetElementById("loginBtn").InvokeMember("click");
        }

        /// <summary>
        /// 设置验证码
        /// </summary>
        public void SetValidateCode()
        {
            var vcode = main_browser.Document.Window.Frames["main_content_iframe"]?
                .Document?.All.GetElementsByName("vcode")?[0];
            if (vcode == null) return;
            vcode.Focus();
            vcode.SetAttribute("value", "ABCD");
        }

        public void SetUserNameAndPassword()
        {
            var doc = main_browser.Document.Window.Frames["main_content_iframe"]?.Document;
            if (doc == null) return;
            var loginid = doc.All.GetElementsByName("loginid")[0];
            //MyArgumentsHelper.ThrowsIfNullOrNoRecord(col_id, nameof(col_id));
            loginid.Focus();
            loginid.SetAttribute("value", txt_userName.Text);
            var password = doc.All.GetElementsByName("password")[0];
            //MyArgumentsHelper.ThrowsIfNullOrNoRecord(col_pw, nameof(col_pw));
            password.Focus();
            password.SetAttribute("value", txt_password.Text);
        }

        /// <summary>
        /// 窗体加载完毕事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Document.Window.Error += new HtmlElementErrorEventHandler(IgnoreErrorWin);
            _browserWrapper.InvokeDocumentCompleted(e.Url.ToString());
        }

        private void IgnoreErrorWin(object sender, HtmlElementErrorEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            main_browser.Navigate(_mainPageUrl);
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            //ExecDoLoginJS();
            DoLogin();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            DoSubmit();
        }

        private void main_browser_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
