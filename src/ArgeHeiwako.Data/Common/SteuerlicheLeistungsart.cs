using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert eine Steuerliche Leistungsart nach Tabelle "L" des 
    /// standardisierten Datenaustausches nach der ARGE Heiwako
    /// </summary>
    public sealed class SteuerlicheLeistungsart
    {
        #region Tabelle "L"

        private static readonly IDictionary<string, SteuerlicheLeistungsart> tabelleL = new Dictionary<string, SteuerlicheLeistungsart>
        {
            { "00", new SteuerlicheLeistungsart("00", "keine steuerliche Leistungsart") },
            { "01", new SteuerlicheLeistungsart("01", "geringfügige haushaltsnahe Beschäftigungsverhältnisse") },
            { "02", new SteuerlicheLeistungsart("02", "sozialversicherungspflichtige haushaltsnahe Beschäftigungsverhältnisse") },
            { "03", new SteuerlicheLeistungsart("03", "haushaltsnahe Dienstleistungen") },
            { "04", new SteuerlicheLeistungsart("04", "Handwerkerleistungen") },
            { "11", new SteuerlicheLeistungsart("11", "Haushaltsnahe geringfügige Beschäftigungsverhältnisse", true) },
            { "12", new SteuerlicheLeistungsart("12", "Haushaltsnahe geringfügige Beschäftigungsverhältnisse, die nicht unter Abs.1 oder 3 fallen", true) },
            { "13", new SteuerlicheLeistungsart("13", "Handwerkerleistungen", true) },
        };

        #endregion

        private bool istNeueLeistungsart;

        /// <summary>
        /// Liefert den öffentlich verwendeten Schlüssel der steuerlichen Leistungsart
        /// </summary>
        public string Schluessel { get; private set; }

        /// <summary>
        /// Liefert die Bedeutung der steuerlichen Leistungsart
        /// </summary>
        public string Bedeutung { get; private set; }

        private SteuerlicheLeistungsart(string schluessel, string bedeutung)
            : this(schluessel, bedeutung, false)
        {
        }

        private SteuerlicheLeistungsart(string schluessel, string bedeutung, bool istNeueLeistungsart)
        {
            Schluessel = schluessel;
            Bedeutung = bedeutung;
            this.istNeueLeistungsart = istNeueLeistungsart;
        }

        /// <summary>
        /// Überprüft, ob die <see cref="SteuerlicheLeistungsart"/> für den gewählten Zeitraum gültig ist.
        /// </summary>
        /// <param name="letzterTag">Letzter Tag des Abrechnungszeitraums</param>
        /// <returns>Kennzeichen, ob der Schlüssel für den Abrechnungszeitraum verwendet werden kann.</returns>
        public bool IsGueltigFuer(Tag letzterTag)
        {
            var wechselZeitpunkt = new DateTime(2009, 1, 1);
            return Schluessel == "00"
                || (istNeueLeistungsart && letzterTag >= wechselZeitpunkt)
                || (!istNeueLeistungsart && letzterTag < wechselZeitpunkt);
        }

        /// <summary>
        /// Findet eine <see cref="SteuerlicheLeistungsart"/> anhand des im Standard festgelegten Schlüssels
        /// </summary>
        /// <param name="schluessel">Der Schlüssel der <see cref="SteuerlicheLeistungsart"/></param>
        /// <returns>Die <see cref="SteuerlicheLeistungsart"/>-Instanz passend zum Schlüssel</returns>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="schluessel"/> NULL ist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Parameter <paramref name="schluessel"/> keinen gültiges Schlüsselformat enthält</exception>
        public static SteuerlicheLeistungsart Finde(string schluessel)
        {
            if (schluessel == null)
                throw new ArgumentNullException("schluessel");

            if (schluessel.Length != 2)
                throw new ArgumentOutOfRangeException("schluessel");

            int test = 0;
            if (!int.TryParse(schluessel, out test))
                throw new ArgumentOutOfRangeException("schluessel");

            return tabelleL[schluessel];
        }
    }
}
