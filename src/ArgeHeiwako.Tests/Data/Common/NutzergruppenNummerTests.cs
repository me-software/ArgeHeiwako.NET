using ArgeHeiwako.Data.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class NutzergruppenNummerTests
    {
        #region Ctor

        [Fact]
        public void Ctor_StringNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new NutzergruppenNummer(null));
            Assert.Equal("nutzergruppenNummer", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("0")]
        [InlineData("00")]
        [InlineData("000")]
        [InlineData("00000")]
        [InlineData("000A")]
        public void Ctor_StringIncorrect_ThrowsArgumentOutOfRangeException(string data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new NutzergruppenNummer(data));
            Assert.Equal("nutzergruppenNummer", ex.ParamName);
        }

        [Theory]
        [InlineData(-1000)]
        [InlineData(10000)]
        public void Ctor_ShortIncorrect_ThrowsArgumentOutOfRangeException(short data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new NutzergruppenNummer(data));
            Assert.Equal("nutzergruppenNummer", ex.ParamName);
        }

        #endregion

        #region ToString()

        [Theory]
        [InlineData(-1, "-001")]
        [InlineData(1, "0001")]
        public void ToString_ShortValue_ReturnsString(short data, string result)
        {
            Assert.Equal(result, new NutzergruppenNummer(data).ToString());
        }

        [Theory]
        [InlineData("-001")]
        [InlineData("0001")]
        public void ToString_StringValue_ReturnsString(string data)
        {
            Assert.Equal(data, new NutzergruppenNummer(data).ToString());
        }

        #endregion

        #region OpImplicit Short

        [Fact]
        public void OpImplicitShort_ShortValue_ReturnsValue()
        {
            Assert.Equal(1, new NutzergruppenNummer(1));
        }

        [Fact]
        public void OpImplicitShort_StringValue_ReturnsValue()
        {
            Assert.Equal(1, new NutzergruppenNummer("0001"));
        }

        #endregion
    }
}
