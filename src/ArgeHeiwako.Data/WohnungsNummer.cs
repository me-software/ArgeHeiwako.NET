using ArgeHeiwako.Data.Properties;
using System;

namespace ArgeHeiwako.Data
{
    public sealed class WohnungsNummer
    {
        private readonly short wohnungsnummer;

        public WohnungsNummer(short wohnungsnummer)
        {
            this.wohnungsnummer = CheckRange(wohnungsnummer);
        }

        public WohnungsNummer(string wohnungsnummer)
        {
            if (wohnungsnummer == null)
                throw new ArgumentNullException("wohnungsnummer", Resources.EXP_MSG_VALID_WOHNUNGSNUMMER);

            if (wohnungsnummer.Length != 4)
                throw new ArgumentOutOfRangeException("wohnungsnummer", Resources.EXP_MSG_VALID_WOHNUNGSNUMMER);

            short nummer = 0;
            if (!short.TryParse(wohnungsnummer, out nummer))
                throw new ArgumentException(Resources.EXP_MSG_VALID_WOHNUNGSNUMMER, "wohnungsnummer");

            this.wohnungsnummer = CheckRange(nummer);
        }

        public override string ToString()
        {
            return (wohnungsnummer < 0) ? 
                $"-{Math.Abs(wohnungsnummer):000}":
                $"{wohnungsnummer:0000}";
        }

        public static implicit operator short(WohnungsNummer nummer)
        {
            return nummer.wohnungsnummer;
        }

        private short CheckRange(short wohnungsnummer)
        {
            if (wohnungsnummer < -999 || wohnungsnummer > 9999)
                throw new ArgumentOutOfRangeException("wohnungsnummer", Resources.EXP_MSG_VALID_WOHNUNGSNUMMER);

            return wohnungsnummer;
        }
    }
}