using ArgeHeiwako.Data.Common;
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
        public void CtorIntMinus999999999_ToString_Equal9999999999()
        {
            var kundenNummer = new KundenNummer(-999999999);
            Assert.Equal("-999999999", kundenNummer.ToString());
        }

        [Fact]
        public void CtorIntMinus100000000_ToString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new KundenNummer(-1000000000));
        }

        [Fact]
        public void CtorIntMinus1_ToString_EqualMinus000000001()
        {
            var kundenNummer = new KundenNummer(-1);
            Assert.Equal("-000000001", kundenNummer.ToString());
        }

        [Fact]
        public void CtorInt10000000000_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new KundenNummer(10000000000));
        }

        [Fact]
        public void Ctor_StringNotNumeric_ThrowsArgumentExcepton()
        {
            Assert.Throws<ArgumentException>(() => new KundenNummer("Test"));
        }

        [Fact]
        public void Ctor_StringNull_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new KundenNummer(null));
            Assert.Equal("nummer", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringEmpty_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new KundenNummer(string.Empty));
            Assert.Equal("nummer", ex.ParamName);
            Assert.StartsWith(ArgeHeiwako.Data.Properties.Resources.EXP_MSG_VALID_KUNDENNUMMER_LENGTH, ex.Message);
        }

        [Fact]
        public void Ctor_StringNumeric0000000001_ToStringEquals0000000001()
        {
            Assert.Equal("0000000001", new KundenNummer("0000000001").ToString());
        }
    }
}
