using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgeHeiwako.Tests.IO
{
    [ExcludeFromCodeCoverage]
    public class FileCreationTestBase : IDisposable
    {
        private List<string> filesCreated;

        public FileCreationTestBase()
        {
            filesCreated = new List<string>();
        }

        protected void AddFile(string fileName)
        {
            filesCreated.Add(fileName);
        }

        public virtual void Dispose()
        {
            foreach(var file in filesCreated)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
