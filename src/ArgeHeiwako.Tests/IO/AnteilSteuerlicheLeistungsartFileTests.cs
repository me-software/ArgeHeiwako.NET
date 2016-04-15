using ArgeHeiwako.Data;
using ArgeHeiwako.IO;
using ArgeHeiwako.Tests.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace ArgeHeiwako.Tests.IO
{
    public class AnteilSteuerlicheLeistungsartFileTests : FileTestsBase<AnteilSteuerlicheLeistungsartFile, AnteilSteuerlicheLeistungsart>
    {
        private AnteilSteuerlicheLeistungsartFile file;

        public AnteilSteuerlicheLeistungsartFileTests()
        {
            file = GetFileInstance();
        }

        protected override AnteilSteuerlicheLeistungsartFile GetFileInstance()
        {
            return new AnteilSteuerlicheLeistungsartFile(DateTime.Now, new List<AnteilSteuerlicheLeistungsart>());
        }

        #region FileName

        [Fact]
        public void FileName_Get_StartsWithDTE835_()
        {
            var file = GetFileInstance();
            Assert.StartsWith("DTE835305_", file.FileName);
        }

        [Fact]
        public void FileName_LengthEqual25()
        {
            var ordnungsbegriffeFile = new AnteilSteuerlicheLeistungsartFile(DateTime.Now, new List<AnteilSteuerlicheLeistungsart>());
            Assert.Equal(28, ordnungsbegriffeFile.FileName.Length);
        }

        [Fact]
        public void FileName_DatePartEqual20150101()
        {
            var ordnungsbegriffeFile = new AnteilSteuerlicheLeistungsartFile(new DateTime(2015, 1, 1), new List<AnteilSteuerlicheLeistungsart>());
            Assert.Equal("20150101", ordnungsbegriffeFile.FileName.Substring(10, 8));
        }

        [Fact]
        public void FileName_TimePartEqual161510()
        {
            var ordnungsbegriffeFile = new AnteilSteuerlicheLeistungsartFile(new DateTime(2015, 1, 1, 16, 15, 10), new List<AnteilSteuerlicheLeistungsart>());
            Assert.Equal("161510", ordnungsbegriffeFile.FileName.Substring(18, 6));
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
            

            var file = new AnteilSteuerlicheLeistungsartFile(DateTime.Now, new[] { AnteilSteuerlicheLeistungsartTests.CreateDefault() });
            var fileName = Path.Combine(Environment.CurrentDirectory, file.FileName);

            file.Write();
            Assert.Equal(135, new FileInfo(fileName).Length);
        }

        #endregion

        #region Load()

        [Fact]
        public void Load_FromStream_ReturnsAnteilSteuerlicheLeistungsartFile()
        {
            using (var stream = new MemoryStream(GetBytes()))
            {
                var file = AnteilSteuerlicheLeistungsartFile.Load(stream);
                Assert.NotNull(file);
                Assert.IsAssignableFrom<OrdnungsbegriffeFile>(file);
            }
        }

        [Fact]
        public void Load_FromStreamWithSingleRow_ReturnsAnteilSteuerlicheLeistungsartFileWithOneItem()
        {
            using (var stream = new MemoryStream(GetBytes()))
            {
                var file = AnteilSteuerlicheLeistungsartFile.Load(stream);
                Assert.NotNull(file);
                Assert.NotNull(file.Datensaetze);
                Assert.NotEmpty(file.Datensaetze);
                Assert.Equal(1, file.Datensaetze.Count());
                Assert.IsAssignableFrom<Ordnungsbegriffe>(file.Datensaetze.First());
            }
        }

        private byte[] GetBytes()
        {
            byte[] content = null;
            using (var stream = new MemoryStream())
            {
                using (var writer = new AnteilSteuerlicheLeistungsartWriter(stream))
                {
                    writer.Write(AnteilSteuerlicheLeistungsartTests.CreateDefault());
                }
                stream.Flush();
                content = stream.ToArray();
            }

            return content;
        }

        #endregion

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
