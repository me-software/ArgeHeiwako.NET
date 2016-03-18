using ArgeHeiwako.Data;
using ArgeHeiwako.Data.Common;
using ArgeHeiwako.IO;
using ArgeHeiwako.Tests.Data;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Xunit;

namespace ArgeHeiwako.Tests.IO
{
    [ExcludeFromCodeCoverage]
    public class OrdnungsbegriffeWriterTests
    {
        #region Write()

        [Fact]
        public void WriteTests()
        {
            byte[] content = GetWrittenBytes();
            using (var stream = new MemoryStream(content))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    Assert.Equal(CreateDefaultOrdnungsbegriffe().ToString(), streamReader.ReadLine());
                    Assert.True(streamReader.EndOfStream);
                }
            }
        }

        [Fact]
        public void Write_SingleOrdnungsbegriffe_ByteLengthEqual130()
        {
            var content = GetWrittenBytes();
            Assert.Equal(130, content.Length);
        }

        [Fact]
        public void Write_SingleOrdnungsbegriffe_SecondLastByteEqualCR()
        {
            byte[] content = GetWrittenBytes();
            Assert.Equal("\r", OrdnungsbegriffeWriter.WriterEncoding.GetString(content.Skip(128).Take(1).ToArray()));
        }

        [Fact]
        public void Write_SingleOrdnungsbegriffe_LastByteEqualLF()
        {
            byte[] content = GetWrittenBytes();
            Assert.Equal("\n", OrdnungsbegriffeWriter.WriterEncoding.GetString(content.Skip(129).Take(1).ToArray()));
        }

        [Fact]
        public void Write_AfterDispose_ThrowsObjectDisposedException()
        {
            using (var stream = new MemoryStream())
            {
                var writer = new OrdnungsbegriffeWriter(stream);
                writer.Dispose();

                var ex = Assert.Throws<ObjectDisposedException>(() => writer.Write(CreateDefaultOrdnungsbegriffe()));
                Assert.Equal("OrdnungsbegriffeWriter", ex.ObjectName);
            }
        }

        #endregion

        private Ordnungsbegriffe CreateDefaultOrdnungsbegriffe(Abrechnungsunternehmen unternehmen = null)
        {
            return new Ordnungsbegriffe(new ArgeVersion(), new KundenNummer(1), new OrdnungsbegriffAbrechnungsunternehmen(new LiegenschaftsNummer(1), new WohnungsNummer(1)), new
                OrdnungsbegriffWohnungsunternehmen("Id"), unternehmen);
        }

        internal static byte[] GetWrittenBytes()
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

    }
}
