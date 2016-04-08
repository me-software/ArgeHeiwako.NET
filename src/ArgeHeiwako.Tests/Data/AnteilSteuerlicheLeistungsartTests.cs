using ArgeHeiwako.Data;
using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class AnteilSteuerlicheLeistungsartTests
    {
        private Kostenart kostenart;
        private ErweiterterOrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen;
        private OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen;
        private SteuerlicheLeistungsart steuerlicheLeistungsart;
        private Betrag rechnungsbetrag;
        private Betrag nutzerAnteil;
        private Prozent prozentualerNutzerAnteil;
        private Betrag lohnanteilRechnungsbetrag;
        private Betrag lohnanteilNutzerAnteil;
        private Tag letzterTagNutzungszeitraum;

        private AnteilSteuerlicheLeistungsart anteilSteuerlicheLeistungsart;

        public AnteilSteuerlicheLeistungsartTests()
        {
            ordnungsbegriffAbrechnungsunternehmen = new ErweiterterOrdnungsbegriffAbrechnungsunternehmen(
                new LiegenschaftsNummer(1),
                new NutzergruppenNummer(1),
                new WohnungsNummer(1),
                new Nutzerfolge(1));
            ordnungsbegriffWohnungsunternehmen = new OrdnungsbegriffWohnungsunternehmen("ID");
            kostenart = Kostenart.Finde("050");
            steuerlicheLeistungsart = SteuerlicheLeistungsart.Finde("00");
            rechnungsbetrag = new Betrag(100.00M);
            nutzerAnteil = new Betrag(5.0M);
            prozentualerNutzerAnteil = new Prozent(5);
            lohnanteilRechnungsbetrag = new Betrag(0);
            lohnanteilNutzerAnteil = new Betrag(0);
            letzterTagNutzungszeitraum = new Tag(new DateTime(2016, 12, 31));

            anteilSteuerlicheLeistungsart = new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum);
        }

        #region Ctor

        [Fact]
        public void Ctor_OrdnungsbegriffAbrechnungsunternehmenNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AnteilSteuerlicheLeistungsart(
                null,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum));
            Assert.Equal("ordnungsbegriffAbrechnungsunternehmen", ex.ParamName);
        }

        [Fact]
        public void Ctor_OrdnungsbegriffWohnungsunternehmenNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                null,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum));
            Assert.Equal("ordnungsbegriffWohnungsunternehmen", ex.ParamName);
        }

        [Fact]
        public void Ctor_KostenartNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                null,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum));
            Assert.Equal("kostenart", ex.ParamName);
        }

        [Fact]
        public void Ctor_SteuerlicheLeistungsartNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                null,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum));
            Assert.Equal("steuerlicheLeistungsart", ex.ParamName);
        }

        [Fact]
        public void Ctor_RechnungsbetragNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                null,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum));
            Assert.Equal("rechnungsbetrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_NutzerAnteilNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                null,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum));
            Assert.Equal("nutzerAnteil", ex.ParamName);
        }

        [Fact]
        public void Ctor_ProzentualerNutzerAnteilNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                null,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum));
            Assert.Equal("prozentualerNutzerAnteil", ex.ParamName);
        }

        [Fact]
        public void Ctor_LohnanteilRechnungsbetragNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                null,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum));
            Assert.Equal("lohnanteilRechnungsbetrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_LohnanteilNutzerAnteilNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                null,
                letzterTagNutzungszeitraum));
            Assert.Equal("lohnanteilNutzerAnteil", ex.ParamName);

        }

        [Fact]
        public void Ctor_LetzterTagNutzungszeitraumNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                null));
            Assert.Equal("letzterTagNutzungszeitraum", ex.ParamName);
        }

        [Theory]
        [InlineData("228")]
        [InlineData("242")]
        [InlineData("254")]
        [InlineData("311")]
        public void Ctor_KostenartText_TooLongStringThrowsArgumentOutOfRangeException(string kostenartSchluessel)
        {
            var variableKostenart = Kostenart.Finde(kostenartSchluessel);
            var ex = Assert.Throws<ArgumentNullException>(
                () => new AnteilSteuerlicheLeistungsart(
                    ordnungsbegriffAbrechnungsunternehmen,
                    ordnungsbegriffWohnungsunternehmen,
                    variableKostenart,
                    steuerlicheLeistungsart,
                    rechnungsbetrag,
                    nutzerAnteil,
                    prozentualerNutzerAnteil,
                    lohnanteilRechnungsbetrag,
                    lohnanteilNutzerAnteil,
                    letzterTagNutzungszeitraum)
                );
            Assert.Equal("kostenartText", ex.ParamName);
        }

        #endregion

        #region Kostenart

        [Fact]
        public void Kostenart_Get_ReturnsBackingField()
        {
            Assert.Equal(kostenart, anteilSteuerlicheLeistungsart.Kostenart);
        }

        #endregion

        #region OrdnungsbegriffAbrechnungsunternehmen

        [Fact]
        public void OrdnungsbegriffAbrechnungsunternehmen_Get_ReturnsBackingField()
        {
            Assert.Equal(ordnungsbegriffAbrechnungsunternehmen, anteilSteuerlicheLeistungsart.OrdnungsbegriffAbrechnungsunternehmen);
        }

        #endregion

        #region OrdnungsbegriffWohnungsunternehmen

        [Fact]
        public void OrdnungsbegriffWohnungsunternehmen_Get_ReturnsBackingField()
        {
            Assert.Equal(ordnungsbegriffWohnungsunternehmen, anteilSteuerlicheLeistungsart.OrdnungsbegriffWohnungsunternehmen);
        }

        #endregion

        #region SteuerlicheLeistungsart

        [Fact]
        public void SteuerlicheLeistungsart_Get_ReturnsBackingField()
        {
            Assert.Equal(steuerlicheLeistungsart, anteilSteuerlicheLeistungsart.SteuerlicheLeistungsart);
        }

        #endregion

        #region Rechnungsbetrag

        [Fact]
        public void Rechnungsbetrag_Get_ReturnsBackingField()
        {
            Assert.Equal(rechnungsbetrag, anteilSteuerlicheLeistungsart.Rechnungsbetrag);
        }

        #endregion

        #region NutzerAnteil

        [Fact]
        public void NutzerAnteil_Get_ReturnsBackingField()
        {
            Assert.Equal(nutzerAnteil, anteilSteuerlicheLeistungsart.NutzerAnteil);
        }

        #endregion

        #region ProzentualerNutzerAnteil

        [Fact]
        public void ProzentualerNutzerAnteil_Get_ReturnsBackingField()
        {
            Assert.Equal(prozentualerNutzerAnteil, anteilSteuerlicheLeistungsart.ProzentualerNutzerAnteil);
        }

        #endregion

        #region ProzentualerNutzerAnteil

        [Fact]
        public void LohnanteilRechnungsbetrag_Get_ReturnsBackingField()
        {
            Assert.Equal(lohnanteilRechnungsbetrag, anteilSteuerlicheLeistungsart.LohnanteilRechnungsbetrag);
        }

        #endregion

        #region LohnanteilNutzerAnteil

        [Fact]
        public void LohnanteilNutzerAnteil_Get_ReturnsBackingField()
        {
            Assert.Equal(lohnanteilNutzerAnteil, anteilSteuerlicheLeistungsart.LohnanteilNutzerAnteil);
        }

        #endregion

        #region LetzterTagNutzungszeitraum

        [Fact]
        public void LetzterTagNutzungszeitraum_Get_ReturnsBackingField()
        {
            Assert.Equal(letzterTagNutzungszeitraum, anteilSteuerlicheLeistungsart.LetzterTagNutzungszeitraum);
        }

        #endregion

        #region SatzfolgeNummer

        [Fact]
        public void SatzfolgeNummer_Get_DefaultReturnsNull()
        {
            Assert.Null(anteilSteuerlicheLeistungsart.Satzfolgenummer);
        }

        [Fact]
        public void SatzfolgeNummer_Get_AfterSetReturnsValue()
        {
            var satzfolgeNummer = new Satzfolgenummer(1);
            var item = new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum,
                satzfolgeNummer: satzfolgeNummer);

            Assert.Equal(satzfolgeNummer, item.Satzfolgenummer);
        }

        #endregion

        #region Abrechnungsunternehmen

        [Fact]
        public void Abrechnungsunternehmen_Get_DefaultReturnsNull()
        {
            Assert.Null(anteilSteuerlicheLeistungsart.Abrechnungsunternehmen);
        }

        [Fact]
        public void Abrechnungsunternehmen_Get_AfterSetReturnsValue()
        {
            var abrechnungsunternehmen = Abrechnungsunternehmen.Find(30);

            var item = new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum,
                abrechnungsunternehmen: abrechnungsunternehmen);

            Assert.Equal(abrechnungsunternehmen, item.Abrechnungsunternehmen);
        }

        #endregion

        #region AbrechnungsfolgeNummer

        [Fact]
        public void AbrechnungsfolgeNummer_Get_DefaultReturnsNull()
        {
            Assert.Null(anteilSteuerlicheLeistungsart.AbrechnungsfolgeNummer);
        }

        [Fact]
        public void AbrechnungsfolgeNummer_Get_AfterSetReturnsValue()
        {
            var abrechnungsfolgeNummer = new AbrechnungsfolgeNummer(" ");
            var item = new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum,
                abrechnungsfolgeNummer: abrechnungsfolgeNummer);

            Assert.Equal(abrechnungsfolgeNummer, item.AbrechnungsfolgeNummer);
        }

        #endregion

        #region KostenartText
        [Fact]
        public void KostenartText_Get_DefaultReturnsNull()
        {
            Assert.Null(anteilSteuerlicheLeistungsart.KostenartText);
        }

        [Fact]
        public void KostenartText_Get_AfterSetReturnsValue()
        {
            var kostenartText = "Test";
            var item = new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum,
                kostenartText: kostenartText);

            Assert.Equal(kostenartText, item.KostenartText);
        }
        #endregion

        #region ToString()

        [Fact]
        public void ToString_ReturnsStringLength133()
        {
            Assert.Equal(133, anteilSteuerlicheLeistungsart.ToString().Length);
        }

        [Fact]
        public void ToString_MandatoryItemsSet_ReturnsCorrectString()
        {
            var expected =
                "E835         000000001000100011ID                   050                         00000001000000000005000050000000000000000000000311216";
            Assert.Equal(expected, anteilSteuerlicheLeistungsart.ToString());
        }

        [Fact]
        public void ToString_KostenartTextSet_ReturnsCorrectString()
        {
            var expected =
                "E835         000000001000100011ID                   050Testkosten               00000001000000000005000050000000000000000000000311216";

            var item = new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum,
                kostenartText: "Testkosten");
            Assert.Equal(expected, item.ToString());
        }

        [Fact]
        public void ToString_AbrechnungsfolgeNummerSet_ReturnsCorrectString()
        {
            var expected =
                "E835         000000001000100011ID                  1050                         00000001000000000005000050000000000000000000000311216";

            var item = new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum,
                abrechnungsfolgeNummer: new AbrechnungsfolgeNummer("1"));
            Assert.Equal(expected, item.ToString());
        }

        [Fact]
        public void ToString_AbrechnungsunternehmenSet_ReturnsCorrectString()
        {
            var expected =
                "E835       30000000001000100011ID                   050                         00000001000000000005000050000000000000000000000311216";

            var item = new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum,
                abrechnungsunternehmen: Abrechnungsunternehmen.Find(30));
            Assert.Equal(expected, item.ToString());
        }

        [Fact]
        public void ToString_SatzfolgeNummerSet_ReturnsCorrectString()
        {
            var expected =
                "E8350000001  000000001000100011ID                   050                         00000001000000000005000050000000000000000000000311216";

            var item = new AnteilSteuerlicheLeistungsart(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                kostenart,
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum,
                satzfolgeNummer: new Satzfolgenummer(1));
            Assert.Equal(expected, item.ToString());
        }

        #endregion
    }
}
