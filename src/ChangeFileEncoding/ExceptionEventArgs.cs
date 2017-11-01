using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeFileEncoding
{
    class ExceptionEventArgs : EventArgs
    {
        /// <summary>
        /// 异常对象
        /// </summary>
        public Exception Ex { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public String Msg { get; set; }

        /// <summary>
        /// 转换的文件路径
        /// </summary>
        public String FilePath { get; set; }
    }
}
