using ArgeHeiwako.Data;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class KundenNummerTests
    {
        [Fact]
        public void CtorInt1_ToString_Length10()
        {
            var kundenNummer = new KundenNummer(1);
            Assert.Equal(10, kundenNummer.ToString().Length);
        }

        [Fact]
        public void CtorInt1_ToString_Equal0000000001()
        {
            var kundenNummer = new KundenNummer(1);
            Assert.Equal("0000000001", kundenNummer.ToString());
        }

        [Fact]
        public void CtorInt9999999999_ToString_Equal9999999999()
        {
            var kundenNummer = new KundenNummer(9999999999);
            Assert.Equal("9999999999", kundenNummer.ToString());
        }

        [Fact]
        public void CtorInt10000000000_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new KundenNummer(10000000000));
        }
    }
}
