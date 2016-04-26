using ArgeHeiwako.Data.Common;
using System;

namespace ArgeHeiwako.Data
{
    /// <summary>
    /// Diese Klasse repräsentiert einen E898-Datensatz, welcher zum Austausch von Abrechnungsdaten in Dokumentform (Bild, PDF, o.a.) genutzt wird.
    /// </summary>
    public class NutzerAbrechnungBild
    {
        /// <summary>
        /// Liefert das Kennzeichen der Satzart für eine <see cref="NutzerAbrechnungBild"/>-Instanz
        /// </summary>
        public const string Satzart = "E898";

        /// <summary>
        /// Liefert die Länge des Datensatzes in der Datenaustausch-Datei
        /// </summary>
        public const int StringLength = 120;

        private readonly BilddateiFolgeNummer bilddateiFolgeNummer;
        private readonly BilddateiPfad bilddateiPfad;
        private readonly Tag letzterTagNutzungszeitraum;
        private readonly ErweiterterOrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen;
        private readonly OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen;
        private readonly SatzfolgeNummer satzfolgeNummer;
        private readonly Abrechnungsunternehmen abrechnungsunternehmen;
        private readonly AbrechnungsfolgeNummer abrechnungsfolgeNummer;
        private readonly Dokumentart dokumentart;

        /// <summary>
        /// Erstellt eine neue <see cref="NutzerAbrechnungBild"/>-Instanz
        /// </summary>
        /// <param name="ordnungsbegriffAbrechnungsunternehmen"></param>
        /// <param name="ordnungsbegriffWohnungsunternehmen"></param>
        /// <param name="bilddateiPfad"></param>
        /// <param name="bilddateiFolgeNummer"></param>
        /// <param name="letzterTagNutzungszeitraum"></param>
        /// <param name="satzfolgeNummer"></param>
        /// <param name="abrechnungsunternehmen"></param>
        /// <param name="abrechnungsfolgeNummer"></param>
        /// <param name="dokumentart"></param>
        public NutzerAbrechnungBild(
            ErweiterterOrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen,
            OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen,
            BilddateiPfad bilddateiPfad,
            BilddateiFolgeNummer bilddateiFolgeNummer,
            Tag letzterTagNutzungszeitraum,
            SatzfolgeNummer satzfolgeNummer = null,
            Abrechnungsunternehmen abrechnungsunternehmen = null,
            AbrechnungsfolgeNummer abrechnungsfolgeNummer = null,
            Dokumentart dokumentart = null)
        {
            if (ordnungsbegriffAbrechnungsunternehmen == null)
                throw new ArgumentNullException(nameof(ordnungsbegriffAbrechnungsunternehmen));
            if (ordnungsbegriffWohnungsunternehmen == null)
                throw new ArgumentNullException(nameof(ordnungsbegriffWohnungsunternehmen));
            if (bilddateiPfad == null)
                throw new ArgumentNullException(nameof(bilddateiPfad));
            if (bilddateiFolgeNummer == null)
                throw new ArgumentNullException(nameof(bilddateiFolgeNummer));
            if (letzterTagNutzungszeitraum == null)
                throw new ArgumentNullException(nameof(letzterTagNutzungszeitraum));

            this.ordnungsbegriffAbrechnungsunternehmen = ordnungsbegriffAbrechnungsunternehmen;
            this.ordnungsbegriffWohnungsunternehmen = ordnungsbegriffWohnungsunternehmen;
            this.bilddateiPfad = bilddateiPfad;
            this.bilddateiFolgeNummer = bilddateiFolgeNummer;
            this.letzterTagNutzungszeitraum = letzterTagNutzungszeitraum;
            this.satzfolgeNummer = satzfolgeNummer;
            this.abrechnungsunternehmen = abrechnungsunternehmen;
            this.abrechnungsfolgeNummer = abrechnungsfolgeNummer;
            this.dokumentart = dokumentart;
        }

        /// <summary>
        /// Liefert den Schlüssel des Abrechnungsunternehmens
        /// </summary>
        public ErweiterterOrdnungsbegriffAbrechnungsunternehmen OrdnungsbegriffAbrechnungsunternehmen
        {
            get { return ordnungsbegriffAbrechnungsunternehmen; }
        }

        /// <summary>
        /// Liefert den Ordnungsbegriff des Wohnungsunternehmens / Auftraggebers
        /// </summary>
        public OrdnungsbegriffWohnungsunternehmen OrdnungsbegriffWohnungsunternehmen
        {
            get { return ordnungsbegriffWohnungsunternehmen; }
        }

        /// <summary>
        /// Liefert die Bilddatei (Pfad)
        /// </summary>
        public BilddateiPfad BilddateiPfad
        {
            get { return bilddateiPfad; }
        }

        /// <summary>
        /// Liefert die Bilddateti-Folgenummer (Seitenzahl bei einer Seite pro Datei)
        /// </summary>
        public BilddateiFolgeNummer BilddateiFolgeNummer
        {
            get { return bilddateiFolgeNummer; }
        }

        /// <summary>
        /// Liefert den letzten Tag des Nutzungszeitraumes
        /// </summary>
        public Tag LetzterTagNutzungszeitraum
        {
            get { return letzterTagNutzungszeitraum; }
        }

        /// <summary>
        /// Liefert die optionale Satzfolgenummer
        /// </summary>
        public SatzfolgeNummer SatzfolgeNummer { get { return satzfolgeNummer; } }

        /// <summary>
        /// Liefert das optionale Abrechnungsunternehmen
        /// </summary>
        public Abrechnungsunternehmen Abrechnungsunternehmen { get { return abrechnungsunternehmen; } }

        /// <summary>
        /// Liefert das optionale Kennzeichen für die Abrechnungsfolgenummer
        /// </summary>
        public AbrechnungsfolgeNummer AbrechnungsfolgeNummer { get { return abrechnungsfolgeNummer; } }

        /// <summary>
        /// Liefert die optionale Dokumentart
        /// </summary>
        public Dokumentart Dokumentart { get { return dokumentart; } }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",
                Satzart,
                (satzfolgeNummer == null) ? new string(' ', 7) : satzfolgeNummer.ToString(),
                (abrechnungsunternehmen == null) ? new string(' ', 2) : abrechnungsunternehmen.ToString(),
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                (abrechnungsfolgeNummer == null) ? " " : abrechnungsfolgeNummer.ToString(),
                bilddateiPfad,
                bilddateiFolgeNummer,
                letzterTagNutzungszeitraum,
                (dokumentart == null) ? "   " : dokumentart.ToString());
        }

        /// <summary>
        /// Erstellt eine neue <see cref="NutzerAbrechnungBild"/>-Instanz auf Basis des <see cref="string"/> aus der Datenaustausch-Datei
        /// </summary>
        /// <param name="nutzerAbrechnungBildString">Der <see cref="string"/> aus der Datenaustausch-Datei</param>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="nutzerAbrechnungBildString"/> NULL ist</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Parameter <paramref name="nutzerAbrechnungBildString"/> einen nicht gültigen E898-Datensatz beinhaltet.</exception>
        public static NutzerAbrechnungBild FromString(string nutzerAbrechnungBildString)
        {
            if (nutzerAbrechnungBildString == null)
                throw new ArgumentNullException(nameof(nutzerAbrechnungBildString));
            if (nutzerAbrechnungBildString.Length != StringLength || !nutzerAbrechnungBildString.StartsWith(Satzart))
                throw new ArgumentOutOfRangeException(nameof(nutzerAbrechnungBildString));

            var ordnungsbegriffAbrechnungsunternehmen = ErweiterterOrdnungsbegriffAbrechnungsunternehmen.FromString(nutzerAbrechnungBildString.Substring(13, 18));
            var ordnungsbegriffWohnungsunternehmen = new OrdnungsbegriffWohnungsunternehmen(nutzerAbrechnungBildString.Substring(31, 20));
            var bilddateiPfad = new BilddateiPfad(nutzerAbrechnungBildString.Substring(52, 56));
            var bilddateiFolgeNummer = new BilddateiFolgeNummer(nutzerAbrechnungBildString.Substring(108, 3));
            var letzterTagNutzungszeitraum = new Tag(nutzerAbrechnungBildString.Substring(111, 6));

            var satzfolgeNummerString = nutzerAbrechnungBildString.Substring(4, 7).Trim();
            var satzfolgeNummer = satzfolgeNummerString == string.Empty ? null : new SatzfolgeNummer(satzfolgeNummerString);

            var abrechnungsunternehmenString = nutzerAbrechnungBildString.Substring(11, 2).Trim();
            var abrechnungsunternehmen = abrechnungsunternehmenString == string.Empty ? null : Abrechnungsunternehmen.Finde(abrechnungsunternehmenString);

            var abrechnungsfolgeNummerString = nutzerAbrechnungBildString.Substring(51, 1).Trim();
            var abrechnungsfolgeNummer = abrechnungsfolgeNummerString == string.Empty ? null : new AbrechnungsfolgeNummer(abrechnungsfolgeNummerString);

            var dokumentartString = nutzerAbrechnungBildString.Substring(117, 3).Trim();
            var dokumentart = dokumentartString == string.Empty ? null : (Dokumentart)dokumentartString;

            return new NutzerAbrechnungBild(
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                bilddateiPfad, bilddateiFolgeNummer,
                letzterTagNutzungszeitraum,
                satzfolgeNummer,
                abrechnungsunternehmen,
                abrechnungsfolgeNummer,
                dokumentart);
        }
    }
}