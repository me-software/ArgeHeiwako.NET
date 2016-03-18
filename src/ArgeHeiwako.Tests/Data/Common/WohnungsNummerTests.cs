using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class WohnungsNummerTests
    {
        public WohnungsNummerTests()
        {
        }

        #region Ctor

        [Fact]
        public void Ctor_Int0_Liegenschaftsnummer0()
        {
            var wohnungsnummer = new WohnungsNummer(0);
            Assert.Equal(0, wohnungsnummer);
        }

        [Fact]
        public void Ctor_Int9999_Liegenschaftsnummer9999()
        {
            var liegenschaftsnummer = new WohnungsNummer(9999);
            Assert.Equal(9999, liegenschaftsnummer);
        }

        [Fact]
        public void Ctor_Int10000_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new WohnungsNummer(10000));
            Assert.Equal("wohnungsnummer", ex.ParamName);
            Assert.StartsWith("Eine valide Wohnungsnummer besteht aus 4 Ziffern.", ex.Message);
        }

        [Fact]
        public void Ctor_IntMinus999_LiegenschaftsnummerMinus999()
        {
            var liegenschaftsnummer = new WohnungsNummer(-999);
            Assert.Equal(-999, liegenschaftsnummer);
        }

        [Fact]
        public void Ctor_IntMinus100000000_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new WohnungsNummer(-1000));
            Assert.Equal("wohnungsnummer", ex.ParamName);
            Assert.StartsWith("Eine valide Wohnungsnummer besteht aus 4 Ziffern.", ex.Message);
        }

        [Fact]
        public void Ctor_StringNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new WohnungsNummer(null));
            Assert.Equal("wohnungsnummer", ex.ParamName);
            Assert.StartsWith("Eine valide Wohnungsnummer besteht aus 4 Ziffern.", ex.Message);
        }

        [Fact]
        public void Ctor_String0_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new WohnungsNummer("0"));
            Assert.Equal("wohnungsnummer", ex.ParamName);
            Assert.StartsWith("Eine valide Wohnungsnummer besteht aus 4 Ziffern.", ex.Message);
        }

        [Fact]
        public void Ctor_String00000_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new WohnungsNummer("00000"));
            Assert.Equal("wohnungsnummer", ex.ParamName);
            Assert.StartsWith("Eine valide Wohnungsnummer besteht aus 4 Ziffern.", ex.Message);
        }

        [Fact]
        public void Ctor_StringA000_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new WohnungsNummer("A000"));
            Assert.Equal("wohnungsnummer", ex.ParamName);
            Assert.StartsWith("Eine valide Wohnungsnummer besteht aus 4 Ziffern.", ex.Message);
        }

        [Fact]
        public void Ctor_String000000000_ThrowsArgumentException()
        {
            var liegenschaftsnummer = new WohnungsNummer("0000");
            Assert.Equal(0, liegenschaftsnummer);
        }

        #endregion

        #region ToString()

        [Fact]
        public void ToString_0_Equal0000()
        {
            Assert.Equal("0000", new WohnungsNummer(0).ToString());
        }

        [Fact]
        public void ToString_Minus1_EqualMinus00000001()
        {
            Assert.Equal("-001", new WohnungsNummer(-1).ToString());
        }

        [Fact]
        public void ToString_9_EqualMinus00000009()
        {
            Assert.Equal("0009", new WohnungsNummer(9).ToString());
        }

        #endregion
    }
}
