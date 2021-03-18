using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;

namespace BaiDuClick
{
    public partial class GoogleWB : Form
    {
        private String _baiduHomeUrl = "https://www.baidu.com/";
        private Logger _logger = null;
        private Boolean _isSearching = false;
        private CefSharp.IBrowser _browser = null;
        private System.Windows.Forms.Timer _timerClickAD = null;
        private System.Windows.Forms.Timer _timerClose = null;

        public GoogleWB()
        {
            InitializeComponent();
        }

        private void GoogleWB_Load(object sender, EventArgs e)
        {
            _logger = new Logger(this.txt_Log);

            var setting = new CefSharp.WinForms.CefSettings();
            var agents = new String[] {
            "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.198 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:86.0) Gecko/20100101 Firefox/86.0",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.192 Safari/537.36 OPR/74.0.3911.218"
            };
            setting.UserAgent = agents[0];
            CefSharp.Cef.Initialize(setting, true);

            //开始按钮
            btn_start_Click(null, null);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            var chWB = new CefSharp.WinForms.ChromiumWebBrowser();
            panel2.Controls.Add(chWB);
            chWB.Dock = DockStyle.Fill;
            chWB.FrameLoadEnd += ChWB_FrameLoadEnd;
            chWB.LoadingStateChanged += chWB_LoadingStateChanged;
            chWB.Load(_baiduHomeUrl);
            chWB.Show();
        }

        private void chWB_LoadingStateChanged(object sender, CefSharp.LoadingStateChangedEventArgs e)
        {
            _logger.Debug($"chWB_LoadingStateChanged，IsLoading：[{e.IsLoading}]");
            this._browser = e.Browser;
            if (this._isSearching == true && !e.IsLoading)
            {
                this._isSearching = false;
                _timerClickAD = new System.Windows.Forms.Timer();
                _timerClickAD.Tick += _timerClickAD;
                //等待5秒钟，加载完毕，再点击广告
                _timerClickAD.Interval = 1000 * 5;
                _timerClickAD.Start();
            }
        }

        private void _timerClickAD_Tick(object sender, EventArgs e)
        {
            _timerClickAD.Stop();
            btn_clickAD_Click(null, null);
        }

        private void ChWB_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            _logger.Debug($"ChWB_FrameLoadEnd--");
            var cookieManager = CefSharp.Cef.GetGlobalCookieManager();
            CookieVisitor visitor = new CookieVisitor();
            visitor.SendCookie += visitor_SendCookie;
            cookieManager.VisitAllCookies(visitor);

            if (e.Frame.IsMain)
            {
                var setValueScript = $"document.getElementById('kw').value='智推科技'";
                e.Browser.MainFrame.ExecuteJavaScriptAsync(setValueScript);

                var clickScript = $"document.getElementById('su').click()";
                e.Browser.MainFrame.ExecuteJavaScriptAsync(clickScript);
                this._isSearching = true;
            }
        }

        private void visitor_SendCookie(CefSharp.Cookie obj)
        {
            _logger.Debug($"domain：[{obj.Domain}], name：[{obj.Name}], value：[{obj.Value}]");
        }

        private void btn_clickAD_Click(object sender, EventArgs e)
        {
            var testScript = @"(function () {
                                    var aTags = document.getElementsByTagName('a');
                                    var allClassName = '';
                                    for (var key in aTags) {
                                        var a = aTags[key];
                                        if (a['target'] !== '_blank') continue;
                                        allClassName += 'classList：' + a['href'] + '\r\n';
                                        if (a.attributes && a.attributes['data-landurl']) {
                                            var dataLandUrl = a.attributes['data-landurl'].value;
                                            allClassName += 'data-landurl：' + dataLandUrl + '\r\n';
                                            if (dataLandUrl === 'http://www.ztkjgz.com/') {
                                                a.click();
                                                break;
                                            }
                                        }
                                    }
                                    return allClassName;
                                })()";
            var task = _browser.MainFrame.EvaluateScriptAsync(testScript);
            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    var response = t.Result;
                    var resultMsg = response.Success ? (response.Result ?? "null") : response.Message;
                    //this._logger.Debug($"JS ReturnVal：{resultMsg}");
                    _timerClose = new System.Windows.Forms.Timer();
                    _timerClose.Tick += _timerClose_Tick;
                    //等待5秒钟，加载完毕，执行关闭程序
                    _timerClickAD.Interval = 1000 * 5;
                    _timerClickAD.Start();
                }
            });
        }

        private void _timerClose_Tick(object sender, EventArgs e)
        {
            _timerClose.Stop();
            btn_restartWB_Click(null, null);
        }

        private void btn_restartWB_Click(object sender, EventArgs e)
        {
            try
            {
                if (_browser != null)
                {
                    _browser.CloseDevTools();
                    _browser.CloseBrowser(true);
                }
            }
            catch { }

            try
            {
                if (_browser != null)
                {
                    var cookieManager = CefSharp.Cef.GetGlobalCookieManager();
                    cookieManager.DeleteCookies();
                    _browser.Dispose();
                    Cef.Shutdown();
                }
            }
            catch { }
        }
    }
}
