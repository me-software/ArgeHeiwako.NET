using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class OrdnungsbegriffAbrechnungsunternehmenTests
    {
        [Fact]
        public void Ctor_IntAndShort_ToStringLength13()
        {
            var ordnungsbegriff = new OrdnungsbegriffAbrechnungsunternehmen(new LiegenschaftsNummer(12), new WohnungsNummer(1));
            Assert.Equal(13, ordnungsbegriff.ToString().Length);
        }

        [Fact]
        public void Ctor_IntAndShort_ToString_Equal0000000120001()
        {
            var ordnungsbegriff = new OrdnungsbegriffAbrechnungsunternehmen(new LiegenschaftsNummer(12), new WohnungsNummer(1));
            Assert.Equal("0000000120001", ordnungsbegriff.ToString());
        }
    }
}
