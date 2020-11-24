using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace socketTest.SClient
{
    class Program
    {
        static Socket clientSocket = null;
        static Thread thread = null;
        static void Main(string[] args)
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //这里联通nginx代理服务器地址ip
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                //var endpoint = new IPEndPoint(ip, Convert.ToInt32("11911"));
                var endpoint = new IPEndPoint(ip, Convert.ToInt32("11913"));
                clientSocket.Connect(endpoint);
                thread = new Thread(ReceMsg);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("123");
            Console.ReadKey();
        }
        static void ReceMsg()
        {
            while (true)
            {
                byte[] buffer = new byte[1024 * 1024 * 2];
                clientSocket.Receive(buffer);
                string ReceiveMsg = System.Text.Encoding.UTF8.GetString(buffer).Substring(0, 30);
                Console.WriteLine("接收到数据:" + ReceiveMsg);
            }
        }
    }
}
