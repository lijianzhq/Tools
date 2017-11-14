using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearTempFile
{
    class ClearedEventArgs : EventArgs
    {
        /// <summary>
        /// 移除结果
        /// </summary>
        public Boolean Result { get; set; }

        /// <summary>
        /// 转换的文件路径
        /// </summary>
        public String FilePath { get; set; }
    }
}
