using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 更新链接转换器
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = web("https://raw.githubusercontent.com/breakwa11/breakwa11.github.io/master/free/freenodeplain.txt");
            //https://raw.githubusercontent.com/breakwa11/breakwa11.github.io/master/free/freenodeplain.txt
            //if (str.IndexOf("MAX") < 5 && str.IndexOf("MAX") != -1)
            str = Encoding.UTF8.GetString(Convert.FromBase64String(str));
            string a = str.Replace("MAX=5", "MAX=99");
            str = Convert.ToBase64String(Encoding.UTF8.GetBytes(a));

            //else
            //{

            //}



            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\wamp64\\www\\updata\\updata.txt", false))
            {
                sw.WriteLine(str);
            }
        }

        public static string web(string web_src, string encod = "UTF8")
        {
            try
            {

                WebClient MyWebClient = new WebClient()
                {
                    Credentials = CredentialCache.DefaultCredentials//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                };
                Byte[] pageData = MyWebClient.DownloadData(web_src); //从指定网站下载数据
                string pageHtml = "";
                if (encod == "gbk")
                {
                    pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            
                }
                else
                {
                    pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
                }
                return pageHtml;
            }

            catch (WebException webEx)
            {

                Console.WriteLine("网址访问出现以下错误:" + webEx.Message.ToString());
                return null;
            }
        }
    }
}
