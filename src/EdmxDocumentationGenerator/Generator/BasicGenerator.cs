using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace Generator
{
    public abstract class BasicGenerator
    {
        protected XElement _EdmxFiledoc;

        protected virtual String EdmxFileFullPath
        {
            get;
            set;
        }

        protected virtual String OutputFileFullPath
        {
            get;
            set;
        }

        protected virtual String DBConnectionString
        {
            get;
            set;
        }

        public BasicGenerator(String edmxFileFullPath, String dbConnectionString, String outputFileFullPath = "")
        {
            if (String.IsNullOrWhiteSpace(edmxFileFullPath))
                throw new ArgumentNullException("edmxFileFullPath");
            if (String.IsNullOrWhiteSpace(dbConnectionString))
                throw new ArgumentNullException("dbConnectionString");
            this.EdmxFileFullPath = edmxFileFullPath;
            this.DBConnectionString = dbConnectionString;
            this.OutputFileFullPath = outputFileFullPath;
        }

        /// <summary>
        /// 执行生成操作
        /// </summary>
        public virtual Boolean TryDoGenerate()
        {
            try
            {
                if (!File.Exists(EdmxFileFullPath))
                    throw new FileNotFoundException(String.Format("edmxFile [{0}] not Found!", EdmxFileFullPath));
                _EdmxFiledoc = XElement.Load(EdmxFileFullPath, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
                AddDocumentation();
                _EdmxFiledoc.Save(this.OutputFileFullPath);
                Console.WriteLine("success!");
                return true;
            }
            catch (Exception ex)
            {
                WriteLogMsg(ex);
                //throw;
            }
            return false;
        }

        public virtual void WriteLogMsg(Exception ex)
        {
            WriteLogMsg(String.Format("failed,message:{0},stacktrace:{1}", ex.Message, ex.StackTrace));
        }

        public virtual void WriteLogMsg(String msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// 获取Schema元素（映射数据库实例）
        /// </summary>
        /// <returns></returns>
        protected virtual XElement GetSchemaElement()
        {
            return _EdmxFiledoc.Elements().Where(e => e.Name.LocalName == "Runtime")
                                          .Elements()
                                          .Where(e => e.Name.LocalName == "ConceptualModels")
                                          .Elements()
                                          .Where(e => e.Name.LocalName == "Schema")
                                          .FirstOrDefault();
        }

        /// <summary>
        /// 获取EntityTypeElements（映射数据表）
        /// </summary>
        /// <param name="schema"></param>
        protected virtual IEnumerable<XElement> GetEntityTypeElements(XElement schema)
        {
            return schema.Elements().Where(e => e.Name.LocalName == "EntityType");
        }

        /// <summary>
        /// 获取PropertyElements（映射数据列）
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        protected virtual IEnumerable<XElement> GetPropertyElements(XElement entityType)
        {
            return entityType.Elements().Where(e => e.Name.LocalName == "Property");
        }

        /// <summary>
        /// 添加注释
        /// </summary>
        protected virtual void AddDocumentation()
        {
            XElement schema = GetSchemaElement();
            if (schema == null)
                throw new Exception(String.Format("[{0}] file resolve failed!", EdmxFileFullPath));

            IEnumerable<XElement> entityTypeElements = GetEntityTypeElements(schema);
            int i = 0;
            foreach (XElement entityTypeElement in entityTypeElements)
            {
                String tableName = entityTypeElement.Attribute("Name").Value;
                //添加表注释（映射类）
                this.AddNodeDocumentation(entityTypeElement, GetTableDocumentation(tableName));

                var propertyElements = GetPropertyElements(entityTypeElement);
                //添加列注释（映射属性）
                foreach (XElement propertyElement in propertyElements)
                {
                    String columnName = propertyElement.Attribute("Name").Value;
                    this.AddNodeDocumentation(propertyElement, GetColumnDocumentation(tableName, columnName));
                }
            }
        }

        /// <summary>
        /// 添加节点注释
        /// </summary>
        /// <param name="element"></param>
        /// <param name="documentation"></param>
        protected virtual void AddNodeDocumentation(XElement element, String documentation)
        {
            if (String.IsNullOrEmpty(documentation))
                return;
            XElement docE = element.Elements().Where(e => e.Name.LocalName == "Documentation").FirstOrDefault();
            if (docE != null) docE.Remove();
            element.AddFirst(new XElement("{{n}}Documentation".Replace("{n}", element.Name.NamespaceName),
                                          new XElement("{{n}}Summary".Replace("{n}", element.Name.NamespaceName), documentation))
                            );
        }

        /// <summary>
        /// 获取表的注释
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected abstract String GetTableDocumentation(String tableName);

        /// <summary>
        /// 获取列的注释
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        protected abstract String GetColumnDocumentation(String tableName, String columnName);
    }
}
