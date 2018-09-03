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
            GeneratorTool tool = new GeneratorTool();
            //Boolean result = tool.TryGenerate(@"D:\01.Work\Test\Test2017\trunk\TestEF\Model1.edmx",
            //                                  @"data source=(localdb)\ProjectsV13;initial catalog=Test;integrated security=True",
            //                                  "SqlServer2016.Generator.dll",
            //                                  "",
            //                                  @"D:\01.Work\Test\Test2017\trunk\TestEF\Model1.edmx");

            //GeneratorTool tool = new GeneratorTool();
            //var generator = tool.GetGenerateor(@"D:\01.Work\Test\Test2017\trunk\GenerateEntity\PQ_Entity\PQ.edmx",
            //                                    @"DATA SOURCE=172.26.136.162:1521/KFMQCS;PASSWORD=MQCSBUS;PERSIST SECURITY INFO=True;USER ID=MQCSBUS",
            //                                    "Oracle.Generator.dll",
            //                                    "",
            //                                    @"D:\01.Work\Test\Test2017\trunk\GenerateEntity\PQ_Entity\PQ.edmx") as Oracle.Generator.OracleGenerator;
            //var doc = generator.GetColumnDocumentation("T_EAP_CALENDAR_SETTING", "USER_CONF");
            //var data = doc.Split(new String[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(doc);


            //Boolean result = tool.TryGenerate(@"D:\01.Work\Test\Test2017\trunk\GenerateEntity\PQ_Entity\PQ.edmx",
            //                                  @"DATA SOURCE=172.26.136.162:1521/KFMQCS;PASSWORD=PQ;PERSIST SECURITY INFO=True;USER ID=PQ",
            //                                  "Oracle.Generator.dll",
            //                                  "",
            //                                  @"D:\01.Work\Test\Test2017\trunk\GenerateEntity\PQ_Entity\PQ.edmx");



            Boolean result = tool.TryGenerate(@"D:\01.Work\szlanyou\TQMP_公共产出\00_源程序\LY.CommonCodes\LY.CommonCodes.GenerateEntity\PTMC\DB_PTMC.edmx",
                                              @"DATA SOURCE=172.26.175.94:1521/PTMCDB;PASSWORD=PTMC;PERSIST SECURITY INFO=True;USER ID=PTMC",
                                              "Oracle.Generator.dll",
                                              "",
                                              @"D:\01.Work\szlanyou\TQMP_公共产出\00_源程序\LY.CommonCodes\LY.CommonCodes.GenerateEntity\PTMC\DB_PTMC.edmx");

            //Boolean result = tool.TryGenerate(@"D:\01.Work\Test\Test2017\trunk\GenerateEntity\DB_Entity\DB.edmx",
            //                                  @"DATA SOURCE=172.26.136.162:1521/KFMQCS;PASSWORD=DB;PERSIST SECURITY INFO=True;USER ID=DB",
            //                                  "Oracle.Generator.dll",
            //                                  "",
            //                                  @"D:\01.Work\Test\Test2017\trunk\GenerateEntity\DB_Entity\DB.edmx");
            if (!result)
                Console.Read();
        }
    }
}
