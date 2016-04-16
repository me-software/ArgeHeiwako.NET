using ArgeHeiwako.Data;
using ArgeHeiwako.IO;
using ArgeHeiwako.Tests.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System;

namespace ArgeHeiwako.Tests.IO
{
    [ExcludeFromCodeCoverage]
    public class AnteilSteuerlicheLeistungsartWriterTests : ArgeWriterTestsBase<AnteilSteuerlicheLeistungsart, AnteilSteuerlicheLeistungsartWriter>
    {
        public AnteilSteuerlicheLeistungsartWriterTests() 
            : base(135)
        {
        }

        public override void BuildBytes(Stream stream)
        {
            using (var writer = new AnteilSteuerlicheLeistungsartWriter(stream))
            {
                writer.Write(GetInstance());
            }
        }

        public override AnteilSteuerlicheLeistungsart GetInstance()
        {
            return AnteilSteuerlicheLeistungsartTests.CreateDefault();
        }

        public override AnteilSteuerlicheLeistungsartWriter GetWriter(Stream stream)
        {
            return new AnteilSteuerlicheLeistungsartWriter(stream);
        }

        public override string GetWriterName()
        {
            return nameof(AnteilSteuerlicheLeistungsartWriter);
        }
    }
}
