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

        [Fact]
        public void ToString_1_Returns00100()
        {
            Assert.Equal("00100", new Prozent(1).ToString());
        }

        [Fact]
        public void ToString_10_Returns01000()
        {
            Assert.Equal("01000", new Prozent(10).ToString());
        }

        [Fact]
        public void ToString_100_Returns10000()
        {
            Assert.Equal("10000", new Prozent(100).ToString());
        }

        [Fact]
        public void ToString_Dot1_Returns00010()
        {
            Assert.Equal("00010", new Prozent(.1M).ToString());
        }

        [Fact]
        public void ToString_Dot01_Returns00001()
        {
            Assert.Equal("00001", new Prozent(.01M).ToString());
        }

        #endregion
    }
}
