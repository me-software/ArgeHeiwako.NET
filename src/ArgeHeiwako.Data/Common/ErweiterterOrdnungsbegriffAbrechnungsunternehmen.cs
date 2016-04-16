using System;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert die erweiterte Darstellung des Ordnungsbegriffes des Abrechnungsunternehmens, so wie er in den Datenaustauschsätzen 
    /// E835 oder E898 verwendet wird.
    /// </summary>
    public sealed class ErweiterterOrdnungsbegriffAbrechnungsunternehmen : OrdnungsbegriffAbrechnungsunternehmen
    {
        private readonly NutzergruppenNummer nutzergruppenNummer;
        private readonly Nutzerfolge nutzerfolge;

        /// <summary>
        /// Erstellt eine neue <see cref="ErweiterterOrdnungsbegriffAbrechnungsunternehmen"/>-Instanz
        /// </summary>
        /// <param name="liegenschaftsNummer">Die Liegenschaftsnummer</param>
        /// <param name="nutzergruppenNummer">Die Nutzergruppennummer</param>
        /// <param name="wohnungsNummer">Die Wohnungsnummer</param>
        /// <param name="nutzerfolge">Die Nutzerfolge</param>
        public ErweiterterOrdnungsbegriffAbrechnungsunternehmen(
            LiegenschaftsNummer liegenschaftsNummer,
            NutzergruppenNummer nutzergruppenNummer,
            WohnungsNummer wohnungsNummer,
            Nutzerfolge nutzerfolge)
            : base(liegenschaftsNummer, wohnungsNummer)
        {
            if (nutzergruppenNummer == null)
                throw new ArgumentNullException("nutzergruppenNummer");

            if (nutzerfolge == null)
                throw new ArgumentNullException("nutzerfolge");

            this.nutzergruppenNummer = nutzergruppenNummer;
            this.nutzerfolge = nutzerfolge;
        }

        /// <summary>
        /// Erstellt eine neue <see cref="ErweiterterOrdnungsbegriffAbrechnungsunternehmen"/>-Instanz
        /// </summary>
        /// <param name="erweiterterOrdnungsbegriffAbrechnungsunternehmenString">Die textuelle Darstellung aus der Datenaustauschdatei</param>
        public static ErweiterterOrdnungsbegriffAbrechnungsunternehmen FromString(string erweiterterOrdnungsbegriffAbrechnungsunternehmenString)
        {
            if (erweiterterOrdnungsbegriffAbrechnungsunternehmenString == null)
                throw new ArgumentNullException(nameof(erweiterterOrdnungsbegriffAbrechnungsunternehmenString));

            if (erweiterterOrdnungsbegriffAbrechnungsunternehmenString.Length != 18)
                throw new ArgumentOutOfRangeException(nameof(erweiterterOrdnungsbegriffAbrechnungsunternehmenString));

            var liegenschaftsNummer = new LiegenschaftsNummer(erweiterterOrdnungsbegriffAbrechnungsunternehmenString.Substring(0, 9));
            var nutzergruppenNummer = new NutzergruppenNummer(erweiterterOrdnungsbegriffAbrechnungsunternehmenString.Substring(9, 4));
            var wohnungsNummer = new WohnungsNummer(erweiterterOrdnungsbegriffAbrechnungsunternehmenString.Substring(13, 4));
            var nutzerfolge = new Nutzerfolge(erweiterterOrdnungsbegriffAbrechnungsunternehmenString.Substring(17, 1));

            return new ErweiterterOrdnungsbegriffAbrechnungsunternehmen(liegenschaftsNummer, nutzergruppenNummer, wohnungsNummer, nutzerfolge);
        }

        /// <summary>
        /// Liefert die Nutzergruppen-Nummer
        /// </summary>
        public NutzergruppenNummer NutzergruppenNummer
        {
            get { return nutzergruppenNummer; }
        }

        /// <summary>
        /// Liefert die Nutzerfolge
        /// </summary>
        public Nutzerfolge Nutzerfolge
        {
            get { return nutzerfolge; }
        }

        /// <summary>
        ///Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return $"{LiegenschaftsNummer}{NutzergruppenNummer}{WohnungsNummer}{Nutzerfolge}";
        }
    }
}
