using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public sealed class AblesekennzeichenTests
    {
        public AblesekennzeichenTests()
        {
        }

        #region Schnellzugriffe

        [Fact]
        public void Schaetzung_Get_ReturnsValue()
        {
            Assert.Equal("01", Ablesekennzeichen.Schaetzung.Schluessel);
            Assert.Equal("Schätzung", Ablesekennzeichen.Schaetzung.Bezeichnung);
        }

        [Fact]
        public void SchaetzungNachVorjahr_Get_ReturnsValue()
        {
            Assert.Equal("02", Ablesekennzeichen.SchaetzungNachVorjahr.Schluessel);
            Assert.Equal("Schätzung nach Vorjahr", Ablesekennzeichen.SchaetzungNachVorjahr.Bezeichnung);
        }

        [Fact]
        public void SchaetzungNachNormwaermeleistung_Get_ReturnsValue()
        {
            Assert.Equal("03", Ablesekennzeichen.SchaetzungNachNormwaermeleistung.Schluessel);
            Assert.Equal("Schätzung nach Normwärmeleistung", Ablesekennzeichen.SchaetzungNachNormwaermeleistung.Bezeichnung);
        }

        [Fact]
        public void SchaetzungNachGrundanteil_Get_ReturnsValue()
        {
            Assert.Equal("04", Ablesekennzeichen.SchaetzungNachGrundanteil.Schluessel);
            Assert.Equal("Schätzung nach Grundanteil(z.B. 1 WMZ pro Nutzeinheit)", Ablesekennzeichen.SchaetzungNachGrundanteil.Bezeichnung);
        }

        [Fact]
        public void Teilschaetzung_Get_ReturnsValue()
        {
            Assert.Equal("05", Ablesekennzeichen.Teilschaetzung.Schluessel);
            Assert.Equal("Teilschätzung", Ablesekennzeichen.Teilschaetzung.Bezeichnung);
        }

        [Fact]
        public void SchaetzungNachFlaeche_Get_ReturnsValue()
        {
            Assert.Equal("06", Ablesekennzeichen.SchaetzungNachFlaeche.Schluessel);
            Assert.Equal("Schätzung nach Fläche", Ablesekennzeichen.SchaetzungNachFlaeche.Bezeichnung);
        }

        [Fact]
        public void SchaetzungNachVergleichbarenZeitraeumen_Get_ReturnsValue()
        {
            Assert.Equal("07", Ablesekennzeichen.SchaetzungNachVergleichbarenZeitraeumen.Schluessel);
            Assert.Equal("Schätzung nach vergleichbaren Zeiträumen", Ablesekennzeichen.SchaetzungNachVergleichbarenZeitraeumen.Bezeichnung);
        }

        [Fact]
        public void SchaetzungNachDurchschnittsverbrauch_Get_ReturnsValue()
        {
            Assert.Equal("08", Ablesekennzeichen.SchaetzungNachDurchschnittsverbrauch.Schluessel);
            Assert.Equal("Schätzung nach Durchschnittsverbrauch", Ablesekennzeichen.SchaetzungNachDurchschnittsverbrauch.Bezeichnung);
        }

        [Fact]
        public void NurKostenlieferung_Get_ReturnsValue()
        {
            Assert.Equal("10", Ablesekennzeichen.NurKostenlieferung.Schluessel);
            Assert.Equal("nur Kostenlieferung", Ablesekennzeichen.NurKostenlieferung.Bezeichnung);
        }

        [Fact]
        public void Hauptablesung_Get_ReturnsValue()
        {
            Assert.Equal("11", Ablesekennzeichen.Hauptablesung.Schluessel);
            Assert.Equal("Hauptablesung", Ablesekennzeichen.Hauptablesung.Bezeichnung);
        }

        [Fact]
        public void Zwischenablesung_Get_ReturnsValue()
        {
            Assert.Equal("12", Ablesekennzeichen.Zwischenablesung.Schluessel);
            Assert.Equal("Zwischenablesung", Ablesekennzeichen.Zwischenablesung.Bezeichnung);
        }

        [Fact]
        public void AufteilungNachTagen_Get_ReturnsValue()
        {
            Assert.Equal("13", Ablesekennzeichen.AufteilungNachTagen.Schluessel);
            Assert.Equal("Aufteilung nach Tagen", Ablesekennzeichen.AufteilungNachTagen.Bezeichnung);
        }

        [Fact]
        public void AufteilungNachGradtagen_Get_ReturnsValue()
        {
            Assert.Equal("14", Ablesekennzeichen.AufteilungNachGradtagen.Schluessel);
            Assert.Equal("Aufteilung nach Gradtagen", Ablesekennzeichen.AufteilungNachGradtagen.Bezeichnung);
        }

        [Fact]
        public void SchaetzungNachVergleichbarenRaeumen_Get_ReturnsValue()
        {
            Assert.Equal("15", Ablesekennzeichen.SchaetzungNachVergleichbarenRaeumen.Schluessel);
            Assert.Equal("Schätzung nach vergleichbaren Räumen", Ablesekennzeichen.SchaetzungNachVergleichbarenRaeumen.Bezeichnung);
        }

        #endregion

        #region FromString()

        [Fact]
        public void FromString_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Ablesekennzeichen.FromString(null));
            Assert.Equal("ablesekennzeichen", ex.ParamName);
        }

        [Fact]
        public void FromString_StringEmpty_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Ablesekennzeichen.FromString(string.Empty));
            Assert.Equal("ablesekennzeichen", ex.ParamName);
        }

        [Fact]
        public void FromString_StringNotKnown_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Ablesekennzeichen.FromString("1"));
            Assert.Equal("ablesekennzeichen", ex.ParamName);
        }

        [Fact]
        public void FromString_StringKnown_ReturnsValue()
        {
            Assert.Equal(Ablesekennzeichen.Hauptablesung, Ablesekennzeichen.FromString(Ablesekennzeichen.Hauptablesung.Schluessel));
        }

        #endregion

        #region ToString()

        [Fact]
        public void ToString_ReturnsStringLength2()
        {
            Assert.Equal(2, Ablesekennzeichen.Hauptablesung.ToString().Length);
        }

        [Fact]
        public void ToString_ReturnsSchluesselValue()
        {
            Assert.Equal(Ablesekennzeichen.Hauptablesung.Schluessel, Ablesekennzeichen.Hauptablesung.ToString());
        }

        #endregion
    }
}
