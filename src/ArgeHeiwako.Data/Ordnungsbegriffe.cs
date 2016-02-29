using ArgeHeiwako.Data.Properties;
using System;
using System.Collections.Generic;

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

        public string Version { get { return version.ToString(); } }

        public KundenNummer KundenNummer { get { return kundenNummer; } }

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

        internal static Ordnungsbegriffe FromString(string ordnungsbegriffeString)
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

            return new Ordnungsbegriffe(version, kundenNummer, new OrdnungsbegriffAbrechnungsunternehmen(0, 0), new OrdnungsbegriffWohnungsunternehmen("0"));
        }
    }
}
