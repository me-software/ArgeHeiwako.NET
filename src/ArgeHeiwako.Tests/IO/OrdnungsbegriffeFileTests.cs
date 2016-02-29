using ArgeHeiwako.Data;
using ArgeHeiwako.IO;
using ArgeHeiwako.Tests.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Xunit;

namespace ArgeHeiwako.Tests.IO
{
    [ExcludeFromCodeCoverage]
    public class OrdnungsbegriffeFileTests : IDisposable
    {
        private DateTime creationDate;
        private OrdnungsbegriffeFile file;

        public OrdnungsbegriffeFileTests()
        {
            creationDate = DateTime.Now;
            file = new OrdnungsbegriffeFile(creationDate);
        }

        #region Ctor

        [Fact]
        public void Ctor_DateTime_CreatedEqualsDateTime()
        {
            var dateTime = DateTime.Now;
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(dateTime);
            Assert.Equal(dateTime, ordnungsbegriffeFile.Created);
        }

        #endregion

        #region FileName

        [Fact]
        public void FileName_StartsWithDTA305()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(DateTime.Now);
            Assert.StartsWith("DTA305_", ordnungsbegriffeFile.FileName);
        }

        [Fact]
        public void FileName_ExtensionDotDAT()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(DateTime.Now);
            Assert.EndsWith(".DAT", ordnungsbegriffeFile.FileName);
        }

        [Fact]
        public void FileName_LengthEqual25()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(DateTime.Now);
            Assert.Equal(25, ordnungsbegriffeFile.FileName.Length);
        }

        [Fact]
        public void FileName_DatePartEqual20150101()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(new DateTime(2015, 1, 1));
            Assert.Equal("20150101", ordnungsbegriffeFile.FileName.Substring(7, 8));
        }

        [Fact]
        public void FileName_TimePartEqual161510()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(new DateTime(2015, 1, 1, 16, 15, 10));
            Assert.Equal("161510", ordnungsbegriffeFile.FileName.Substring(15, 6));
        }

        #endregion

        #region Write()

        [Fact]
        public void Write_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => file.Write(null));
        }

        [Fact]
        public void Write_Null_ThrowsArgumentNullExceptionParamNameBegriffe()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => file.Write(null));
            Assert.Equal("ordnungsbegriffe", ex.ParamName);
        }

        [Fact]
        public void Write_WithEmptyListOfOrdnungsbegriffen_CreatesFileInCurrentDirectory()
        {
            file.Write(new List<Ordnungsbegriffe>());
            Assert.True(File.Exists(Path.Combine(Environment.CurrentDirectory, file.FileName)));
        }

        [Fact]
        public void Write_ListWithOneItem_CreatesFileInCurrentDirectory()
        {
            file.Write(new[] { OrdnungsbegriffeTests.CreateDefault() });
            Assert.True(File.Exists(Path.Combine(Environment.CurrentDirectory, file.FileName)));
        }

        [Fact]
        public void Write_ListWithOneItem_FileSizeEquals130()
        {
            file.Write(new[] { OrdnungsbegriffeTests.CreateDefault() });
            Assert.Equal(130, new FileInfo(Path.Combine(Environment.CurrentDirectory, file.FileName)).Length);
        }

        public void Dispose()
        {
            if (File.Exists(file.FileName))
            {
                File.Delete(file.FileName);
            }
        }

        #endregion

        #region Load()

        ////public void Load_FromStream_ReturnsOrdnungsbegriffeFile()
        ////{
        ////    using (var stream = new MemoryStream(OrdnungsbegriffeWriterTests.GetWrittenBytes()))
        ////    {
        ////        var file = OrdnungsbegriffeFile.Load(stream);
        ////        Assert.NotNull(file);
        ////        Assert.IsAssignableFrom<OrdnungsbegriffeFile>(file);
        ////    }
        ////}

        ////[Fact]
        ////public void Load_FromStreamWithSingleRow_ReturnsOrdnungsbegriffeFileWithOneItem()
        ////{
        ////    using (var stream = new MemoryStream(OrdnungsbegriffeWriterTests.GetWrittenBytes()))
        ////    {
        ////        var file = OrdnungsbegriffeFile.Load(stream);
        ////        Assert.NotNull(file);
        ////        Assert.NotNull(file.Ordnungsbegriffe);
        ////        Assert.NotEmpty(file.Ordnungsbegriffe);
        ////        Assert.Equal(1, file.Ordnungsbegriffe.Count());
        ////        Assert.IsAssignableFrom<Ordnungsbegriffe>(file.Ordnungsbegriffe.First());
        ////    }
        ////}

        #endregion
    }
}
