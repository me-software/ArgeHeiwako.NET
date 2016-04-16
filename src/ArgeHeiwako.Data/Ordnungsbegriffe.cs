using ArgeHeiwako.Data.Properties;
using System;
using ArgeHeiwako.Data.Common;

namespace ArgeHeiwako.Data
{
    /// <summary>
    /// Diese Klasse repräsentiert die Satzart A, welche für Austausch der Ordnungsbegriffe zwischen
    /// Abrechnungs- und Wohnungsunternehmen verwendet wird.
    /// </summary>
    public sealed class Ordnungsbegriffe
    {
        /// <summary>
        /// Die Kennzeichnung der Satzart
        /// </summary>
        public const string Satzart = "A";
        
        private readonly ArgeVersion version;
        private readonly KundenNummer kundenNummer;
        private readonly OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen;
        private readonly OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen;
        private readonly Abrechnungsunternehmen unternehmen;

        /// <summary>
        /// Liefert die verwendete <see cref="ArgeVersion"/> für den Datenaustausch
        /// </summary>
        public ArgeVersion Version
        {
            get { return version; }
        }

        /// <summary>
        /// Liefert die Kundennummer des Wohnungsunternehmens, wie sie beim Abrechnungsunternehmen geführt wird
        /// </summary>
        public KundenNummer KundenNummer
        {
            get { return kundenNummer; }
        }

        /// <summary>
        /// Liefert das Abrechnungsunternehmen oder NULL, falls nicht gesetzt.
        /// </summary>
        public Abrechnungsunternehmen Abrechnungsunternehmen
        {
            get { return unternehmen; }
        }

        /// <summary>
        /// Liefert den vom Abrechnungsunternehmen verwendeten Ordnungsbegriff
        /// </summary>
        public OrdnungsbegriffAbrechnungsunternehmen OrdnungsbegriffAbrechnungsunternehmen
        {
            get { return ordnungsbegriffAbrechnungsunternehmen; }
        }

        /// <summary>
        /// Liefert den vom Wohnungsunternehmen verwendeten Ordnungsbegriff
        /// </summary>
        public OrdnungsbegriffWohnungsunternehmen OrdnungsbegriffWohnungsunternehmen
        {
            get { return ordnungsbegriffWohnungsunternehmen; }
        }

        /// <summary>
        /// Erstellt eine neue <see cref="Ordnungsbegriffe"/>-Instanz
        /// </summary>
        /// <param name="version">Verwendete <see cref="ArgeVersion"/></param>
        /// <param name="kundenNummer">Die Nummer des Wohnungsunternehmens wie es beim Abrechnungsunternehmen geführt wird</param>
        /// <param name="ordnungsbegriffAbrechnungsunternehmen">Der vom Abrechnungsunternehmen verwendete Ordnungsbegriff</param>
        /// <param name="ordnungsbegriffWohnungsunternehmen">Der vom Wohnungsunternehmen verwendete Ordnungsbegriff</param>
        public Ordnungsbegriffe(
            ArgeVersion version,
            KundenNummer kundenNummer,
            OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen,
            OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen)
            : this(version, kundenNummer, ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, null)
        {
        }

        /// <summary>
        /// Erstellt eine neue <see cref="Ordnungsbegriffe"/>-Instanz
        /// </summary>
        /// <param name="version">Verwendete <see cref="ArgeVersion"/></param>
        /// <param name="kundenNummer">Die Nummer des Wohnungsunternehmens wie es beim Abrechnungsunternehmen geführt wird</param>
        /// <param name="ordnungsbegriffAbrechnungsunternehmen">Der vom Abrechnungsunternehmen verwendete Ordnungsbegriff</param>
        /// <param name="ordnungsbegriffWohnungsunternehmen">Der vom Wohnungsunternehmen verwendete Ordnungsbegriff</param>
        /// <param name="unternehmen">Das Abrechnungsunternehmen</param>
        public Ordnungsbegriffe(
            ArgeVersion version,
            KundenNummer kundenNummer,
            OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen,
            OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen,
            Abrechnungsunternehmen unternehmen)
        {
            this.version = version;
            this.kundenNummer = kundenNummer;
            this.ordnungsbegriffAbrechnungsunternehmen = ordnungsbegriffAbrechnungsunternehmen;
            this.ordnungsbegriffWohnungsunternehmen = ordnungsbegriffWohnungsunternehmen;
            this.unternehmen = unternehmen;
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return string.Format(
                "{0}{1}{2}{3}{4}{5}{6}{0}",
                Satzart,
                version,
                kundenNummer,
                unternehmen != null ? unternehmen.ToString() : new string(' ', 2),
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                new string(' ', 76));
        }

        /// <summary>
        /// Erstellt eine neue <see cref="Ordnungsbegriffe"/>-Instanz auf Basis einer Zeile in der Datenaustausch-Datei
        /// </summary>
        /// <param name="ordnungsbegriffeString">Die Zeile aus der Datenaustausch-Datei</param>
        /// <returns>Die ausgelesene <see cref="Ordnungsbegriffe"/>-Instanz</returns>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="ordnungsbegriffeString"/> NULL ist</exception>
        /// <exception cref="ArgumentException">Wenn der Parameter <paramref name="ordnungsbegriffeString"/> keinen validen A-Satz enthält</exception>
        public static Ordnungsbegriffe FromString(string ordnungsbegriffeString)
        {
            #region Contracts
            if (ordnungsbegriffeString == null)
                throw new ArgumentNullException("ordnungsbegriffeString");

            if (ordnungsbegriffeString.Length != 128)
                throw new ArgumentException(Resources.EXP_MSG_VALID_A_SATZ_128_CHARACTERS, "ordnungsbegriffeString");

            if (!ordnungsbegriffeString.StartsWith(Satzart) || !ordnungsbegriffeString.EndsWith(Satzart))
                throw new ArgumentException(Resources.EXP_MSG_VALID_A_SATZ_MUST_START_END_WITH_A, "ordnungsbegriffeString");
            #endregion

            var version = new ArgeVersion(ordnungsbegriffeString.Substring(1, 5));
            var kundenNummer = new KundenNummer(ordnungsbegriffeString.Substring(6, 10));
            var abrechnungsunternehmen = Abrechnungsunternehmen.FromString(ordnungsbegriffeString.Substring(16, 2));
            var liegenschaftsNummer = new LiegenschaftsNummer(ordnungsbegriffeString.Substring(18, 9));
            var wohnungsNummer = new WohnungsNummer(ordnungsbegriffeString.Substring(27, 4));
            var ordnungsbegriffWohnungsunternehmen = new OrdnungsbegriffWohnungsunternehmen(ordnungsbegriffeString.Substring(31, 20));

            return new Ordnungsbegriffe(
                version,
                kundenNummer,
                new OrdnungsbegriffAbrechnungsunternehmen(liegenschaftsNummer, wohnungsNummer),
                ordnungsbegriffWohnungsunternehmen,
                abrechnungsunternehmen);
        }
    }
}
