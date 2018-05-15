using System;
using System.Windows.Forms;

using Mini.Foundation.Basic.Utility;

namespace AutoSubmit.Win
{
    class BrowserWrapper
    {
        private WebBrowser _wb;

        /// <summary>
        /// 文档加载完毕事件，传入参数url
        /// </summary>
        public event Action<String> DocumentCompleted;
        public event Action<String> Navigated;

        public BrowserWrapper(WebBrowser wb)
        {
            _wb = wb;
        }

        public void InvokeDocumentCompleted(String url)
        {
            DocumentCompleted?.Invoke(url);
        }

        public void InvokeNavigated(String url)
        {
            Navigated?.Invoke(url);
        }
    }
}
