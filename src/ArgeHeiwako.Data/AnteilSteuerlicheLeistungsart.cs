using ArgeHeiwako.Data.Common;
using System;
using System.Collections.Generic;

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

        private readonly Kostenart kostenart;
        private readonly SteuerlicheLeistungsart steuerlicheLeistungsart;
        private readonly Betrag lohnanteilNutzerAnteil;
        private readonly Betrag lohnanteilRechnungsbetrag;
        private readonly Betrag nutzerAnteil;
        private readonly ErweiterterOrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen;
        private readonly OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen;
        private readonly Prozent prozentualerNutzerAnteil;
        private readonly Betrag rechnungsbetrag;
        private readonly Tag letzterTagNutzungszeitraum;
        private readonly Abrechnungsunternehmen abrechnungsunternehmen;
        private readonly string kostenartText;
        private readonly Satzfolgenummer satzfolgeNummer;
        private readonly AbrechnungsfolgeNummer abrechnungsfolgeNummer;

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
        /// <param name="satzfolgeNummer"></param>
        /// <param name="abrechnungsunternehmen"></param>
        /// <param name="abrechnungsfolgeNummer"></param>
        /// <param name="kostenartText"></param>
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
            Tag letzterTagNutzungszeitraum,
            Satzfolgenummer satzfolgeNummer = null,
            Abrechnungsunternehmen abrechnungsunternehmen = null,
            AbrechnungsfolgeNummer abrechnungsfolgeNummer = null,
            string kostenartText = null)
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
            if (kostenartText != null && kostenartText.Length > 25)
                throw new ArgumentOutOfRangeException(nameof(kostenartText));
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

            this.satzfolgeNummer = satzfolgeNummer;
            this.abrechnungsunternehmen = abrechnungsunternehmen;
            this.abrechnungsfolgeNummer = abrechnungsfolgeNummer;
            this.kostenartText = kostenartText;

            if (kostenart.VariableBedeutung && kostenartText == null)
                throw new ArgumentNullException(nameof(kostenartText));
        }

        /// <summary>
        /// Setzt oder Liefert die optionale <see cref="Common.Satzfolgenummer"/>
        /// </summary>
        public Satzfolgenummer Satzfolgenummer { get { return satzfolgeNummer; } }

        /// <summary>
        /// Setzt oder Liefert das optionale <see cref="Common.Abrechnungsunternehmen"/>
        /// </summary>
        public Abrechnungsunternehmen Abrechnungsunternehmen { get { return abrechnungsunternehmen; } }

        /// <summary>
        /// Setzt oder Liefert die optionale <see cref="Common.AbrechnungsfolgeNummer"/>
        /// </summary>
        public AbrechnungsfolgeNummer AbrechnungsfolgeNummer { get { return abrechnungsfolgeNummer; } }

        /// <summary>
        /// Liefert die <see cref="Common.Kostenart"/> 
        /// </summary>
        public Kostenart Kostenart { get { return kostenart; } }

        /// <summary>
        /// Liefert den <see cref="Common.ErweiterterOrdnungsbegriffAbrechnungsunternehmen"/>
        /// </summary>
        public ErweiterterOrdnungsbegriffAbrechnungsunternehmen OrdnungsbegriffAbrechnungsunternehmen
        {
            get { return ordnungsbegriffAbrechnungsunternehmen; }
        }

        /// <summary>
        /// Liefert den <see cref="Common.OrdnungsbegriffWohnungsunternehmen"/>
        /// </summary>
        public OrdnungsbegriffWohnungsunternehmen OrdnungsbegriffWohnungsunternehmen
        {
            get { return ordnungsbegriffWohnungsunternehmen; }
        }

        /// <summary>
        /// Liefert die <see cref="Common.SteuerlicheLeistungsart"/>
        /// </summary>
        public SteuerlicheLeistungsart SteuerlicheLeistungsart { get { return steuerlicheLeistungsart; } }

        /// <summary>
        /// Liefert den gesamten Rechnungsbetrag
        /// </summary>
        public Betrag Rechnungsbetrag { get { return rechnungsbetrag; } }

        /// <summary>
        /// Liefert den Betrag des Anteil des Nutzers am <see cref="Rechnungsbetrag"/>
        /// </summary>
        public Betrag NutzerAnteil { get { return nutzerAnteil; } }

        /// <summary>
        /// Liefert den prozentualen Anteil des Nutzers am <see cref="Rechnungsbetrag"/>
        /// </summary>
        public Prozent ProzentualerNutzerAnteil { get { return prozentualerNutzerAnteil; } }

        /// <summary>
        /// Liefert den Betrag des Lohnanteils des <see cref="Rechnungsbetrag"/>s
        /// </summary>
        public Betrag LohnanteilRechnungsbetrag { get { return lohnanteilRechnungsbetrag; } }

        /// <summary>
        /// Liefert den Lohnanteil im <see cref="NutzerAnteil"/>
        /// </summary>
        public Betrag LohnanteilNutzerAnteil { get { return lohnanteilNutzerAnteil; } }

        /// <summary>
        /// Liefert den letzten Tag des Nutzungszeitraums
        /// </summary>
        public Tag LetzterTagNutzungszeitraum { get { return letzterTagNutzungszeitraum; } }

        /// <summary>
        /// Liefert den optionalen Pflichttext für die Kostenart bei speziellen <see cref="Common.Kostenart"/>en
        /// </summary>
        public string KostenartText
        {
            get { return kostenartText; }
        }

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
                KostenartText != null ? kostenartText.PadRight(25) : new string(' ', 25),
                steuerlicheLeistungsart,
                rechnungsbetrag,
                nutzerAnteil,
                prozentualerNutzerAnteil,
                lohnanteilRechnungsbetrag,
                lohnanteilNutzerAnteil,
                letzterTagNutzungszeitraum);
        }


        /// <summary>
        /// Erstellt eine neue <see cref="AnteilSteuerlicheLeistungsart"/>-Instanz auf Basis einer Zeile in der Datenaustausch-Datei
        /// </summary>
        /// <param name="anteilSteuerlicheLeistungsartString">Die Zeile aus der Datenaustausch-Datei</param>
        /// <returns>Die ausgelesene <see cref="Ordnungsbegriffe"/>-Instanz</returns>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="anteilSteuerlicheLeistungsartString"/> NULL ist</exception>
        /// <exception cref="ArgumentException">Wenn der Parameter <paramref name="anteilSteuerlicheLeistungsartString"/> keinen validen E835-Satz enthält</exception>
        public static AnteilSteuerlicheLeistungsart FromString(string anteilSteuerlicheLeistungsartString)
        {
            if (anteilSteuerlicheLeistungsartString == null)
                throw new ArgumentNullException(nameof(anteilSteuerlicheLeistungsartString));

            if (anteilSteuerlicheLeistungsartString.Length != 133)
                throw new ArgumentOutOfRangeException(nameof(anteilSteuerlicheLeistungsartString));

            throw new NotImplementedException();
        }
    }
}
