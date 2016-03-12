using ArgeHeiwako.Data.Properties;
using System;

namespace ArgeHeiwako.Data
{
    public sealed class Ordnungsbegriffe
    {
        private const string Satzart = "A";
        private readonly ArgeVersion version;
        private readonly KundenNummer kundenNummer;
        private readonly OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen;
        private readonly OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen;
        private readonly Abrechnungsunternehmen unternehmen;

        public string Version
        {
            get { return version.ToString(); }
        }

        public KundenNummer KundenNummer
        {
            get { return kundenNummer; }
        }

        public Abrechnungsunternehmen Abrechnungsunternehmen
        {
            get { return unternehmen; }
        }

        public OrdnungsbegriffAbrechnungsunternehmen OrdnungsbegriffAbrechnungsunternehmen
        {
            get { return ordnungsbegriffAbrechnungsunternehmen; }
        }

        public OrdnungsbegriffWohnungsunternehmen OrdnungsbegriffWohnungsunternehmen
        {
            get
            {
                return ordnungsbegriffWohnungsunternehmen;
            }
        }


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
