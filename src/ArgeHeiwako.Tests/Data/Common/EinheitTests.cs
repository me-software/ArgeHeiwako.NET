using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class EinheitTests
    {
        public EinheitTests()
        {
        }

        #region Schnellzugriffe
        [Fact]
        public void GJ_GetsCorrectValue()
        {
            Assert.Equal("001", Einheit.GJ.Schluessel);
            Assert.Equal("GJ", Einheit.GJ.Bezeichnung);
        }

        [Fact]
        public void MWh_GetsCorrectValue()
        {
            Assert.Equal("002", Einheit.MWh.Schluessel);
            Assert.Equal("MWh", Einheit.MWh.Bezeichnung);
        }

        [Fact]
        public void Kubikmeter_GetsCorrectValue()
        {
            Assert.Equal("003", Einheit.Kubikmeter.Schluessel);
            Assert.Equal("m³", Einheit.Kubikmeter.Bezeichnung);
        }

        [Fact]
        public void Kalorien_GetsCorrectValue()
        {
            Assert.Equal("004", Einheit.Kalorien.Schluessel);
            Assert.Equal("kcal", Einheit.Kalorien.Bezeichnung);
        }

        [Fact]
        public void KilowattStunde_GetsCorrectValue()
        {
            Assert.Equal("005", Einheit.KilowattStunde.Schluessel);
            Assert.Equal("kWh", Einheit.KilowattStunde.Bezeichnung);
        }

        [Fact]
        public void WohnflaecheQm_GetsCorrectValue()
        {
            Assert.Equal("010", Einheit.QmWohnflaeche.Schluessel);
            Assert.Equal("m² Wohnfläche", Einheit.QmWohnflaeche.Bezeichnung);
        }

        [Fact]
        public void QmBeheizteWohnflaeche_GetsCorrectValue()
        {
            Assert.Equal("011", Einheit.QmBeheizteWohnflaeche.Schluessel);
            Assert.Equal("m² beheizte Wohnfläche", Einheit.QmBeheizteWohnflaeche.Bezeichnung);
        }

        [Fact]
        public void CmUmbauterRaum_GetsCorrectValue()
        {
            Assert.Equal("012", Einheit.CmUmbauterRaum.Schluessel);
            Assert.Equal("m³ umbauter Raum", Einheit.CmUmbauterRaum.Bezeichnung);
        }

        [Fact]
        public void CmBeheizterUmbauterRaum_GetsCorrectValue()
        {
            Assert.Equal("014", Einheit.CmBeheizterUmbauterRaum.Schluessel);
            Assert.Equal("m³ beheizter umbauter Wohnraum", Einheit.CmBeheizterUmbauterRaum.Bezeichnung);
        }

        [Fact]
        public void VariablesTextfeld_GetsCorrectValue()
        {
            Assert.Equal("015", Einheit.VariablesTextfeld.Schluessel);
            Assert.Equal("variables Textfeld für Schlüssel", Einheit.VariablesTextfeld.Bezeichnung);
        }

        [Fact]
        public void Miteigentumsanteil_GetsCorrectValue()
        {
            Assert.Equal("016", Einheit.Miteigentumsanteil.Schluessel);
            Assert.Equal("Miteigentumsanteil", Einheit.Miteigentumsanteil.Bezeichnung);
        }

        [Fact]
        public void QmNutzflaeche_GetsCorrectValue()
        {
            Assert.Equal("017", Einheit.QmNutzflaeche.Schluessel);
            Assert.Equal("m² Nutzfläche", Einheit.QmNutzflaeche.Bezeichnung);
        }

        [Fact]
        public void Anschlusswert_GetsCorrectValue()
        {
            Assert.Equal("020", Einheit.Anschlusswert.Schluessel);
            Assert.Equal("Anschlusswert", Einheit.Anschlusswert.Bezeichnung);
        }

        [Fact]
        public void Zaehler_GetsCorrectValue()
        {
            Assert.Equal("021", Einheit.Zaehler.Schluessel);
            Assert.Equal("Zähler", Einheit.Zaehler.Bezeichnung);
        }

        [Fact]
        public void Wohnung_GetsCorrectValue()
        {
            Assert.Equal("022", Einheit.Wohnung.Schluessel);
            Assert.Equal("Wohnung", Einheit.Wohnung.Bezeichnung);
        }

        [Fact]
        public void Abrechnung_GetsCorrectValue()
        {
            Assert.Equal("023", Einheit.Abrechnung.Schluessel);
            Assert.Equal("Abrechnung", Einheit.Abrechnung.Bezeichnung);
        }

        [Fact]
        public void Verbrauchseinheiten_GetsCorrectValue()
        {
            Assert.Equal("030", Einheit.Verbrauchseinheiten.Schluessel);
            Assert.Equal("Verbrauchseinheiten (VE)", Einheit.Verbrauchseinheiten.Bezeichnung);
        }

        [Fact]
        public void Verbrauchswerte_GetsCorrectValue()
        {
            Assert.Equal("031", Einheit.Verbrauchswerte.Schluessel);
            Assert.Equal("Verbrauchswerte", Einheit.Verbrauchswerte.Bezeichnung);
        }

        [Fact]
        public void Striche_GetsCorrectValue()
        {
            Assert.Equal("032", Einheit.Striche.Schluessel);
            Assert.Equal("Striche (Venturi)", Einheit.Striche.Bezeichnung);
        }

        [Fact]
        public void KilojouleProSekunde_GetsCorrectValue()
        {
            Assert.Equal("033", Einheit.KilojouleProSekunde.Schluessel);
            Assert.Equal("1000 J/Sec.", Einheit.KilojouleProSekunde.Bezeichnung);
        }

        [Fact]
        public void PersonenMalMonate_GetsCorrectValue()
        {
            Assert.Equal("034", Einheit.PersonenMalMonate.Schluessel);
            Assert.Equal("Personen x Monate", Einheit.PersonenMalMonate.Bezeichnung);
        }

        [Fact]
        public void Personen_GetsCorrectValue()
        {
            Assert.Equal("035", Einheit.Personen.Schluessel);
            Assert.Equal("Personen", Einheit.Personen.Bezeichnung);
        }

        [Fact]
        public void Prozent_GetsCorrectValue()
        {
            Assert.Equal("040", Einheit.Prozent.Schluessel);
            Assert.Equal("Prozent", Einheit.Prozent.Bezeichnung);
        }

        [Fact]
        public void Jahre_GetsCorrectValue()
        {
            Assert.Equal("041", Einheit.Jahre.Schluessel);
            Assert.Equal("Jahr", Einheit.Jahre.Bezeichnung);
        }

        [Fact]
        public void Monate_GetsCorrectValue()
        {
            Assert.Equal("042", Einheit.Monate.Schluessel);
            Assert.Equal("Monat", Einheit.Monate.Bezeichnung);
        }

        [Fact]
        public void Tage_GetsCorrectValue()
        {
            Assert.Equal("043", Einheit.Tage.Schluessel);
            Assert.Equal("Tage", Einheit.Tage.Bezeichnung);
        }

        [Fact]
        public void Gradtage_GetsCorrectValue()
        {
            Assert.Equal("044", Einheit.Gradtage.Schluessel);
            Assert.Equal("Gradtage", Einheit.Gradtage.Bezeichnung);
        }

        [Fact]
        public void PromilleAnteile_GetsCorrectValue()
        {
            Assert.Equal("045", Einheit.PromilleAnteile.Schluessel);
            Assert.Equal("‰ – Anteile", Einheit.PromilleAnteile.Bezeichnung);
        }

        [Fact]
        public void AnzahlRauchwarnmelder_GetsCorrectValue()
        {
            Assert.Equal("046", Einheit.AnzahlRauchwarnmelder.Schluessel);
            Assert.Equal("Anzahl Rauchwarnmelder", Einheit.AnzahlRauchwarnmelder.Bezeichnung);
        }

        #endregion

        #region FromString()

        [Fact]
        public void FromString_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Einheit.FromString(null));
            Assert.Equal("einheit", ex.ParamName);
        }

        [Fact]
        public void FromString_StringEmpty_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Einheit.FromString(string.Empty));
            Assert.Equal("einheit", ex.ParamName);
        }

        [Fact]
        public void FromString_WithNumberNotKnown_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Einheit.FromString("1"));
            Assert.Equal("einheit", ex.ParamName);
        }

        [Fact]
        public void FromString_WithNumberKnown_ReturnsCorrectInstance()
        {
            Assert.Equal(Einheit.GJ, Einheit.FromString("001"));
        }

        #endregion

        #region ToString()

        [Fact]
        public void ToString_ReturnsCorrectValue()
        {
            Assert.Equal("001", Einheit.GJ.ToString());
        }

        #endregion
    }
}
