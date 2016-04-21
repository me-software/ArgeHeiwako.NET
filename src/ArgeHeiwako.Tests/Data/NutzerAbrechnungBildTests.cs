using ArgeHeiwako.Data;
using ArgeHeiwako.Data.Common;
using ArgeHeiwako.Tests.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    public class NutzerAbrechnungBildTests
    {
        private static LiegenschaftsNummer liegenschaftsNummer = new LiegenschaftsNummer(1);
        private static NutzergruppenNummer nutzergruppenNummer = new NutzergruppenNummer(1);
        private static WohnungsNummer wohnungsNummer = new WohnungsNummer(1);
        private static Nutzerfolge nutzerfolge = new Nutzerfolge(1);
        private static ErweiterterOrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen = new ErweiterterOrdnungsbegriffAbrechnungsunternehmen(liegenschaftsNummer, nutzergruppenNummer, wohnungsNummer, nutzerfolge);
        private static OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen = new OrdnungsbegriffWohnungsunternehmen("ID");
        private static BilddateiPfad bilddateiPfad = new BilddateiPfad("test.pdf");
        private static BilddateiFolgeNummer bilddateiFolgeNummer = new BilddateiFolgeNummer(1);
        private static Tag letzterTagNutzungszeitraum = new Tag(new DateTime(2015, 12, 31));

        #region Ctor

        [Fact]
        public void Ctor_OrdnungsbegriffAbrechnungsunternehmenNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new NutzerAbrechnungBild(null, ordnungsbegriffWohnungsunternehmen, bilddateiPfad, bilddateiFolgeNummer, letzterTagNutzungszeitraum));
            Assert.Equal("ordnungsbegriffAbrechnungsunternehmen", ex.ParamName);
        }

        [Fact]
        public void Ctor_OrdnungsbegriffWohnungsunternehmenNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new NutzerAbrechnungBild(ordnungsbegriffAbrechnungsunternehmen, null, bilddateiPfad, bilddateiFolgeNummer, letzterTagNutzungszeitraum));
            Assert.Equal("ordnungsbegriffWohnungsunternehmen", ex.ParamName);
        }

        [Fact]
        public void Ctor_BilddateiPfadNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new NutzerAbrechnungBild(ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, null, bilddateiFolgeNummer, letzterTagNutzungszeitraum));
            Assert.Equal("bilddateiPfad", ex.ParamName);
        }

        [Fact]
        public void Ctor_BilddateiFolgeNummerNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new NutzerAbrechnungBild(ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, bilddateiPfad, null, letzterTagNutzungszeitraum));
            Assert.Equal("bilddateiFolgeNummer", ex.ParamName);
        }

        [Fact]
        public void Ctor_LetzterTagNutzungszeitraumNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new NutzerAbrechnungBild(ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, bilddateiPfad, bilddateiFolgeNummer, null));
            Assert.Equal("letzterTagNutzungszeitraum", ex.ParamName);
        }

        #endregion

        #region OrdnungsbegriffAbrechnungsunternehmen

        [Fact]
        public void OrdnungsbegriffAbrechnungsunternehmen_Get_ReturnsInstance()
        {
            Assert.Equal(ordnungsbegriffAbrechnungsunternehmen, CreateDefault().OrdnungsbegriffAbrechnungsunternehmen);
        }

        #endregion

        #region OrdnungsbegriffWohnungsunternehmen

        [Fact]
        public void OrdnungsbegriffWohnungsunternehmen_Get_ReturnsInstance()
        {
            Assert.Equal(ordnungsbegriffWohnungsunternehmen, CreateDefault().OrdnungsbegriffWohnungsunternehmen);
        }

        #endregion

        #region BilddateiPfad

        [Fact]
        public void BilddateiPfad_Get_ReturnsInstance()
        {
            Assert.Equal(bilddateiPfad, CreateDefault().BilddateiPfad);
        }

        #endregion

        #region BilddateiFolgeNummer

        [Fact]
        public void BilddateiFolgeNummer_Get_ReturnsInstance()
        {
            Assert.Equal(bilddateiFolgeNummer, CreateDefault().BilddateiFolgeNummer);
        }

        #endregion

        #region LetzterTagNutzungszeitraum

        [Fact]
        public void LetzterTagNutzungszeitraum_Get_ReturnsInstance()
        {
            Assert.Equal(letzterTagNutzungszeitraum, CreateDefault().LetzterTagNutzungszeitraum);
        }

        #endregion

        #region SatzfolgeNummer

        [Fact]
        public void SatzfolgeNummer_Get_DefaultReturnsNull()
        {
            Assert.Null(CreateDefault().SatzfolgeNummer);
        }

        [Fact]
        public void SatzfolgeNummer_Get_SetByCtorReturnsInstance()
        {
            var satzfolgeNummer = new SatzfolgeNummer(1);
            var instance = new NutzerAbrechnungBild(ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, bilddateiPfad, bilddateiFolgeNummer, letzterTagNutzungszeitraum, satzfolgeNummer: satzfolgeNummer);
            Assert.Equal(satzfolgeNummer, instance.SatzfolgeNummer);
        }

        #endregion

        #region Abrechnungsunternehmen

        [Fact]
        public void Abrechnungsunternehmen_Get_DefaultReturnsNull()
        {
            Assert.Null(CreateDefault().Abrechnungsunternehmen);
        }

        [Fact]
        public void Abrechnungsunternehmen_Get_SetByCtorReturnsInstance()
        {
            var abrechnungsunternehmen = Abrechnungsunternehmen.Finde(30);
            var instance = new NutzerAbrechnungBild(ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, bilddateiPfad, bilddateiFolgeNummer, letzterTagNutzungszeitraum, abrechnungsunternehmen: abrechnungsunternehmen);
            Assert.Equal(abrechnungsunternehmen, instance.Abrechnungsunternehmen);
        }

        #endregion

        #region AbrechnungsfolgeNummer

        [Fact]
        public void AbrechnungsfolgeNummer_Get_DefaultReturnsNull()
        {
            Assert.Null(CreateDefault().AbrechnungsfolgeNummer);
        }

        [Fact]
        public void AbrechnungsfolgeNummer_Get_SetByCtorReturnsInstance()
        {
            var abrechnungsfolgeNummer = new AbrechnungsfolgeNummer("1");
            var instance = new NutzerAbrechnungBild(ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, bilddateiPfad, bilddateiFolgeNummer, letzterTagNutzungszeitraum, abrechnungsfolgeNummer: abrechnungsfolgeNummer);
            Assert.Equal(abrechnungsfolgeNummer, instance.AbrechnungsfolgeNummer);
        }

        #endregion

        #region Dokumentart

        [Fact]
        public void Dokumentart_Get_DefaultReturnsNull()
        {
            Assert.Null(CreateDefault().Dokumentart);
        }

        [Fact]
        public void Dokumentart_Get_SetByCtorReturnsInstance()
        {
            var dokumentart = Dokumentart.Heizkostenabrechnung;
            var instance = new NutzerAbrechnungBild(ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, bilddateiPfad, bilddateiFolgeNummer, letzterTagNutzungszeitraum, dokumentart: dokumentart);
            Assert.Equal(dokumentart, instance.Dokumentart);
        }

        #endregion

        #region ToString()

        [Fact]
        public void ToString_DefaultInstance_ReturnsStringLength120()
        {
            Assert.Equal(120, CreateDefault().ToString().Length);
        }

        [Fact]
        public void ToString_DefaultInstance_ReturnsStringValue()
        {
            var expectedString = "E898         000000001000100011ID                   test.pdf                                                001311215   ";
            Assert.Equal(expectedString, CreateDefault().ToString());
        }

        #endregion

        internal static NutzerAbrechnungBild CreateDefault()
        {
            return new NutzerAbrechnungBild(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                bilddateiPfad,
                bilddateiFolgeNummer,
                letzterTagNutzungszeitraum);
        }
    }
}
