namespace ArgeHeiwako.Data
{
    public sealed class OrdnungsbegriffAbrechnungsunternehmen
    {
        private LiegenschaftsNummer liegenschaftsNummer;
        private WohnungsNummer wohnungsNummer;

        public OrdnungsbegriffAbrechnungsunternehmen(LiegenschaftsNummer liegenschaftsNummer, WohnungsNummer wohnungsNummer)
        {
            this.liegenschaftsNummer = liegenschaftsNummer;
            this.wohnungsNummer = wohnungsNummer;
        }

        public override string ToString()
        {
            return $"{liegenschaftsNummer}{wohnungsNummer}";
        }
    }
}