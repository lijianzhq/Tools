using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

using Generator;

namespace Generator.ConsoleTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //GeneratorTool tool = new GeneratorTool();
            //Boolean result = tool.TryGenerate(@"D:\01.Work\Test\Test2017\trunk\TestEF\Model1.edmx",
            //                                  @"data source=(localdb)\ProjectsV13;initial catalog=Test;integrated security=True",
            //                                  "SqlServer2016.Generator.dll",
            //                                  "",
            //                                  @"D:\01.Work\Test\Test2017\trunk\TestEF\Model1.edmx");

            GeneratorTool tool = new GeneratorTool();
            //Boolean result = tool.TryGenerate(@"D:\01.Work\Test\Test2017\trunk\GenerateEntity\Model_MQCSBUS.edmx",
            //                                  @"DATA SOURCE=172.26.136.162:1521/KFMQCS;PASSWORD=PQ;PERSIST SECURITY INFO=True;USER ID=PQ",
            //                                  "Oracle.Generator.dll",
            //                                  "",
            //                                  @"D:\01.Work\Test\Test2017\trunk\GenerateEntity\Model_MQCSBUS.edmx");
            //Boolean result = tool.TryGenerate(@"D:\01.Work\Test\Test2017\trunk\GenerateEntity\MQCSBUS_Entity\MQCSBUS.edmx",
            //                                  @"DATA SOURCE=172.26.136.162:1521/KFMQCS;PASSWORD=MQCSBUS;PERSIST SECURITY INFO=True;USER ID=MQCSBUS",
            //                                  "Oracle.Generator.dll",
            //                                  "",
            //                                  @"D:\01.Work\Test\Test2017\trunk\GenerateEntity\MQCSBUS_Entity\MQCSBUS.edmx");

            Boolean result = tool.TryGenerate(@"D:\01.Work\Test\Test2017\trunk\GenerateEntity\DB_Entity\DB.edmx",
                                              @"DATA SOURCE=172.26.136.162:1521/KFMQCS;PASSWORD=DB;PERSIST SECURITY INFO=True;USER ID=DB",
                                              "Oracle.Generator.dll",
                                              "",
                                              @"D:\01.Work\Test\Test2017\trunk\GenerateEntity\DB_Entity\DB.edmx");
            if (!result)
                Console.Read();
        }
    }
}
