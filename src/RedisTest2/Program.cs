using System;
using System.Threading;

namespace RedisTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var csredis = "127.0.0.1:27000,password=123456,defaultDatabase=1,prefix=";
            //(2)连接哨兵，并初始化，redis Sentinel
            //RedisHelper.Initialization(new CSRedis.CSRedisClient("mymaster,password=foobared",
            //            new string[] {
            //                "192.168.1.222:26379",
            //                "192.168.1.222:26380",
            //                "192.168.1.222:26381" }));
            //RedisHelper.Initialization(new CSRedis.CSRedisClient("mymaster,password=foobared",
            //            new string[] {
            //                "192.168.1.222:26379"}));

            //(1)单节点的方式 Single machine redis
            RedisHelper.Initialization(new CSRedis.CSRedisClient("192.168.2.17:6379,password=foobared"));
            while (true)
            {
                Test();
                Thread.Sleep(2000);
            }
            Console.ReadKey();
        }

        static void Test()
        {
            try
            {
                // 列表
                //删除指定key的列表
                RedisHelper.Del("list");

                RedisHelper.RPush("list", "第一个元素");
                RedisHelper.RPush("list", "第二个元素");
                Console.WriteLine($"list的长度为{RedisHelper.LLen("list")}");
                Console.WriteLine($"list的第二个元素为{RedisHelper.LIndex("list", 1)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error:" + ex.Message);
            }
        }
    }
}
