using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class TagTests
    {
        public TagTests()
        {
        }

        #region Ctor

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Tag(null));
            Assert.Equal("tag", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("0")]
        [InlineData("01010")]
        [InlineData("0101001")]
        [InlineData("AAAAAA")]
        [InlineData("320101")]
        [InlineData("011301")]
        public void Ctor_StringValues_ThrowsArgumentException(string data)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Tag(data));
        }

        #endregion

        #region ToString()

        [Theory]
        [InlineData(01, 01, 01, "010101")]
        public void ToString_Data_ReturnsExpectedValue(int day, int month, int year, string expectedValue)
        {
            Assert.Equal(expectedValue, new Tag(new DateTime(year, month, day)).ToString());
        }

        #endregion

        #region op_Implicit_DateTime

        [Fact]
        public void OpImplicit_DateTimeWithoutTimePart_ReturnsSameValue()
        {
            var date = new DateTime(2012, 12, 31);
            Assert.Equal(date, new Tag(date));
        }

        [Fact]
        public void OpImplicit_DateTimeWithTimePart_ReturnsSameValue()
        {
            var date = new DateTime(2012, 12, 31, 16, 00 , 59);
            Assert.Equal(date.Date, new Tag(date));
        }

        #endregion
    }
}
