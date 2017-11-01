using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeFileEncoding
{
    class ConvertedEventArgs : EventArgs
    {
        /// <summary>
        /// 转换结果
        /// </summary>
        public Boolean Result { get; set; }

        /// <summary>
        /// 转换的文件路径
        /// </summary>
        public String FilePath { get; set; }
    }
}
