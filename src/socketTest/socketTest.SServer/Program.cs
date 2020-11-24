using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace socketTest.SServer
{
    class Program
    {
        static Socket sck = null;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //监听本机ip        
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, int.Parse("11911"));
            sck.Bind(endPoint);
            sck.Listen(10);
            Console.WriteLine("开启监听！");
            Thread thread = new Thread(JtSocket);
            thread.IsBackground = true;
            thread.Start();
            while (true)
            {
                var msg = Console.ReadLine().Trim();
                if (msg != "")
                {
                    byte[] buffer = System.Text.Encoding.ASCII.GetBytes(msg); //将要发送的数据，生成字节数组。
                    accSck.Send(buffer);
                    Console.WriteLine("向客户端发送了:" + msg);
                }
            }
        }
        static Socket accSck = null;
        static void JtSocket()
        {
            while (true)
            {
                accSck = sck.Accept();
                Console.WriteLine("链接成功！");
            }
        }
    }
}
