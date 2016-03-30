using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class OrdnungsbegriffAbrechnungsunternehmenTests
    {
        private LiegenschaftsNummer liegenschaftsNummer;
        private WohnungsNummer wohnungsNummer;
        private OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriff;

        public OrdnungsbegriffAbrechnungsunternehmenTests()
        {
            liegenschaftsNummer = new LiegenschaftsNummer(1);
            wohnungsNummer = new WohnungsNummer(1);

            ordnungsbegriff = new OrdnungsbegriffAbrechnungsunternehmen(liegenschaftsNummer, wohnungsNummer);
        }

        #region Ctor

        [Fact]
        public void Ctor_NullItem_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new OrdnungsbegriffAbrechnungsunternehmen(null, wohnungsNummer));
            Assert.Equal("liegenschaftsNummer", ex.ParamName);
        }

        [Fact]
        public void Ctor_ItemNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new OrdnungsbegriffAbrechnungsunternehmen(liegenschaftsNummer, null));
            Assert.Equal("wohnungsNummer", ex.ParamName);
        }

        [Fact]
        public void Ctor_IntAndShort_ToStringLength13()
        {
            var ordnungsbegriff = new OrdnungsbegriffAbrechnungsunternehmen(new LiegenschaftsNummer(12), new WohnungsNummer(1));
            Assert.Equal(13, ordnungsbegriff.ToString().Length);
        }

        [Fact]
        public void Ctor_IntAndShort_ToString_Equal0000000120001()
        {
            var ordnungsbegriff = new OrdnungsbegriffAbrechnungsunternehmen(new LiegenschaftsNummer(12), new WohnungsNummer(1));
            Assert.Equal("0000000120001", ordnungsbegriff.ToString());
        }

        #endregion

        #region LiegenschaftsNummer

        [Fact]
        public void LiegenschaftsNummer_Get_ReturnsInstance()
        {
            Assert.Equal(liegenschaftsNummer, ordnungsbegriff.LiegenschaftsNummer);
        }

        #endregion

        #region WohnungsNummer

        [Fact]
        public void WohnungsNummer_Get_ReturnsInstance()
        {
            Assert.Equal(wohnungsNummer, ordnungsbegriff.WohnungsNummer);
        }

        #endregion
    }
}
