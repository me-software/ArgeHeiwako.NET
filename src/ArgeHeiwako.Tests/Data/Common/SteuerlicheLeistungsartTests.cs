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
    public class SteuerlicheLeistungsartTests
    {
        public SteuerlicheLeistungsartTests()
        {
        }

        #region Finde()

        [Fact]
        public void Finde_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => SteuerlicheLeistungsart.Finde(null));
            Assert.Equal("schluessel", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("0")]
        [InlineData("000")]
        [InlineData("0A")]
        public void Finde_IncorrtString_ThrowsArgumentOutOfRangeException(string data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => SteuerlicheLeistungsart.Finde(data));
            Assert.Equal("schluessel", ex.ParamName);
        }

        [Theory]
        [InlineData("00")]
        [InlineData("01")]
        [InlineData("02")]
        [InlineData("03")]
        [InlineData("04")]
        [InlineData("11")]
        [InlineData("12")]
        [InlineData("13")]
        public void Finde_CorrectKey_ReturnsInstance(string data)
        {
            var result = SteuerlicheLeistungsart.Finde(data);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<SteuerlicheLeistungsart>(result);
        }

        #endregion

        #region IstGueltigFuer()

        [Theory]
        [InlineData(31, 12, 2008, "00", true)]
        [InlineData(1, 1, 2009, "00", true)]
        [InlineData(31, 12, 2008, "01", true)]
        [InlineData(1, 1, 2009, "01", false)]
        [InlineData(31, 12, 2008, "02", true)]
        [InlineData(1, 1, 2009, "02", false)]
        [InlineData(31, 12, 2008, "03", true)]
        [InlineData(1, 1, 2009, "03", false)]
        [InlineData(31, 12, 2008, "04", true)]
        [InlineData(1, 1, 2009, "04", false)]
        [InlineData(31, 12, 2008, "11", false)]
        [InlineData(1, 1, 2009, "11", true)]
        [InlineData(31, 12, 2008, "12", false)]
        [InlineData(1, 1, 2009, "12", true)]
        [InlineData(31, 12, 2008, "13", false)]
        [InlineData(1, 1, 2009, "13", true)]
        public void IstGueltigFuer_SchluesselUndTag_ReturnsKennzeichen(int tag, int monat, int jahr, string schluessel, bool result)
        {
            var leitsungsart = SteuerlicheLeistungsart.Finde(schluessel);
            Assert.Equal(result, leitsungsart.IsGueltigFuer(new Tag(new DateTime(jahr, monat, tag))));
        }

        #endregion

        #region ToString()

        [Fact]
        public void ToString_ReturnsStringLength2()
        {
            Assert.Equal(2, SteuerlicheLeistungsart.Finde("00").ToString().Length);
        }

        [Fact]
        public void ToString_ReturnsCorrectString()
        {
            Assert.Equal("00", SteuerlicheLeistungsart.Finde("00").ToString());
        }

        #endregion
    }
}
