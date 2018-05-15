using System;
using System.Net;
using System.Text;

namespace AutoSubmit.BLL
{
    public class SubmitService
    {
        private WebClientWithSession _webClient = null;

        public WebClientWithSession WebClient
        {
            get
            {
                if (_webClient == null)
                    _webClient = new WebClientWithSession();
                return _webClient;
            }
        }

        public Boolean Login(String userName, String password)
        {
            String url = "http://210.76.66.109:7006/gdweb/ajaxlogin.do";
            String data = "LOGINID=monica1688&PASSWORD=3132383a3134383a33373a38313a3131313a3131323a3137313a38373a3134363a3134313a34303a34333a38363a333a35313a35373a3130383a37313a35393a3231333a36343a35383a32363a313337&IMAGCHECK=2re6&ISCA=false&CAMY=&ticket=137313&des_key=6535795hnisi&subsys=ldl&SUBSYS=LDL";
            var result = WebClient.UploadData(new Uri(url), Encoding.UTF8.GetBytes(data));
            result.
        }
    }
}
