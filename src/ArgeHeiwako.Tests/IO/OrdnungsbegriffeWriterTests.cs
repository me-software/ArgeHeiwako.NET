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
    public class OrdnungsbegriffeWriterTests : ArgeWriterTestsBase<Ordnungsbegriffe>
    {
        public OrdnungsbegriffeWriterTests()
            : base(130)
        {
        }
        #region Write()

        [Fact]
        public void WriteTests()
        {
            byte[] content = GetBytes();
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

        public override byte[] GetBytes()
        {
            byte[] content = null;
            using (var stream = new MemoryStream())
            {
                using (var writer = new OrdnungsbegriffeWriter(stream))
                {
                    writer.Write(GetInstance());
                }
                stream.Flush();
                content = stream.ToArray();
            }

            return content;
        }

        public override Ordnungsbegriffe GetInstance()
        {
            return OrdnungsbegriffeTests.CreateDefault();
        }
    }
}
