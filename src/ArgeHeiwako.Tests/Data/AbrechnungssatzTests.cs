using ArgeHeiwako.Data;
using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class AbrechnungssatzTests
    {
        private ArgeVersion version;
        private KundenNummer kundenNummer;
        private LiegenschaftsNummer liegenschaftsNummer;
        private WohnungsNummer wohnungsNummer;
        private OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen;
        private OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen;
        private Tag letzterTagNutzungszeitraum;
        private Kostenart kostenart;
        private Waehrung waehrung;

        public AbrechnungssatzTests()
        {
            version = new ArgeVersion();
            kundenNummer = new KundenNummer(1);
            liegenschaftsNummer = new LiegenschaftsNummer(1);
            wohnungsNummer = new WohnungsNummer(1);
            ordnungsbegriffAbrechnungsunternehmen = new OrdnungsbegriffAbrechnungsunternehmen(liegenschaftsNummer, wohnungsNummer);
            ordnungsbegriffWohnungsunternehmen = new OrdnungsbegriffWohnungsunternehmen("ID");
            letzterTagNutzungszeitraum = new Tag(new DateTime(2015, 12, 31));
            kostenart = Kostenart.Finde("251");
            waehrung = new Waehrung();
        }

        #region Ctor

        [Fact]
        public void Ctor_ArgeVersionNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Abrechnungssatz(null, kundenNummer, ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, letzterTagNutzungszeitraum, kostenart, waehrung));
        }

        [Fact]
        public void Ctor_KundenNummerNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Abrechnungssatz(version, null, ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, letzterTagNutzungszeitraum, kostenart, waehrung));
        }

        [Fact]
        public void Ctor_OrdnungsbegriffAbrechnungsunternehmenNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Abrechnungssatz(version, kundenNummer, null, ordnungsbegriffWohnungsunternehmen, letzterTagNutzungszeitraum, kostenart, waehrung));
        }

        [Fact]
        public void Ctor_OrdnungsbegriffWohnungsunternehmenNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Abrechnungssatz(version, kundenNummer, ordnungsbegriffAbrechnungsunternehmen, null, letzterTagNutzungszeitraum, kostenart, waehrung));
        }

        [Fact]
        public void Ctor_LetzterTagNutzungszeitraumNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Abrechnungssatz(version, kundenNummer, ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, null, kostenart, waehrung));
        }

        [Fact]
        public void Ctor_KostenartNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Abrechnungssatz(version, kundenNummer, ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, letzterTagNutzungszeitraum, null, waehrung));
        }

        [Fact]
        public void Ctor_WaehrungNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Abrechnungssatz(version, kundenNummer, ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, letzterTagNutzungszeitraum, kostenart, null));
        }

        [Fact]
        public void Ctor_AllParametersFilled_DoesNotThrowException()
        {
            Assert.NotNull(new Abrechnungssatz(version, kundenNummer, ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, letzterTagNutzungszeitraum, kostenart, waehrung));
        }

        #endregion

    }
}
