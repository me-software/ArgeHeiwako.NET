using ArgeHeiwako.Data;
using ArgeHeiwako.IO;
using ArgeHeiwako.Tests.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ArgeHeiwako.Tests.IO
{
    [ExcludeFromCodeCoverage]
    public class OrdnungsbegriffeWriterTests : ArgeWriterTestsBase<Ordnungsbegriffe, OrdnungsbegriffeWriter>
    {
        public OrdnungsbegriffeWriterTests()
            : base(128)
        {
        }
        
        public override Ordnungsbegriffe GetInstance()
        {
            return OrdnungsbegriffeTests.CreateDefault();
        }

        public override void BuildBytes(Stream stream)
        {
            using (var writer = new OrdnungsbegriffeWriter(stream))
            {
                writer.Write(GetInstance());
            }
        }

        public override OrdnungsbegriffeWriter GetWriter(Stream stream)
        {
            return new OrdnungsbegriffeWriter(stream);
        }

        public override string GetWriterName()
        {
            return nameof(OrdnungsbegriffeWriter);
        }
    }
}
