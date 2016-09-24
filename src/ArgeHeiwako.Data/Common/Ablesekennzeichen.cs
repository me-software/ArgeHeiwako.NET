using System;
using System.Collections.Generic;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert die für den Datenaustausch definierten Schätzungsaufteilungen sowie die 
    /// Ablesekennzeichen aus der Tabelle "S"
    /// </summary>
    public sealed class Ablesekennzeichen
    {
        #region Tabelle "S"

        private static readonly IDictionary<string, Ablesekennzeichen> ablesekennzeichenDictionary = new Dictionary<string, Ablesekennzeichen> {
             { "01", Schaetzung = new Ablesekennzeichen("01", "Schätzung") },
             { "02", SchaetzungNachVorjahr = new Ablesekennzeichen("02", "Schätzung nach Vorjahr") },
             { "03", SchaetzungNachNormwaermeleistung = new Ablesekennzeichen("03", "Schätzung nach Normwärmeleistung") },
             { "04", SchaetzungNachGrundanteil = new Ablesekennzeichen("04", "Schätzung nach Grundanteil(z.B. 1 WMZ pro Nutzeinheit)") },
             { "05", Teilschaetzung = new Ablesekennzeichen("05", "Teilschätzung") },
             { "06", SchaetzungNachFlaeche = new Ablesekennzeichen("06", "Schätzung nach Fläche") },
             { "07", SchaetzungNachVergleichbarenZeitraeumen = new Ablesekennzeichen("07", "Schätzung nach vergleichbaren Zeiträumen") },
             { "08", SchaetzungNachDurchschnittsverbrauch = new Ablesekennzeichen("08", "Schätzung nach Durchschnittsverbrauch") },
             { "10", NurKostenlieferung = new Ablesekennzeichen("10", "nur Kostenlieferung") },
             { "11", Hauptablesung = new Ablesekennzeichen("11", "Hauptablesung") },
             { "12", Zwischenablesung = new Ablesekennzeichen("12", "Zwischenablesung") },
             { "13", AufteilungNachTagen = new Ablesekennzeichen("13", "Aufteilung nach Tagen") },
             { "14", AufteilungNachGradtagen = new Ablesekennzeichen("14", "Aufteilung nach Gradtagen") },
             { "15", SchaetzungNachVergleichbarenRaeumen = new Ablesekennzeichen("15", "Schätzung nach vergleichbaren Räumen") },
            };
        private readonly string schluessel;
        private readonly string bezeichnung;

        private Ablesekennzeichen(string schluessel, string bezeichnung)
        {
            this.schluessel = schluessel;
            this.bezeichnung = bezeichnung;
        }

        #endregion

        #region Schnellzugriffe

        /// <summary>
        /// Schätzung
        /// </summary>
        public static Ablesekennzeichen Schaetzung { get; private set; }

        /// <summary>
        /// Schätzung nach Vorjahr
        /// </summary>
        public static Ablesekennzeichen SchaetzungNachVorjahr { get; private set; }

        /// <summary>
        /// Schätzung nach Normwärmeleistung
        /// </summary>
        public static Ablesekennzeichen SchaetzungNachNormwaermeleistung { get; private set; }

        /// <summary>
        /// Schätzung nach Grundanteil
        /// </summary>
        public static Ablesekennzeichen SchaetzungNachGrundanteil { get; private set; }

        /// <summary>
        /// Teilschätzung
        /// </summary>
        public static Ablesekennzeichen Teilschaetzung { get; private set; }

        /// <summary>
        /// Schätzung nach Fläche
        /// </summary>
        public static Ablesekennzeichen SchaetzungNachFlaeche { get; private set; }

        /// <summary>
        /// Schätzung nach vergleichbaren Zeiträumen
        /// </summary>
        public static Ablesekennzeichen SchaetzungNachVergleichbarenZeitraeumen { get; private set; }

        /// <summary>
        /// Schätzung nach Durchschnittsverbrauch
        /// </summary>
        public static Ablesekennzeichen SchaetzungNachDurchschnittsverbrauch { get; private set; }

        /// <summary>
        /// Nur Kostenlieferung
        /// </summary>
        public static Ablesekennzeichen NurKostenlieferung { get; private set; }

        /// <summary>
        /// Hauptablesung
        /// </summary>
        public static Ablesekennzeichen Hauptablesung { get; private set; }

        /// <summary>
        /// Zwischenablesung
        /// </summary>
        public static Ablesekennzeichen Zwischenablesung { get; private set; }

        /// <summary>
        /// Aufteilung nach Tagen
        /// </summary>
        public static Ablesekennzeichen AufteilungNachTagen { get; private set; }

        /// <summary>
        /// Aufteilung nach Gradtagen
        /// </summary>
        public static Ablesekennzeichen AufteilungNachGradtagen { get; private set; }

        /// <summary>
        /// Schätzung nach vergleichbaren Räumen
        /// </summary>
        public static Ablesekennzeichen SchaetzungNachVergleichbarenRaeumen { get; private set; }

        #endregion

        /// <summary>
        /// Liefert den Schlüssel für das Ablesekennzeichen in der Datenaustauschdatei
        /// </summary>
        public string Schluessel { get { return schluessel; } }

        /// <summary>
        /// Liefert die textuelle Bedeutung des Schlüssels
        /// </summary>
        public string Bezeichnung { get { return bezeichnung; } }
        
        /// <summary>
        /// Ermittelt das Ablesekennzeichen anhand des Schlüssels, der in der Datenaustauschdatei verwendet wird.
        /// </summary>
        /// <param name="ablesekennzeichen">Der textuelle Schlüssel aus der Datenaustauschdatei</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Wenn für <paramref name="ablesekennzeichen"/> NULL übergeben wird.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn für den Wert in <paramref name="ablesekennzeichen"/> kein Ablesenkennzeichen bekannt ist.</exception>
        public static Ablesekennzeichen FromString(string ablesekennzeichen)
        {
            if (ablesekennzeichen == null)
            {
                throw new ArgumentNullException(nameof(ablesekennzeichen));
            }
            if (ablesekennzeichen == string.Empty || !ablesekennzeichenDictionary.ContainsKey(ablesekennzeichen))
            {
                throw new ArgumentOutOfRangeException(nameof(ablesekennzeichen));
            }

            return ablesekennzeichenDictionary[ablesekennzeichen];
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return Schluessel;
        }
    }
}