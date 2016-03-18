using System;

namespace ArgeHeiwako.Data.Common
{
    public sealed class Betrag
    {
        private decimal betrag;

        public Betrag(decimal betrag)
        {
            if (betrag < -9999999.99M || betrag > 99999999.99M)
                throw new ArgumentOutOfRangeException("betrag");

            this.betrag = betrag;
        }

        public Betrag(string betrag)
        {
            if (betrag == null)
                throw new ArgumentNullException("betrag");

            if (betrag.Length != 10)
                throw new ArgumentOutOfRangeException("betrag");

            this.betrag = decimal.Parse(betrag);
        }
    }
}
