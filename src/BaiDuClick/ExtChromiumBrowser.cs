using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

namespace BaiDuClick
{
    public class ExtChromiumBrowser : ChromiumWebBrowser
    {
        public ExtChromiumBrowser()
        {
            this.LifeSpanHandler = new CefLifeSpanHandler();
        }
    }
}
