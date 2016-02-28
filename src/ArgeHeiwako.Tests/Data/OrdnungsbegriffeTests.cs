using ArgeHeiwako.Data;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class OrdnungsbegriffeTests
    {
        #region ToString()

        [Fact]
        public void ToString_Length128()
        {
            Assert.Equal(128, CreateDefault().ToString().Length);
        }

        [Fact]
        public void ToString_FirstCharacterEqualA()
        {
           Assert.Equal("A", CreateDefault().ToString().Substring(0, 1));
        }

        [Fact]
        public void ToString_LastCharacterEqualA()
        {
            Assert.Equal("A", CreateDefault().ToString().Substring(127, 1));
        }

        [Fact]
        public void ToString_Chars2To6_Version_Equal03p05()
        {
            Assert.Equal("03.05", CreateDefault().ToString().Substring(1, 5));
        }

        [Fact]
        public void ToString_Chars7To16_KundenNummer_Equal0000000001()
        {
            Assert.Equal("0000000001", CreateDefault().ToString().Substring(6, 10));
        }

        [Fact]
        public void ToString_Chars17To18_Abrechnungsunternehmen_Equal2Space()
        {
            Assert.Equal("  ", CreateDefault().ToString().Substring(16, 2));
        }

        [Fact]
        public void ToString_Chars17To18_AbrechnungsunternehmenTechem_Equal30()
        {
            Assert.Equal("30", CreateDefault(Abrechnungsunternehmen.Find(30)).ToString().Substring(16, 2));
        }

        [Fact]
        public void ToString_Chars19To31_OrdnungsbegriffAbrechnungsunternehmen_Equal0000000010001()
        {
            Assert.Equal("0000000010001", CreateDefault().ToString().Substring(18, 13));
        }

        [Fact]
        public void ToString_Chars32To51_OrdnungsbegriffWohnungsunternehmen_EqualId18Spaces()
        {
            Assert.Equal("Id                  ", CreateDefault().ToString().Substring(31, 20));
        }

        [Fact]
        public void ToString_Chars52To127_Leer_Equal76Spaces()
        {
            Assert.Equal(new string(' ', 76), CreateDefault().ToString().Substring(51, 76));
        }

        #endregion

        internal static Ordnungsbegriffe CreateDefault(Abrechnungsunternehmen unternehmen = null)
        {
            return new Ordnungsbegriffe(new ArgeVersion(), new KundenNummer(1), new OrdnungsbegriffAbrechnungsunternehmen(1, 1), new
                OrdnungsbegriffWohnungsunternehmen("Id"), unternehmen);
        }
    }
}
