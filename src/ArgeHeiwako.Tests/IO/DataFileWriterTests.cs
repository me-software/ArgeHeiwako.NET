using ArgeHeiwako.Data;
using ArgeHeiwako.IO;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Xunit;

namespace ArgeHeiwako.Tests.IO
{
    [ExcludeFromCodeCoverage]
    public class DataFileWriterTests
    {
        [Fact]
        public void WriteTests()
        {
            byte[] content = null;
            using (var stream = new MemoryStream())
            {
                using (var writer = new DataFileWriter(stream))
                {
                    writer.Write(CreateDefaultOrdnungsbegriffe());
                }
                stream.Flush();
                content = stream.ToArray();
            }

            using (var stream = new MemoryStream(content))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    Assert.Equal(CreateDefaultOrdnungsbegriffe().ToString(), streamReader.ReadLine());
                    Assert.True(streamReader.EndOfStream);
                }
            }
        }

        private Ordnungsbegriffe CreateDefaultOrdnungsbegriffe(Abrechnungsunternehmen unternehmen = null)
        {
            return new Ordnungsbegriffe(new ArgeVersion(), new KundenNummer(1), new OrdnungsbegriffAbrechnungsunternehmen(1, 1), new
                OrdnungsbegriffWohnungsunternehmen("Id"), unternehmen);
        }
    }
}
