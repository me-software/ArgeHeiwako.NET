using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class BetragTests
    {
        public BetragTests()
        {
        }

        #region Ctor

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Betrag(null));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_EmptyString_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Betrag(string.Empty));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringLength9_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Betrag(new string('0', 9)));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringLength11_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Betrag(new string('0', 11)));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringNotNumericCorrectLength_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Betrag(new string('A', 10)));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_Number10000000Dot01_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Betrag(100000000.01M));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_Number0_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Betrag(-10000000.00M));
            Assert.Equal("betrag", ex.ParamName);
        }

        #endregion

        #region ToString()

        [Theory]
        [InlineData("-000000001", -.01)]
        [InlineData("-000000100", -1)]
        [InlineData("0000000001", .01)]
        [InlineData("0000000010", .1)]
        [InlineData("0000000000", 0)]
        [InlineData("0000000100", 1)]
        [InlineData("0000001000", 10)]
        [InlineData("0000010000", 100)]
        [InlineData("0000100000", 1000)]
        [InlineData("0001000000", 10000)]
        [InlineData("0010000000", 100000)]
        [InlineData("0100000000", 1000000)]
        [InlineData("1000000000", 10000000)]
        public void ToString_Data_ReturnsExpectedStringValue(string expectedValue, decimal data)
        {
            Assert.Equal(expectedValue, new Betrag(data).ToString());
        }

        #endregion

        #region op_Implicit_Decimal

        [Theory]
        [InlineData(1, "0000000100")]
        [InlineData(.1, "0000000010")]
        [InlineData(.01, "0000000001")]
        [InlineData(10, "0000001000")]
        [InlineData(100, "0000010000")]
        [InlineData(1000, "0000100000")]
        [InlineData(10000, "0001000000")]
        [InlineData(100000, "0010000000")]
        [InlineData(1000000, "0100000000")]
        [InlineData(10000000, "1000000000")]
        public void OpImplicit_StringValue_ReturnsExpectedValue(decimal expectedValue, string data)
        {
            Assert.Equal(expectedValue, new Betrag(data));
        }

        #endregion
    }
}
