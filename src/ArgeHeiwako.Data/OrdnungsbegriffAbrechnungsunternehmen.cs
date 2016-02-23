namespace ArgeHeiwako.Data
{
    public sealed class OrdnungsbegriffAbrechnungsunternehmen
    {
        private int liegenschaftsNummer;
        private short wohnungsNummer;

        public OrdnungsbegriffAbrechnungsunternehmen(int liegenschaftsNummer, short wohnungsNummer)
        {
            this.liegenschaftsNummer = liegenschaftsNummer;
            this.wohnungsNummer = wohnungsNummer;
        }

        public override string ToString()
        {
            return string.Format("{0:000000000}{1:0000}", liegenschaftsNummer, wohnungsNummer);
        }
    }
}