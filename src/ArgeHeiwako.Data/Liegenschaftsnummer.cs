using ArgeHeiwako.Data.Properties;
using System;

namespace ArgeHeiwako.Data
{
    public sealed class LiegenschaftsNummer
    {
        private readonly int liegenschaftsnummer;

        public LiegenschaftsNummer(string liegenschaftsnummer)
        {
            if (liegenschaftsnummer == null)
                throw new ArgumentNullException("liegenschaftsnummer");

            if (liegenschaftsnummer.Length != 9)
                throw new ArgumentException(Resources.EXP_MSG_VALID_LIEGENSCHAFTSNUMMER, "liegenschaftsnummer");

            int nummer = 0;
            if (!int.TryParse(liegenschaftsnummer, out nummer))
                throw new ArgumentException(Resources.EXP_MSG_VALID_LIEGENSCHAFTSNUMMER, "liegenschaftsnummer");

            if (nummer > 999999999 || nummer < -99999999)
                throw new ArgumentOutOfRangeException("liegenschaftsnummer");

            this.liegenschaftsnummer = nummer;
        }

        public LiegenschaftsNummer(int liegenschaftsnummer)
        {
            if (liegenschaftsnummer > 999999999 || liegenschaftsnummer < -99999999)
                throw new ArgumentOutOfRangeException("liegenschaftsnummer");

            this.liegenschaftsnummer = liegenschaftsnummer;
        }

        public static implicit operator int(LiegenschaftsNummer nummer)
        {
            return nummer.liegenschaftsnummer;
        }

        public override string ToString()
        {
            return (liegenschaftsnummer < 0) ?
                $"-{Math.Abs(liegenschaftsnummer):00000000}" :
                $"{liegenschaftsnummer:000000000}";
        }
    }
}