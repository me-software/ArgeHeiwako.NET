using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class AnteilTests
    {
        #region Ctor

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Anteil(null));
            Assert.Equal("anteil", ex.ParamName);
        }

        [Fact]
        public void Ctor_EmptyString_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Anteil(string.Empty));
            Assert.Equal("anteil", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringLength9_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Anteil(new string('0', 8)));
            Assert.Equal("anteil", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringLength11_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Anteil(new string('0', 10)));
            Assert.Equal("anteil", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringNotNumericCorrectLength_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Anteil(new string('A', 9)));
            Assert.Equal("anteil", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringNumeric000000000_CreatesInstance()
        {
            Assert.NotNull(new Anteil(new string('0', 9)));
        }

        [Fact]
        public void Ctor_Number10000000Dot01_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Anteil(1000000.001M));
            Assert.Equal("anteil", ex.ParamName);
        }

        [Fact]
        public void Ctor_Number0_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Anteil(-100000.000M));
            Assert.Equal("anteil", ex.ParamName);
        }

        [Fact]
        public void Ctor_Number0_CreatesInstance()
        {
            Assert.NotNull(new Anteil(0));
        }

        #endregion

        #region ToString()

        [Theory]
        [InlineData("-00000001", -.001)]
        [InlineData("-00001000", -1)]
        [InlineData("000000001", .001)]
        [InlineData("000000010", .01)]
        [InlineData("000000100", .1)]
        [InlineData("000000000", 0)]
        [InlineData("000001000", 1)]
        [InlineData("000010000", 10)]
        [InlineData("000100000", 100)]
        [InlineData("001000000", 1000)]
        [InlineData("010000000", 10000)]
        [InlineData("100000000", 100000)]
        public void ToString_Data_ReturnsExpectedStringValue(string expectedValue, decimal data)
        {
            Assert.Equal(expectedValue, new Anteil(data).ToString());
        }

        #endregion

        #region op_Implicit_Decimal

        [Theory]
        [InlineData(1, "000001000")]
        [InlineData(.1, "000000100")]
        [InlineData(.001, "000000001")]
        [InlineData(10, "000010000")]
        [InlineData(100, "000100000")]
        [InlineData(1000, "001000000")]
        [InlineData(10000, "010000000")]
        [InlineData(100000, "100000000")]
        public void OpImplicit_StringValue_ReturnsExpectedValue(decimal expectedValue, string data)
        {
            Assert.Equal(expectedValue, new Anteil(data));
        }

        #endregion
    }
}
