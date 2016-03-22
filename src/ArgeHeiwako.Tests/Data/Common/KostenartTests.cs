using ArgeHeiwako.Data.Common;
using System;
using System.Collections.Generic;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    public class KostenartTests
    {
        public KostenartTests()
        {
        }

        #region Find()

        [Fact]
        public void Finde_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Kostenart.Finde(null));
            Assert.Equal("schluessel", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("0")]
        [InlineData("00")]
        [InlineData("0000")]
        [InlineData("00A")]
        public void Finde_WithIncorrectString_ThrowsArgumentOutOfRangeException(string data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Kostenart.Finde(data));
            Assert.Equal("schluessel", ex.ParamName);
        }

        [Fact]
        public void Finde_WithNotRegisteredKey_ThrowsKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() => Kostenart.Finde("000"));
        }

        [Theory]
        [InlineData("228")]
        [InlineData("242")]
        [InlineData("254")]
        [InlineData("311")]
        public void Finde_WithKeysNeedMoreInfo_ReturnsErweiterteBedeutungTrue(string data)
        {
            Assert.True(Kostenart.Finde(data).VariableBedeutung);
        }

        #endregion
    }
}
