using System;

namespace ArgeHeiwako.Data
{
    public sealed class KundenNummer
    {
        public const long MaxValue = 9999999999;
        private long nummer;

        public KundenNummer(long nummer)
        {
            if (nummer > MaxValue)
                throw new ArgumentException();

            this.nummer = nummer;
        }

        public override string ToString()
        {
            return string.Format("{0:0000000000}", nummer);
        }
    }
}