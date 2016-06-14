using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;  

namespace IPRenew
{
    public class Network
    {
        public static string ChangeIP(string oldIp)
        {
            Network p = new Network();
            Console.WriteLine(oldIp);
            new Mercury().RenewIP();
            string newIP = p.GetPublicIP();
            while (newIP == oldIp)
            {
                new Mercury().RenewIP();
                newIP = p.GetPublicIP();
            }
            Console.WriteLine(newIP);
            return newIP;
        }
        public string GetPublicIP()
        {
            String direction = "";
            try
            {
                
                WebRequest request = WebRequest.Create("http://bot.whatismyipaddress.com/");
                using (WebResponse response = request.GetResponse())
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    direction = stream.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return direction;
        }

        public bool IsOnline()
        {
            string ipStr = "113.207.34.20";
            Ping pingSender = new Ping();
            //Ping 选项设置  
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            //测试数据  
            string data = "a";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            //设置超时时间  
            int timeout = 120;
            //调用同步 send 方法发送数据,将返回结果保存至PingReply实例  
            PingReply reply = pingSender.Send(ipStr, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            return false;
        }
    }
}
