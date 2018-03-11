using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveSRFromCode
{
    public class CodeFileOperator
    {
        /// <summary>
        /// 移除符号
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public String RemoveSRCode(String fileData)
        {
            if (String.IsNullOrEmpty(fileData)) return fileData;
            String startData = "SR.GetString(";
            Int32 startIndex = fileData.IndexOf(startData, 0);
            Int32 endIndex = 0;
            while (startIndex >= 0)
            {
                //在前面加双引号
                fileData = fileData.Insert(startIndex, "\"");
                Int32 rightBracketsCount = 0;
                endIndex = startIndex + (startData.Length - 1) + 1 + 1;//+1是因为插入了一个双引符号，再+1从下一个字符串开始
                while (fileData[endIndex] != ')' || rightBracketsCount != 0)
                {
                    char nextChar = fileData[endIndex];
                    if (nextChar == '(')//遇到一个左括号则继续嵌套标识符+1;
                        rightBracketsCount++;
                    else if (nextChar == ')')
                        rightBracketsCount--; //遇到一个右括号，则继续嵌套标识符-1
                    endIndex++;
                }
                //endIndex = fileData.IndexOf(")", startIndex);
                //在后面加双引号
                fileData = fileData.Insert(endIndex + 1, "\"");
                //从结束符开始下一个搜索位置
                startIndex = fileData.IndexOf("SR.GetString(", endIndex);
            }
            return fileData;
        }
    }
}
