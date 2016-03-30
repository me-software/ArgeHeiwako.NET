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
        /// test
        /// </summary>
        /// <param name="liegenschaftsNummer"></param>
        /// <param name="nutzergruppenNummer"></param>
        /// <param name="wohnungsNummer"></param>
        /// <param name="nutzerfolge"></param>
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
