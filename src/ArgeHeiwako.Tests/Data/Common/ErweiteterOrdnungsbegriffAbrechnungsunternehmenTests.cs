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
    public class ErweiteterOrdnungsbegriffAbrechnungsunternehmenTests
    {
        private LiegenschaftsNummer liegenschaftsNummer;
        private Nutzerfolge nutzerfolge;
        private NutzergruppenNummer nutzergruppenNummer;
        private WohnungsNummer wohnungsNummer;
        private ErweiterterOrdnungsbegriffAbrechnungsunternehmen ordnungsbegriff;

        public ErweiteterOrdnungsbegriffAbrechnungsunternehmenTests()
        {
            liegenschaftsNummer = new LiegenschaftsNummer(1);
            nutzergruppenNummer = new NutzergruppenNummer(1);
            wohnungsNummer = new WohnungsNummer(1);
            nutzerfolge = new Nutzerfolge(1);

            ordnungsbegriff = new ErweiterterOrdnungsbegriffAbrechnungsunternehmen(liegenschaftsNummer, nutzergruppenNummer, wohnungsNummer, nutzerfolge);
        }

        #region Ctor

        [Fact]
        public void Ctor_NullItemItemItem_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new ErweiterterOrdnungsbegriffAbrechnungsunternehmen(null, nutzergruppenNummer, wohnungsNummer, nutzerfolge));
            Assert.Equal("liegenschaftsNummer", ex.ParamName);
        }

        [Fact]
        public void Ctor_ItemNullItemItem_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new ErweiterterOrdnungsbegriffAbrechnungsunternehmen(liegenschaftsNummer, null, wohnungsNummer, nutzerfolge));
            Assert.Equal("nutzergruppenNummer", ex.ParamName);
        }

        [Fact]
        public void Ctor_ItemItemNullItem_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new ErweiterterOrdnungsbegriffAbrechnungsunternehmen(liegenschaftsNummer, nutzergruppenNummer, null, nutzerfolge));
            Assert.Equal("wohnungsNummer", ex.ParamName);
        }

        [Fact]
        public void Ctor_ItemItemItemNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new ErweiterterOrdnungsbegriffAbrechnungsunternehmen(liegenschaftsNummer, nutzergruppenNummer, wohnungsNummer, null));
            Assert.Equal("nutzerfolge", ex.ParamName);
        }

        #endregion

        #region FromString()

        [Fact]
        public void FromString_StringNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ErweiterterOrdnungsbegriffAbrechnungsunternehmen.FromString(null));
            Assert.Equal("erweiterterOrdnungsbegriffAbrechnungsunternehmenString", ex.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("00000000000000000")]
        [InlineData("0000000000000000000")]
        public void FromString_StringNotValid_ThrowsArgumentOutOfRangeException(string data)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => ErweiterterOrdnungsbegriffAbrechnungsunternehmen.FromString(data));
            Assert.Equal("erweiterterOrdnungsbegriffAbrechnungsunternehmenString", ex.ParamName);
        }

        [Fact]
        public void FromString_ValidString_ReturnsValidToString()
        {
            var validString = "000000001000100011";
            Assert.Equal(validString, ErweiterterOrdnungsbegriffAbrechnungsunternehmen.FromString(validString).ToString());
        }

        #endregion

        #region LiegenschaftsNummer 

        [Fact]
        public void LiegenschaftsNummer_Get_ReturnsInstance()
        {
            Assert.Equal(liegenschaftsNummer, ordnungsbegriff.LiegenschaftsNummer);
        }

        #endregion

        #region NutzergruppenNummer

        [Fact]
        public void NutzergruppenNummer_Get_ReturnsInstance()
        {
            Assert.Equal(nutzergruppenNummer, ordnungsbegriff.NutzergruppenNummer);
        }

        #endregion

        #region WohnungsNummer

        [Fact]
        public void WohnungsNummer_Get_ReturnsInstance()
        {
            Assert.Equal(wohnungsNummer, ordnungsbegriff.WohnungsNummer);
        }

        #endregion

        #region WohnungsNummer

        [Fact]
        public void Nutzerfolge_Get_ReturnsInstance()
        {
            Assert.Equal(nutzerfolge, ordnungsbegriff.Nutzerfolge);
        }

        #endregion

        #region ToString()

        [Fact]
        public void ToString_ValuesSet1111_Returns000000001000100011()
        {
            Assert.Equal("000000001000100011", ordnungsbegriff.ToString());
        }

        #endregion
    }
}
