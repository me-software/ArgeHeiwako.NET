using ArgeHeiwako.Data;
using ArgeHeiwako.IO;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using ArgeHeiwako.Tests.Data;

namespace ArgeHeiwako.Tests.IO
{
    [ExcludeFromCodeCoverage]
    public class NutzerAbrechnungBildWriterTests : ArgeWriterTestsBase<NutzerAbrechnungBild, NutzerAbrechnungBildWriter>
    {
        public NutzerAbrechnungBildWriterTests() 
            : base(120)
        {
        }

        public override void BuildBytes(Stream stream)
        {
            using (var writer = new NutzerAbrechnungBildWriter(stream))
            {
                writer.Write(GetInstance());
            }
        }

        public override NutzerAbrechnungBild GetInstance()
        {
            return NutzerAbrechnungBildTests.CreateDefault();
        }

        public override NutzerAbrechnungBildWriter GetWriter(Stream stream)
        {
            return new NutzerAbrechnungBildWriter(stream);
        }

        public override string GetWriterName()
        {
            return nameof(NutzerAbrechnungBildWriter);
        }
    }
}
