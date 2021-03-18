using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace BaiDuClick
{
    public class CefLifeSpanHandler : ILifeSpanHandler
    {
        public CefLifeSpanHandler()
        {

        }

        public bool DoClose(IWebBrowser browserControl, CefSharp.IBrowser browser)
        {
            if (browser.IsDisposed || browser.IsPopup)
            {
                return false;
            }

            return true;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }

        //public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IWindowInfo windowInfo, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        //{
        //    var chromiumWebBrowser = (ExtChromiumBrowser)browserControl;

        //    if (!string.IsNullOrEmpty(targetUrl))
        //    {
        //        chromiumWebBrowser.Load(targetUrl);
        //    }

        //    newBrowser = null;
        //    return false;
        //}

        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            if (!string.IsNullOrEmpty(targetUrl))
            {
                chromiumWebBrowser.Load(targetUrl);
            }

            newBrowser = null;
            return true;
        }
    }
}
