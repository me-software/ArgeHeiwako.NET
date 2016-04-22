using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class BilddateiPfadTests
    {
        #region Ctor

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new BilddateiPfad(null));
            Assert.Equal("bilddateiPfad", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("                                                         ")]
        public void Ctor_InvalidStringValue_ThrowsArgumentOutOfRangeException(string value)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new BilddateiPfad(value));
            Assert.Equal("bilddateiPfad", ex.ParamName);
        }

        #endregion

        #region ToString()

        [Theory]
        [InlineData("Test")]
        [InlineData("TestTestTestTest.pdf")]
        public void ToString_Value_AlwaysLength56(string value)
        {
            Assert.Equal(56, new BilddateiPfad(value).ToString().Length);
        }

        #endregion
    }
}
