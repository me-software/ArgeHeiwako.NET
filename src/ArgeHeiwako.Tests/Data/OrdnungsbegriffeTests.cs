using ArgeHeiwako.Data;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
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

        #region FromString() 

        [Fact]
        public void FromString_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Ordnungsbegriffe.FromString(null));
            Assert.Equal("ordnungsbegriffeString", ex.ParamName);
        }

        [Fact]
        public void FromString_EmptyString_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Ordnungsbegriffe.FromString(string.Empty));
            Assert.Equal("ordnungsbegriffeString", ex.ParamName);
            Assert.StartsWith(ArgeHeiwako.Data.Properties.Resources.EXP_MSG_VALID_A_SATZ_128_CHARACTERS, ex.Message);
        }

        [Fact]
        public void FromString_StringShorterThan128Characters_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Ordnungsbegriffe.FromString(new string(' ', 50)));
            Assert.Equal("ordnungsbegriffeString", ex.ParamName);
            Assert.StartsWith(ArgeHeiwako.Data.Properties.Resources.EXP_MSG_VALID_A_SATZ_128_CHARACTERS, ex.Message);
        }

        [Fact]
        public void FromString_StringDoesNotStartWithA_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Ordnungsbegriffe.FromString(new string(' ', 128)));
            Assert.Equal("ordnungsbegriffeString", ex.ParamName);
            Assert.StartsWith(ArgeHeiwako.Data.Properties.Resources.EXP_MSG_VALID_A_SATZ_MUST_START_END_WITH_A, ex.Message);
        }

        [Fact]
        public void FromString_StringDoesNotEndWithA_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Ordnungsbegriffe.FromString($"A{new string(' ', 127)}"));
            Assert.Equal("ordnungsbegriffeString", ex.ParamName);
            Assert.StartsWith(ArgeHeiwako.Data.Properties.Resources.EXP_MSG_VALID_A_SATZ_MUST_START_END_WITH_A, ex.Message);
        }

        [Fact]
        public void FromString_StringVersionPartEmpty_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Ordnungsbegriffe.FromString($"A{new string(' ', 126)}A"));
        }

        [Fact]
        public void FromString_StringVersionValid_VersionEqual03p05()
        {
            var value = CreateDefault().ToString();
            Assert.Equal("03.05", Ordnungsbegriffe.FromString(value).Version);
        }

        [Fact]
        public void FromString_StringKundenNummerEmpty_Throws()
        {
            var value = CreateDefault().ToString();
            value = value.Replace("0000000001", new string(' ', 10));

            Assert.Throws<ArgumentException>(() => Ordnungsbegriffe.FromString(value));
        }

        [Fact]
        public void FromString_StringKundenNummer_KundenNummerEqual0000000001()
        {
            var value = CreateDefault().ToString();
            Assert.Equal("0000000001", Ordnungsbegriffe.FromString(value).KundenNummer.ToString());
        }

        [Fact]
        public void FromString_StringAbrechnungsunternehmenEmpty_KundenNummerEqual0000000001()
        {
            var valueBuilder = new StringBuilder(CreateDefault().ToString());
            valueBuilder[16] = ' ';
            valueBuilder[17] = ' ';
            Assert.Null(Ordnungsbegriffe.FromString(valueBuilder.ToString()).Abrechnungsunternehmen);
        }

        [Fact]
        public void FromString_StringAbrechnungsunternehmen30_AbrechnungsunternehmenEqual30()
        {
            var valueBuilder = new StringBuilder(CreateDefault(Abrechnungsunternehmen.Find(30)).ToString());
            Assert.Equal("30", Ordnungsbegriffe.FromString(valueBuilder.ToString()).Abrechnungsunternehmen.ToString());
        }

        [Fact(Skip = "Not Implemented")]
        public void FromString_String128Characters_ReturnsOrdnungsbegriffe()
        {
            Assert.IsAssignableFrom<Ordnungsbegriffe>(Ordnungsbegriffe.FromString(CreateDefault().ToString()));
        }

        #endregion

        internal static Ordnungsbegriffe CreateDefault(Abrechnungsunternehmen unternehmen = null)
        {
            return new Ordnungsbegriffe(new ArgeVersion(), new KundenNummer(1), new OrdnungsbegriffAbrechnungsunternehmen(1, 1), new
                OrdnungsbegriffWohnungsunternehmen("Id"), unternehmen);
        }
    }
}
