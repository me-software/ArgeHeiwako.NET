using ArgeHeiwako.Data.Common;
using System;

namespace ArgeHeiwako.Data
{
    /// <summary>
    /// Diese Klasse repräsentiert den Satz zum Austausch des Anteil an steuerlichen Leistungsarten 
    /// eines Nutzers (E835 Format im Standarddatenaustausch 3.05 der ARGE Heiwako)
    /// </summary>
    public sealed class AnteilSteuerlicheLeistungsart
    {
        /// <summary>
        /// Kennzeichnung der Satzart
        /// </summary>
        public const string Satzart = "E835";

        private Kostenart kostenart;
        private Tag letzterTagNutzungszeitraum;
        private Betrag lohnanteilNutzerAnteil;
        private Betrag lohnanteilRechnungsbetrag;
        private Betrag nutzerAnteil;
        private ErweiterterOrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen;
        private OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen;
        private Prozent prozentualerNutzerAnteil;
        private Betrag rechnungsbetrag;
        private SteuerlicheLeistungsart steuerlicheLeistungsart;

        /// <summary>
        /// Erstellt eine neue <see cref="AnteilSteuerlicheLeistungsart"/>-Instanz
        /// </summary>
        /// <param name="ordnungsbegriffAbrechnungsunternehmen"></param>
        /// <param name="ordnungsbegriffWohnungsunternehmen"></param>
        /// <param name="kostenart"></param>
        /// <param name="steuerlicheLeistungsart"></param>
        /// <param name="rechnungsbetrag"></param>
        /// <param name="nutzerAnteil"></param>
        /// <param name="prozentualerNutzerAnteil"></param>
        /// <param name="lohnanteilRechnungsbetrag"></param>
        /// <param name="lohnanteilNutzerAnteil"></param>
        /// <param name="letzterTagNutzungszeitraum"></param>
        public AnteilSteuerlicheLeistungsart(
            ErweiterterOrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen,
            OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen,
            Kostenart kostenart,
            SteuerlicheLeistungsart steuerlicheLeistungsart,
            Betrag rechnungsbetrag,
            Betrag nutzerAnteil,
            Prozent prozentualerNutzerAnteil,
            Betrag lohnanteilRechnungsbetrag,
            Betrag lohnanteilNutzerAnteil,
            Tag letzterTagNutzungszeitraum)
        {
            #region Contracts
            if (ordnungsbegriffAbrechnungsunternehmen == null)
                throw new ArgumentNullException(nameof(ordnungsbegriffAbrechnungsunternehmen));
            if (ordnungsbegriffWohnungsunternehmen == null)
                throw new ArgumentNullException(nameof(ordnungsbegriffWohnungsunternehmen));
            if (kostenart == null)
                throw new ArgumentNullException(nameof(kostenart));
            if (steuerlicheLeistungsart == null)
                throw new ArgumentNullException(nameof(steuerlicheLeistungsart));
            if (rechnungsbetrag == null)
                throw new ArgumentNullException(nameof(rechnungsbetrag));
            if (nutzerAnteil == null)
                throw new ArgumentNullException(nameof(nutzerAnteil));
            if (prozentualerNutzerAnteil == null)
                throw new ArgumentNullException(nameof(prozentualerNutzerAnteil));
            if (lohnanteilRechnungsbetrag == null)
                throw new ArgumentNullException(nameof(lohnanteilRechnungsbetrag));
            if (lohnanteilNutzerAnteil == null)
                throw new ArgumentNullException(nameof(lohnanteilNutzerAnteil));
            if (letzterTagNutzungszeitraum == null)
                throw new ArgumentNullException(nameof(letzterTagNutzungszeitraum));
            #endregion

            this.ordnungsbegriffAbrechnungsunternehmen = ordnungsbegriffAbrechnungsunternehmen;
            this.ordnungsbegriffWohnungsunternehmen = ordnungsbegriffWohnungsunternehmen;
            this.kostenart = kostenart;
            this.steuerlicheLeistungsart = steuerlicheLeistungsart;
            this.rechnungsbetrag = rechnungsbetrag;
            this.nutzerAnteil = nutzerAnteil;
            this.prozentualerNutzerAnteil = prozentualerNutzerAnteil;
            this.lohnanteilRechnungsbetrag = lohnanteilRechnungsbetrag;
            this.lohnanteilNutzerAnteil = lohnanteilNutzerAnteil;
            this.letzterTagNutzungszeitraum = letzterTagNutzungszeitraum;
        }

        /// <summary>
        /// Setzt oder Liefert die optionale <see cref="Common.Satzfolgenummer"/>
        /// </summary>
        public Satzfolgenummer Satzfolgenummer { get; set; }

        /// <summary>
        /// Setzt oder Liefert das optionale <see cref="Common.Abrechnungsunternehmen"/>
        /// </summary>
        public Abrechnungsunternehmen Abrechnungsunternehmen { get; set; }

        /// <summary>
        /// Setzt oder Liefert die optionale <see cref="Common.AbrechnungsfolgeNummer"/>
        /// </summary>
        public AbrechnungsfolgeNummer AbrechnungsfolgeNummer { get; set; }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return string.Format(
                "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}",
                Satzart,
                (Satzfolgenummer == null ? new string(' ', 7) : Satzfolgenummer.ToString()),
                (Abrechnungsunternehmen == null ? new string(' ', 2) : Abrechnungsunternehmen.ToString()),
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                (AbrechnungsfolgeNummer == null ? new string(' ', 1) : AbrechnungsfolgeNummer.ToString()),
                kostenart,
                new string(' ', 25), // TODO: Implementieren des individuellen Textes
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum);
        }
    }
}
