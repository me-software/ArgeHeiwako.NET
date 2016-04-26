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
    public class NutzerAbrechnungBildFileTests : FileTestsBase<NutzerAbrechnungBildFile, NutzerAbrechnungBild>
    {
        private NutzerAbrechnungBildFile file;

        public NutzerAbrechnungBildFileTests()
        {
            file = GetEmptyFileInstance();
        }

        protected override NutzerAbrechnungBildFile GetEmptyFileInstance()
        {
            var dateTime = new DateTime(2016, 12, 31, 16, 15, 00);
            return new NutzerAbrechnungBildFile(dateTime, new List<NutzerAbrechnungBild>());
        }

        #region FileName

        [Fact]
        public void FileName_Get_StartsWithDTE898_()
        {
            var file = GetEmptyFileInstance();
            Assert.StartsWith("DTE898_", file.FileName);
        }

        [Fact]
        public void FileName_LengthEqual25()
        {
            var ordnungsbegriffeFile = new NutzerAbrechnungBildFile(DateTime.Now, new List<NutzerAbrechnungBild>());
            Assert.Equal(25, ordnungsbegriffeFile.FileName.Length);
        }

        [Fact]
        public void FileName_DatePartEqual20150101()
        {
            var ordnungsbegriffeFile = new NutzerAbrechnungBildFile(new DateTime(2015, 1, 1), new List<NutzerAbrechnungBild>());
            Assert.Equal("20150101", ordnungsbegriffeFile.FileName.Substring(7, 8));
        }

        [Fact]
        public void FileName_TimePartEqual161510()
        {
            var ordnungsbegriffeFile = new NutzerAbrechnungBildFile(new DateTime(2015, 1, 1, 16, 15, 10), new List<NutzerAbrechnungBild>());
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
        public void Write_EmptyRows_CreatesFileInCurrentDirectory()
        {
            file.Write();
            var fileName = Path.Combine(Environment.CurrentDirectory, file.FileName);
            AddFile(fileName);

            Assert.True(File.Exists(fileName));
        }

        [Fact]
        public void Write_EmptyRows_CreatesFileInDirectory()
        {
            var directory = Path.Combine(Environment.CurrentDirectory, "test");
            var fileName = Path.Combine(directory, file.FileName);

            file.Write(directory);
            AddFile(fileName);

            Assert.True(File.Exists(fileName));
        }

        [Fact]
        public void Write_SingleInstance_FileSizeEquals130()
        {
            var file = new NutzerAbrechnungBildFile(
                DateTime.Now,
                new[] { NutzerAbrechnungBildTests.CreateDefault() });
            var fileName = Path.Combine(Environment.CurrentDirectory, file.FileName);

            file.Write();
            Assert.Equal(122, new FileInfo(fileName).Length);
        }

        #endregion

        #region Load()

        [Fact]
        public void Load_FromStream_ReturnsAnteilSteuerlicheLeistungsartFile()
        {
            using (var stream = new MemoryStream(GetBytes()))
            {
                var file = NutzerAbrechnungBildFile.Load(stream);
                Assert.NotNull(file);
                Assert.IsAssignableFrom<NutzerAbrechnungBildFile>(file);
            }
        }

        [Fact]
        public void Load_FromStreamWithSingleRow_ReturnsAnteilSteuerlicheLeistungsartFileWithOneItem()
        {
            using (var stream = new MemoryStream(GetBytes()))
            {
                var file = NutzerAbrechnungBildFile.Load(stream);
                Assert.NotNull(file);
                Assert.NotNull(file.Datensaetze);
                Assert.NotEmpty(file.Datensaetze);
                Assert.Equal(1, file.Datensaetze.Count());
                Assert.IsAssignableFrom<NutzerAbrechnungBild>(file.Datensaetze.First());
            }
        }

        private byte[] GetBytes()
        {
            byte[] content = null;
            using (var stream = new MemoryStream())
            {
                using (var writer = new NutzerAbrechnungBildWriter(stream))
                {
                    writer.Write(NutzerAbrechnungBildTests.CreateDefault());
                }
                stream.Flush();
                content = stream.ToArray();
            }

            return content;
        }

        #endregion
    }
}
