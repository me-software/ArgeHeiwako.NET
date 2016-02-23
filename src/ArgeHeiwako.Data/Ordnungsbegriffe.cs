namespace ArgeHeiwako.Data
{
    public sealed class Ordnungsbegriffe
    {
        private const string Satzart = "A";
        private ArgeVersion version;
        private KundenNummer kundenNummer;
        private OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen;
        private OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen;

        public Ordnungsbegriffe(
            ArgeVersion version,
            KundenNummer kundenNummer,
            OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen,
            OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen)
        {
            this.version = version;
            this.kundenNummer = kundenNummer;
            this.ordnungsbegriffAbrechnungsunternehmen = ordnungsbegriffAbrechnungsunternehmen;
            this.ordnungsbegriffWohnungsunternehmen = ordnungsbegriffWohnungsunternehmen;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}{1}{2}{3}{4}{5}{6}{0}",
                Satzart,
                version,
                kundenNummer,
                new string(' ', 2), // TODO: Abrechnungsunternehmen als Parameter berücksichtigen ,
                ordnungsbegriffAbrechnungsunternehmen,
                ordnungsbegriffWohnungsunternehmen,
                new string(' ', 76));
        }
    }
}
