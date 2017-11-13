using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

using Common;
using DreamCube.Foundation.Log;

namespace ClearOfficeTempFile
{
    class ClearOfficeTempFileOperator : FileOperator
    {
        public event EventHandler<ClearedEventArgs> Converted;

        public String Path { get; protected set; }

        public ClearOfficeTempFileOperator(String path)
        {
            this.Path = path;
        }

        public async Task<IEnumerable<String>> GetAllFilesAsync()
        {
            return await this.GetAllFilesAsync(this.Path, "*");
        }
    }
}
