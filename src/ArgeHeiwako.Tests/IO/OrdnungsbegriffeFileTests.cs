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
    public class OrdnungsbegriffeFileTests : FileTestsBase<OrdnungsbegriffeFile, Ordnungsbegriffe>
    {
        private DateTime creationDate;
        private OrdnungsbegriffeFile file;

        public OrdnungsbegriffeFileTests()
        {
            creationDate = DateTime.Now;
            file = new OrdnungsbegriffeFile(creationDate, new List<Ordnungsbegriffe>());
        }

        #region Ctor


        [Fact]
        public void Ctor_DateTime_CreatedEqualsDateTime()
        {
            var dateTime = DateTime.Now;
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(dateTime, new List<Ordnungsbegriffe>());
            Assert.Equal(dateTime, ordnungsbegriffeFile.Created);
        }
        
        #endregion

        #region FileName

        [Fact]
        public void FileName_StartsWithDTA305()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(DateTime.Now, new List<Ordnungsbegriffe>());
            Assert.StartsWith("DTA305_", ordnungsbegriffeFile.FileName);
        }

        [Fact]
        public void FileName_LengthEqual25()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(DateTime.Now, new List<Ordnungsbegriffe>());
            Assert.Equal(25, ordnungsbegriffeFile.FileName.Length);
        }

        [Fact]
        public void FileName_DatePartEqual20150101()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(new DateTime(2015, 1, 1), new List<Ordnungsbegriffe>());
            Assert.Equal("20150101", ordnungsbegriffeFile.FileName.Substring(7, 8));
        }

        [Fact]
        public void FileName_TimePartEqual161510()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(new DateTime(2015, 1, 1, 16, 15, 10), new List<Ordnungsbegriffe>());
            Assert.Equal("161510", ordnungsbegriffeFile.FileName.Substring(15, 6));
        }

        #endregion

        #region Write()

        [Fact]
        public void Write_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => file.Write(null));
            Assert.Equal("directory", ex.ParamName);
        }

        [Fact]
        public void Write_WithEmptyListOfOrdnungsbegriffen_CreatesFileInCurrentDirectory()
        {
            file.Write();
            var fileName = Path.Combine(Environment.CurrentDirectory, file.FileName);
            AddFile(fileName);

            Assert.True(File.Exists(fileName));
        }

        [Fact]
        public void Write_ListWithOneItem_CreatesFileInDirectory()
        {
            var directory = Path.Combine(Environment.CurrentDirectory, "test");
            var fileName = Path.Combine(directory, file.FileName);

            file.Write(directory);
            AddFile(fileName);

            Assert.True(File.Exists(fileName));
        }

        [Fact]
        public void Write_ListWithOneItem_FileSizeEquals130()
        {
            var file = new OrdnungsbegriffeFile(DateTime.Now, new[] { OrdnungsbegriffeTests.CreateDefault() });
            file.Write();
            Assert.Equal(130, new FileInfo(Path.Combine(Environment.CurrentDirectory, file.FileName)).Length);
        }

        #endregion

        #region Load()

        [Fact]
        public void Load_FromStream_ReturnsOrdnungsbegriffeFile()
        {
            using (var stream = new MemoryStream(GetBytes()))
            {
                var file = OrdnungsbegriffeFile.Load(stream);
                Assert.NotNull(file);
                Assert.IsAssignableFrom<OrdnungsbegriffeFile>(file);
            }
        }

        [Fact]
        public void Load_FromStreamWithSingleRow_ReturnsOrdnungsbegriffeFileWithOneItem()
        {
            using (var stream = new MemoryStream(GetBytes()))
            {
                var file = OrdnungsbegriffeFile.Load(stream);
                Assert.NotNull(file);
                Assert.NotNull(file.Datensaetze);
                Assert.NotEmpty(file.Datensaetze);
                Assert.Equal(1, file.Datensaetze.Count());
                Assert.IsAssignableFrom<Ordnungsbegriffe>(file.Datensaetze.First());
            }
        }

        #endregion

        private byte[] GetBytes()
        {
            byte[] content = null;
            using (var stream = new MemoryStream())
            {
                using (var writer = new OrdnungsbegriffeWriter(stream))
                {
                    writer.Write(OrdnungsbegriffeTests.CreateDefault());
                }
                stream.Flush();
                content = stream.ToArray();
            }

            return content;
        }

        protected override OrdnungsbegriffeFile GetFileInstance()
        {
            return new OrdnungsbegriffeFile(DateTime.Now, new List<Ordnungsbegriffe>());
        }


        public override void Dispose()
        {
            base.Dispose();

            var fileName = Path.Combine(Environment.CurrentDirectory, file.FileName);
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

    }
}
