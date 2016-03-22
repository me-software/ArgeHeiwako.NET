using System;
using System.Collections.Generic;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert eine Kostenart aus der Tabelle "K" des Standarddatenaustausches
    /// nach der ARGE Heiwako.
    /// </summary>
    public sealed class Kostenart
    {
        #region Tabelle "K"

        private static readonly IDictionary<string, Kostenart> tabelleK = new Dictionary<string, Kostenart>()
        {
            {"050", new Kostenart( "050", "Arbeitspreis Raumheizung")},
            {"051", new Kostenart( "051", "Netzverlust Raumheizung") },
            {"052", new Kostenart( "052", "Grundpreis Raumheizung") },
            {"053", new Kostenart( "053", "Mengenpreis Raumheizung")},
            {"054", new Kostenart( "054", "Eichgebühr Raumheizung")},
            {"055", new Kostenart( "055", "Umweltschutzkosten Raumheizung")},
            {"056", new Kostenart( "056", "Strom- und Regelkosten Raumheizung")},
            {"057", new Kostenart( "057", "Anschaffungskosten Messeinrichtungen Raumheizung")},
            {"058", new Kostenart( "058", "Servicekosten der Messdienstfirma Raumheizung")},
            {"059", new Kostenart( "059", "Arbeitspreis Warmwasser")},
            {"060", new Kostenart( "060", "Grundpreis Warmwasser")},
            {"061", new Kostenart( "061", "Mengenpreis Warmwasser")},
            {"062", new Kostenart( "062", "Eichgebühr Warmwasser")},
            {"063", new Kostenart( "063", "Umweltschutzkosten Warmwasser")},
            {"064", new Kostenart( "064", "Strom- und Regelkosten Warmwasser")},
            {"065", new Kostenart( "065", "Anschaffungskosten Messeinrichtungen Warmwasser")},
            {"066", new Kostenart( "066", "Servicekosten der Messdienstfirma Warmwasser")},
            {"067", new Kostenart( "067", "Dienstleistung")},
            {"068", new Kostenart( "068", "Gerätevertrag Miete")},
            {"069", new Kostenart( "069", "Gerätevertrag Wartung")},
            {"070", new Kostenart( "070", "Sonstige Leistungen")},
            {"200", new Kostenart( "200", "Anfangsstand")},
            {"201", new Kostenart( "201", "Lieferung / Rechnung")},
            {"202", new Kostenart( "202", "Restbestand")},
            {"203", new Kostenart( "203", "Brennstoffverbrauch")},
            {"220", new Kostenart( "220", "Betriebsstrom")},
            {"221", new Kostenart( "221", "Wartungskosten")},
            {"222", new Kostenart( "222", "Bedienungskosten")},
            {"223", new Kostenart( "223", "Reinigungskosten")},
            {"224", new Kostenart( "224", "Immissionsmessung")},
            {"225", new Kostenart( "225", "Kaminfeger")},
            {"226", new Kostenart( "226", "Tankreinigung")},
            {"227", new Kostenart( "227", "Servicekosten der Messdienstfirma")},
            {"228", new Kostenart( "228", "variables Textfeld HZG + WW", true)},
            {"229", new Kostenart( "229", "Brennerwartung")},
            {"230", new Kostenart( "230", "Gesamtkosten")},
            {"231", new Kostenart( "231", "Kosten HZG + WW")},
            {"232", new Kostenart( "232", "Kaltwasser für Warmwasser Währungseinheit/Gesamt")},
            {"233", new Kostenart( "233", "Kaltwasser für Warmwasser Währungseinheit/m3")},
            {"234", new Kostenart( "234", "Kosten HZG")},
            {"235", new Kostenart( "235", "Kosten WW")},
            {"236", new Kostenart( "236", "Kosten Frisch- und Abwasser")},
            {"237", new Kostenart( "237", "Kosten Frischwasser")},
            {"238", new Kostenart( "238", "Kosten Abwasser")},
            {"239", new Kostenart( "239", "Kosten Oberflächenentwässerung")},
            {"240", new Kostenart( "240", "Kaltwasser Betrag")},
            {"241", new Kostenart( "241", "Kaltwasser Preis/m3")},
            {"242", new Kostenart( "242", "variables Textfeld BKA", true)},
            {"243", new Kostenart( "243", "Eichgebühr Kaltwasser")},
            {"244", new Kostenart( "244", "Kaltwasser, Abwasser und weitere(= sonstige kalte) Betriebskosten")},
            {"245", new Kostenart( "245", "Frisch- und Abwasser Preis/m³")},
            {"246", new Kostenart( "246", "Abwasser Preis/m³")},
            {"247", new Kostenart( "247", "Trinkwasserprüfung")},
            {"250", new Kostenart( "250", "Zwischenablesung")},
            {"251", new Kostenart( "251", "Kosten Nutzerwechsel")},
            {"252", new Kostenart( "252", "Kosten Schätzung")},
            {"253", new Kostenart( "253", "Kosten MwSt-Errechnung")},
            {"254", new Kostenart( "254", "variables Textfeld direktzugeordnete Nebenkosten", true)},
            {"255", new Kostenart( "255", "Zusätzlicher Ablesetermin")},
            {"256", new Kostenart( "256", "Zwischenablese- und Nutzerwechselkosten")},
            {"257", new Kostenart( "257", "Summe Sonderkosten")},
            {"258", new Kostenart( "258", "Direktkosten(Nutzer)")},
            {"259", new Kostenart( "259", "Weitere Betriebskosten")},
            {"260", new Kostenart( "260", "Nicht umlagefähige Kosten")},
            {"300", new Kostenart( "300", "Gerätemiete Heizkostenverteiler")},
            {"301", new Kostenart( "301", "Gerätemiete Warmwasserzähler")},
            {"302", new Kostenart( "302", "Gerätemiete Wärmemengenzähler")},
            {"303", new Kostenart( "303", "Gerätemiete Kaltwasserzähler")},
            {"304", new Kostenart( "304", "Verbrauchsanalyse")},
            {"305", new Kostenart( "305", "Gerätewartung Warmwasserzähler")},
            {"306", new Kostenart( "306", "Gerätewartung Wärmemengenzähler")},
            {"307", new Kostenart( "307", "Gerätewartung Kaltwasserzähler")},
            {"308", new Kostenart( "308", "Gerätemiete Rauchwarnmelder")},
            {"309", new Kostenart( "309", "Gerätewartung Rauchwarnmelder")},
            {"310", new Kostenart( "310", "Funktionsprüfung Rauchwarnmelder")},
            {"311", new Kostenart( "311", "variables Textfeld Rauchwarnmelder", true)},
        };

        #endregion

        /// <summary>
        /// Liefert den öffentlich verwendeten Schlüssel der Kostenart
        /// </summary>
        public string Schluessel { get; private set; }

        /// <summary>
        /// Liefert die Bedeutung der Kostenart
        /// </summary>
        public string Bedeutung { get; private set; }

        /// <summary>
        /// Liefert das Kennzeichen, ob für diese Kostenart eine variable Bedeutung benötigt wird
        /// </summary>
        public bool VariableBedeutung { get; private set; }

        private Kostenart(string schluessel, string bedeutung)
            : this(schluessel, bedeutung, false)
        {
        }

        private Kostenart(string schluessel, string bedeutung, bool variableBedeutung)
        {
            Schluessel = schluessel;
            Bedeutung = bedeutung;
            VariableBedeutung = variableBedeutung;
        }

        /// <summary>
        /// Ermittelt die Kostenart auf Basis des öffentlichen Schlüssels
        /// </summary>
        /// <param name="schluessel">Der öffentliche Schlüssel für die verwendete <see cref="Kostenart"/></param>
        /// <returns>Die gefundene <see cref="Kostenart"/>-Instanz</returns>
        public static Kostenart Finde(string schluessel)
        {
            if (schluessel == null)
                throw new ArgumentNullException("schluessel");

            if (schluessel.Length != 3)
                throw new ArgumentOutOfRangeException("schluessel");

            int test = 0;
            if (!int.TryParse(schluessel, out test))
                throw new ArgumentOutOfRangeException("schluessel");

            return tabelleK[schluessel];
        }
    }
}
