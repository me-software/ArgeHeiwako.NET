using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class BilddateiFolgeNummerTests
    {
        #region Ctor

        [Fact]
        public void Ctor_StringNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new BilddateiFolgeNummer(null));
            Assert.Equal("bilddateiFolgeNummer", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("A00")]
        [InlineData("1000")]
        [InlineData("-100")]
        public void Ctor_StringInvalidValue_ThrowsArgumentOutOfRangeException(string data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new BilddateiFolgeNummer(data));
            Assert.Equal("bilddateiFolgeNummer", ex.ParamName);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(1000)]
        public void Ctor_NumericInvalidValue_ThrowsArgumentOutOfRangeException(int data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new BilddateiFolgeNummer(data));
            Assert.Equal("bilddateiFolgeNummer", ex.ParamName);
        }

        #endregion

        #region Op_Implicit int

        [Fact]
        public void OpImplicitInt_ShortValue_ReturnsValue()
        {
            Assert.Equal(1, new BilddateiFolgeNummer(1));
        }

        [Fact]
        public void OpImplicitInt_StringValue_ReturnsValue()
        {
            Assert.Equal(1, new BilddateiFolgeNummer("001"));
        }

        #endregion

        #region ToString()

        [Theory]
        [InlineData(1, "001")]
        [InlineData(10, "010")]
        [InlineData(100, "100")]
        [InlineData(-1, "-01")]
        [InlineData(-10, "-10")]
        public void ToString_Value_ReturnsExpectedString(int value, string expectedString)
        {
            Assert.Equal(expectedString, new BilddateiFolgeNummer(value).ToString());
        }

        #endregion
    }
}
