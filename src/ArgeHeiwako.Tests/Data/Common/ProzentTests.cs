using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class ProzentTests
    {
        public ProzentTests()
        {
        }

        #region Ctor

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Prozent(null));
            Assert.Equal("prozent", ex.ParamName);
        }

        [Fact]
        public void Ctor_EmptyString_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Prozent(string.Empty));
            Assert.Equal("prozent", ex.ParamName);
        }
        
        [Fact]
        public void Ctor_NumericStringWithLengthOf4_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Prozent("1234"));
            Assert.Equal("prozent", ex.ParamName);
        }

        [Fact]
        public void Ctor_DoubleMinus1_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Prozent(-1));
            Assert.Equal("prozent", ex.ParamName);
        }

        [Fact]
        public void Ctor_Double100Dot01_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Prozent(100.01M));
            Assert.Equal("prozent", ex.ParamName);
        }

        [Fact]
        public void Ctor_NotNumericString_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Prozent(new string('A', 5)));
            Assert.Equal("prozent", ex.ParamName);
        }

        #endregion

        #region Implizit-Operator double()

        [Fact]
        public void ImplicitOperatorDouble_DoubleValue_ReturnsValue()
        {
            Assert.Equal(50.1M, new Prozent(50.1M));
        }

        [Fact]
        public void ImplicitOperatorDouble_StringValue_ReturnsValue()
        {
            Assert.Equal(50.1M, new Prozent("05010"));
        }

        #endregion

        #region ToString()

        [Theory]
        [InlineData("00100", 1)]
        [InlineData("01000", 10)]
        [InlineData("10000", 100)]
        [InlineData("00010", .1)]
        [InlineData("00001", .01)]
        public void ToString_1_Returns00100(string expectedValue, decimal data)
        {
            Assert.Equal(expectedValue, new Prozent(data).ToString());
        }

        #endregion
    }
}
