using ArgeHeiwako.Data;
using System;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    public class LiegenschaftsNummerTests
    {
        public LiegenschaftsNummerTests()
        {
        }

        #region Ctor

        [Fact]
        public void Ctor_Int0_Liegenschaftsnummer0()
        {
            var liegenschaftsnummer = new LiegenschaftsNummer(0);
            Assert.Equal(0, liegenschaftsnummer);
        }

        [Fact]
        public void Ctor_Int999999999_Liegenschaftsnummer999999999()
        {
            var liegenschaftsnummer = new LiegenschaftsNummer(999999999);
            Assert.Equal(999999999, liegenschaftsnummer);
        }

        [Fact]
        public void Ctor_Int1000000000_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new LiegenschaftsNummer(1000000000));
            Assert.Equal("liegenschaftsnummer", ex.ParamName);
        }

        [Fact]
        public void Ctor_IntMinus99999999_LiegenschaftsnummerMinus99999999()
        {
            var liegenschaftsnummer = new LiegenschaftsNummer(-99999999);
            Assert.Equal(-99999999, liegenschaftsnummer);
        }

        [Fact]
        public void Ctor_IntMinus100000000_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new LiegenschaftsNummer(-100000000));
            Assert.Equal("liegenschaftsnummer", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new LiegenschaftsNummer(null));
            Assert.Equal("liegenschaftsnummer", ex.ParamName);
        }

        [Fact]
        public void Ctor_String0_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new LiegenschaftsNummer("0"));
            Assert.Equal("liegenschaftsnummer", ex.ParamName);
            Assert.StartsWith("Eine valide Liegenschaftsnummer besteht aus 9 Ziffern.", ex.Message);
        }

        [Fact]
        public void Ctor_String0000000000_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new LiegenschaftsNummer("0000000000"));
            Assert.Equal("liegenschaftsnummer", ex.ParamName);
            Assert.StartsWith("Eine valide Liegenschaftsnummer besteht aus 9 Ziffern.", ex.Message);
        }

        [Fact]
        public void Ctor_StringA00000000_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>  new LiegenschaftsNummer("A00000000"));
            Assert.Equal("liegenschaftsnummer", ex.ParamName);
            Assert.StartsWith("Eine valide Liegenschaftsnummer besteht aus 9 Ziffern.", ex.Message);
        }

        [Fact]
        public void Ctor_String000000000_ThrowsArgumentException()
        {
            var liegenschaftsnummer = new LiegenschaftsNummer("000000000");
            Assert.Equal(0, liegenschaftsnummer);
        }

        #endregion

        #region ToString()

        [Fact]
        public void ToString_0_Equal000000000()
        {
            Assert.Equal("000000000", new LiegenschaftsNummer(0).ToString());
        }

        [Fact]
        public void ToString_Minus1_EqualMinus00000001()
        {
            Assert.Equal("-00000001", new LiegenschaftsNummer(-1).ToString());
        }
        
        [Fact]
        public void ToString_9_EqualMinus00000009()
        {
            Assert.Equal("000000009", new LiegenschaftsNummer(9).ToString());
        }

        #endregion
    }
}
