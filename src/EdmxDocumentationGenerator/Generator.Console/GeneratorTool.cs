using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

using Generator;

namespace Generator.ConsoleTool
{
    public class GeneratorTool
    {
        public Boolean TryGenerate(String edmxFileFullPath,
                                    String dbConnectionString,
                                    String generatorAssemblyFileFullPath,
                                    String generatorTypeFulleName = "",
                                    String outputFileFullPath = "")
        {
            try
            {
                BasicGenerator generator = GetGenerateor(edmxFileFullPath, dbConnectionString, generatorAssemblyFileFullPath, generatorTypeFulleName, outputFileFullPath);
                return generator.TryDoGenerate();
            }
            catch (Exception ex)
            {
                //throw;
                WriteLogMsg(ex);
            }
            return false;
        }

        protected virtual BasicGenerator GetGenerateor(String edmxFileFullPath,
                                                       String dbConnectionString,
                                                       String generatorAssemblyFileFullPath,
                                                       String generatorTypeFulleName = "",
                                                       String outputFileFullPath = "")
        {
            Assembly asm = Assembly.LoadFrom(generatorAssemblyFileFullPath);
            Type basicType = typeof(BasicGenerator);
            List<Type> typeList = asm.GetTypes().Where(t => basicType.IsAssignableFrom(t)
                                                            && (String.IsNullOrWhiteSpace(generatorTypeFulleName) ? true : t.FullName == generatorTypeFulleName))
                                                            .ToList();
            if (typeList == null && typeList.Count == 0)
                throw new Exception("GetGeneratorInstance failed!");
            ConstructorInfo constructor = typeList[0].GetConstructor(new Type[] { typeof(String), typeof(String), typeof(String) });

            return constructor.Invoke(new Object[] { edmxFileFullPath, dbConnectionString, outputFileFullPath }) as BasicGenerator;
        }

        public virtual void WriteLogMsg(Exception ex)
        {
            WriteLogMsg(String.Format("failed,message:{0},stacktrace:{1}", ex.Message, ex.StackTrace));
        }

        public virtual void WriteLogMsg(String msg)
        {
            Console.WriteLine(msg);
        }
    }
}
