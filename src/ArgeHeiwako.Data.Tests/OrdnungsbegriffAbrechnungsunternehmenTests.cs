using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Data.Tests
{
    [ExcludeFromCodeCoverage]
    public class OrdnungsbegriffAbrechnungsunternehmenTests
    {
        [Fact]
        public void Ctor_IntAndShort_ToStringLength13()
        {
            var ordnungsbegriff = new OrdnungsbegriffAbrechnungsunternehmen(12, 1);
            Assert.Equal(13, ordnungsbegriff.ToString().Length);
        }

        [Fact]
        public void Ctor_IntAndShort_ToString_Equal0000000120001()
        {
            var ordnungsbegriff = new OrdnungsbegriffAbrechnungsunternehmen(12, 1);
            Assert.Equal("0000000120001", ordnungsbegriff.ToString());
        }
    }
}
