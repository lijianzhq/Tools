using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace AutoSubmit.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            String url = "http://210.76.66.109:7006/gdweb/ajaxlogin.do";
            //String url = "http://210.76.66.109:7006/gdweb/ggfw/web/pub/mainpage/mainpageldl.do";
            String data = "LOGINID=monica1688&PASSWORD=3132383a3134383a33373a38313a3131313a3131323a3137313a38373a3134363a3134313a34303a34333a38363a333a35313a35373a3130383a37313a35393a3231333a36343a35383a32363a313337&IMAGCHECK=2re6&ISCA=false&CAMY=&ticket=137313&des_key=6535795hnisi&subsys=ldl&SUBSYS=LDL";
            WebClient client = new WebClient();
            var result = client.UploadData(new Uri(url), Encoding.UTF8.GetBytes(data));
            Console.WriteLine(Encoding.UTF8.GetString(result));
            Console.Read();
        }
    }
}
