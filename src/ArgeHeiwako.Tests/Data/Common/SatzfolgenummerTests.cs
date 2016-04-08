using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class SatzfolgenummerTests
    {
        #region Ctor

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Satzfolgenummer(null));
            Assert.Equal("satzfolgenummer", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("000000")]
        [InlineData("00000000")]
        [InlineData("AAAAAAA")]
        public void Ctor_IncorrectString_ThrowsArgumentOutOfRangeException(string data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Satzfolgenummer(data));
            Assert.Equal("satzfolgenummer", ex.ParamName);
        }

        [Theory]
        [InlineData(10000000)]
        [InlineData(-1000000)]
        public void Ctor_IntOutOfRange_ThrowsArgumentOutOfRangeException(int data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Satzfolgenummer(data));
            Assert.Equal("satzfolgenummer", ex.ParamName);
        }

        #endregion

        #region Op_Implicit Int

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void OpImplicitInt_ReturnsValue(int data)
        {
            Assert.Equal(data, new Satzfolgenummer(data));
        }

        [Theory]
        [InlineData("0000001", 1)]
        [InlineData("-000001", -1)]
        public void OpImplicitInt_StringValue_ReturnsIntValue(string data, int value)
        {
            Assert.Equal(value, new Satzfolgenummer(data));
        }
        #endregion

        #region ToString()

        [Theory]
        [InlineData(1, "0000001")]
        [InlineData(-1, "-000001")]
        public void ToString_ValueReturnsCorrectString(int value, string valueString)
        {
            Assert.Equal(valueString, new Satzfolgenummer(value).ToString());
        }

        #endregion
    }
}
