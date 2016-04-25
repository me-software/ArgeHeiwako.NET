using ArgeHeiwako.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Xunit;

namespace ArgeHeiwako.Tests.IO
{
    [ExcludeFromCodeCoverage]
    public abstract class FileTestsBase<TFile, TData> : IDisposable
        where TFile : IArgeFile<TData>
    {
        private List<string> filesCreated;

        public FileTestsBase()
        {
            filesCreated = new List<string>();
        }

        protected abstract TFile GetEmptyFileInstance();

        protected void AddFile(string fileName)
        {
            filesCreated.Add(fileName);
        }

        public virtual void Dispose()
        {
            foreach (var file in filesCreated)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
        }

        #region Ctor
        [Fact]
        public void Ctor_Default_DatensaetzeReturnsEmptyCollection()
        {
            var file = GetEmptyFileInstance();
            Assert.Empty(file.Datensaetze);
        }
        
        #endregion

        #region FileName

        [Fact]
        public void FileName_StartsWithDT()
        {
            var file = GetEmptyFileInstance();
            Assert.StartsWith("DT", file.FileName);
        }

        [Fact]
        public void FileName_ExtensionDotDAT()
        {
            var file = GetEmptyFileInstance();
            Assert.EndsWith(".DAT", file.FileName);
        }

        #endregion
    }
}
