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
            Assert.Equal(128, CreateDefaultInstance().ToString().Length);
        }

        [Fact]
        public void ToString_FirstCharacterEqualA()
        {
           Assert.Equal("A", CreateDefaultInstance().ToString().Substring(0, 1));
        }

        [Fact]
        public void ToString_LastCharacterEqualA()
        {
            Assert.Equal("A", CreateDefaultInstance().ToString().Substring(127, 1));
        }

        [Fact]
        public void ToString_Chars2To6_Version_Equal03p05()
        {
            Assert.Equal("03.05", CreateDefaultInstance().ToString().Substring(1, 5));
        }

        [Fact]
        public void ToString_Chars7To16_KundenNummer_Equal0000000001()
        {
            Assert.Equal("0000000001", CreateDefaultInstance().ToString().Substring(6, 10));
        }

        [Fact]
        public void ToString_Chars17To18_Abrechnungsunternehmen_Equal2Space()
        {
            Assert.Equal("  ", CreateDefaultInstance().ToString().Substring(16, 2));
        }

        [Fact]
        public void ToString_Chars17To18_AbrechnungsunternehmenTechem_Equal30()
        {
            Assert.Equal("30", CreateDefaultInstance(Abrechnungsunternehmen.Find(30)).ToString().Substring(16, 2));
        }

        [Fact]
        public void ToString_Chars19To31_OrdnungsbegriffAbrechnungsunternehmen_Equal0000000010001()
        {
            Assert.Equal("0000000010001", CreateDefaultInstance().ToString().Substring(18, 13));
        }

        [Fact]
        public void ToString_Chars32To51_OrdnungsbegriffWohnungsunternehmen_EqualId18Spaces()
        {
            Assert.Equal("Id                  ", CreateDefaultInstance().ToString().Substring(31, 20));
        }

        [Fact]
        public void ToString_Chars52To127_Leer_Equal76Spaces()
        {
            Assert.Equal(new string(' ', 76), CreateDefaultInstance().ToString().Substring(51, 76));
        }

        #endregion

        private Ordnungsbegriffe CreateDefaultInstance(Abrechnungsunternehmen unternehmen = null)
        {
            return new Ordnungsbegriffe(new ArgeVersion(), new KundenNummer(1), new OrdnungsbegriffAbrechnungsunternehmen(1, 1), new
                OrdnungsbegriffWohnungsunternehmen("Id"), unternehmen);
        }
    }
}
