namespace ArgeHeiwako.Data
{
    public sealed class Ordnungsbegriffe
    {
        private const string Satzart = "A";
        private ArgeVersion version;
        private KundenNummer kundenNummer;
        private OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen;
        private OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen;
        private Abrechnungsunternehmen unternehmen;

        public Ordnungsbegriffe(
            ArgeVersion version,
            KundenNummer kundenNummer,
            OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen,
            OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen)
            : this(version, kundenNummer, ordnungsbegriffAbrechnungsunternehmen, ordnungsbegriffWohnungsunternehmen, null)
        {
        }

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
    }
}
