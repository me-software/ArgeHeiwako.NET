namespace ArgeHeiwako.Data
{
    /// <summary>
    /// Diese Klasse repräsentiert den Ordnungsbegriff eines Abrechnungsunternehmens
    /// </summary>
    /// <remarks>
    /// Ein Abrechnungsunternehmen verwendet grundsätzlich den Begriff einer Liegenschaft. Eine Liegenschaft ist in 
    /// unterschiedliche Einheiten gegliedert, unter denen die Kosten aufgeteilt werden. 
    /// </remarks>
    public sealed class OrdnungsbegriffAbrechnungsunternehmen
    {
        private LiegenschaftsNummer liegenschaftsNummer;
        private WohnungsNummer wohnungsNummer;

        /// <summary>
        /// Erstellt eine neue <see cref="OrdnungsbegriffAbrechnungsunternehmen"/>-Instanz
        /// </summary>
        /// <param name="liegenschaftsNummer">Identifikationsnummer der Liegenschaft</param>
        /// <param name="wohnungsNummer">Identifikationsnummer der Wohnung / Einheit</param>
        public OrdnungsbegriffAbrechnungsunternehmen(LiegenschaftsNummer liegenschaftsNummer, WohnungsNummer wohnungsNummer)
        {
            this.liegenschaftsNummer = liegenschaftsNummer;
            this.wohnungsNummer = wohnungsNummer;
        }

        /// <summary>
        ///Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei</returns>
        public override string ToString()
        {
            return $"{liegenschaftsNummer}{wohnungsNummer}";
        }
    }
}