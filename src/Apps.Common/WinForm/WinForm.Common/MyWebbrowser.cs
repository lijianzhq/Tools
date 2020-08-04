using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DreamCube.WinForm.Common
{
    public static class MyWebbrowser
    {
        #region "事件"

        /// <summary>
        /// 防止webbrowser里面打开新的浏览器窗体来打开网页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void NewWindowEvent(Object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            WebBrowser webBrowser_temp = sender as WebBrowser;
            if (webBrowser_temp != null)
            {
                String newUrl = webBrowser_temp.Document.ActiveElement.GetAttribute("href");
                webBrowser_temp.Navigate(newUrl);
            }
        }

        #endregion

        #region "方法"

        /// <summary>
        /// 根据CSS类名获取元素
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="className"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public static List<HtmlElement> GetElementsByClassName(WebBrowser browser, String className, String tagName = "")
        {
            if (browser != null && browser.Document !=null)
            {
                List<HtmlElement> targets = new List<HtmlElement>();
                HtmlDocument doc = browser.Document;
                HtmlElementCollection els = null;
                if (String.IsNullOrEmpty(tagName)) els = doc.GetElementsByTagName(tagName);
                else els = doc.Body.All;

                foreach (HtmlElement item in els)
                {
                    if (item.GetAttribute("className") == className) targets.Add(item);
                }
                return targets;
            }
            return null;
        }

        #endregion
    }
}
