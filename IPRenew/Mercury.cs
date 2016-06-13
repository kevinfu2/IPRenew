using HTMLFetchAndParse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace IPRenew
{
    public class Mercury
    {
        HTMLFetcher Fetcher = new HTMLFetcher();

        public void RenewIP()
        {
            //xb2g56hc9TefbwK
            //SecurityEncode(password, "RDpbLfCPsJZ7fiv", "yLwVl0zKqws7LgKPRQ84Mdt708T1qQ3Ha7xv3H7NyU84p21BriUWBU43odz3iP4rBL3cD02KZciXTysVXiV8ngg6vL48rPJyAUw0HurW20xqxv9aYb4M9wK1Ae0wlro510qXeU07kV57fQMc8L6aLgMLwygtc0F10a0Dg70TOoouyFhdysuRMO51yY5ZlOZZLEal1h0t9YQW0Ko7oBwmCAHoic4HYbUyVeU3sfQ1xtXcPcf1aT303wAQhv66qzW");
            
            string content = Fetcher.PostPage("http://172.16.2.1/?code=2&asyn=1", "");
            
            var lines = content.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var id = SecurityEncode(lines[3], "xb2g56hc9TefbwK", lines[4]);

            content = Fetcher.PostPage("http://172.16.2.1/?code=0&asyn=0&id="+HttpUtility.UrlEncode(id), "wan -linkDown");
            //Thread.Sleep(3000);
            content = Fetcher.PostPage("http://172.16.2.1/?code=0&asyn=0&id=" + HttpUtility.UrlEncode(id), "wan -linkUp");

        }
        public string SecurityEncode(string a, string b, string c)
        {
            StringBuilder d = new StringBuilder();
            var f = a.Length;
            var h = b.Length;
            var m = c.Length;
            var e = f > h ? f : h; //密码长度
            for (var g = 0; g < e; g++)
            {
                var l = 187;
                var k = 187;
                if (g >= f)
                {
                    l = (int)b[g];
                }
                else
                {
                    if (g >= h)
                    {
                        k = (int)a[g];
                    }
                    else
                    {
                        k = (int)a[g];
                        l = (int)b[g];
                    }
                }
                d.Append(c[(k ^ l) % m]);
            }
            return d.ToString();
        }
    }
}
