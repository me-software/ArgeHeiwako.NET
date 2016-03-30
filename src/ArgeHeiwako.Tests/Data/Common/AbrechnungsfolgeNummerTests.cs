using ArgeHeiwako.Data.Common;
using System;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    public class AbrechnungsfolgeNummerTests
    {
        #region Ctor

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AbrechnungsfolgeNummer(null));
            Assert.Equal("abrechnungsfolgeNummer", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("0")]
        [InlineData("3")]
        [InlineData("00")]
        public void Ctor_InvalidValues_ThrowsArgumentOutOfRangeException(string data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new AbrechnungsfolgeNummer(data));
            Assert.Equal("abrechnungsfolgeNummer", ex.ParamName);
        }

        #endregion

        #region ToString()

        [Theory]
        [InlineData(" ")]
        [InlineData("1")]
        [InlineData("2")]
        public void ToString_ValidValues_ReturnsString(string data)
        {
            var abrechnungsfolge = new AbrechnungsfolgeNummer(data);
            Assert.Equal(data, abrechnungsfolge.ToString());
        }

        #endregion
    }
}
