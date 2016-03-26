using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class NutzerfolgeTests
    {
        #region Ctor

        [Fact]
        public void Ctor_StringNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Nutzerfolge(null));
            Assert.Equal("nutzerfolge", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("00")]
        [InlineData("A")]
        public void Ctor_StringIncorrect_ThrowsArgumentOutOfRangeException(string data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Nutzerfolge(data));
            Assert.Equal("nutzerfolge", ex.ParamName);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        public void Ctor_IntIncorrect_ThrowsArgumentOutOfRangeException(short data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Nutzerfolge(data));
            Assert.Equal("nutzerfolge", ex.ParamName);
        }

        #endregion

        #region Op_Implicit short

        [Fact]
        public void OpImplicitShort_ShortValue_ReturnsValue()
        {
            Assert.Equal(1, new Nutzerfolge(1));
        }

        [Fact]
        public void OpImplicitShort_StringValue_ReturnsValue()
        {
            Assert.Equal(1, new Nutzerfolge("1"));
        }

        #endregion

        #region ToString() 

        [Fact]
        public void ToString_ShortValue_ReturnsValue()
        {
            Assert.Equal("1", new Nutzerfolge(1).ToString());
        }

        [Fact]
        public void ToString_StringValue_ReturnsValue()
        {
            Assert.Equal("1", new Nutzerfolge("1").ToString());
        }
        #endregion
    }
}
