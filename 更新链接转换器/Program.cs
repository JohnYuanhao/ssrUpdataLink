using System;
using System.Collections.Generic;
using System.IO;
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
            string str1 = web("https://raw.githubusercontent.com/breakwa11/breakwa11.github.io/master/free/freenodeplain.txt");

            str1 = change(str1);
            str1 = str1.Replace("MAX=5", "MAX=99");
            str1 = change(str1);
            using (StreamWriter sw1 = new StreamWriter("C:\\wamp64\\www\\updata\\official.txt", false))
            {
                sw1.WriteLine(str1);
            }

            string str2 = web("http://127.0.0.1/updata/main.php");
            //string str2 = web("http://123.206.189.235/updata/main.php");
            str2 = str2.Remove(0, str2.IndexOf("M"));//不知名原因，大概是编码的问题致使文档开头出现未知字符，查找MAX的位置，直接移除未知字符
            str2 = change(str2);
            using (StreamWriter sw2 = new StreamWriter("C:\\wamp64\\www\\updata\\ishadow.txt", false))
            {
                sw2.WriteLine(str2);
            }


        }

        public static string change(string str)
        {
            if (str.IndexOf("MAX") < 5 && str.IndexOf("MAX") != -1)
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
            }
            else
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(str));
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
