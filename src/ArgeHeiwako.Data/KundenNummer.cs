using ArgeHeiwako.Data.Properties;
using System;

namespace ArgeHeiwako.Data
{
    public sealed class KundenNummer
    {
        public const long MaxValue = 9999999999;
        public const long MinValue = -999999999;
        private long nummer;

        public KundenNummer(string nummer)
        {
            if (nummer == null)
                throw new ArgumentNullException("nummer");

            if (nummer.Length != 10)
                throw new ArgumentException(Resources.EXP_MSG_VALID_KUNDENNUMMER_LENGTH, "nummer");

            long value = 0;
            if (!long.TryParse(nummer, out value))
                throw new ArgumentException();

            Init(value);
        }

        public KundenNummer(long nummer)
        {
            Init(nummer);
        }
        
        public override string ToString()
        {
            return nummer < 0 ? 
                string.Format("{0:000000000}", nummer) : 
                string.Format("{0:0000000000}", nummer);
        }

        private void Init(long nummer)
        {
            if (nummer > MaxValue)
                throw new ArgumentException();
            if (nummer < MinValue)
                throw new ArgumentException();

            this.nummer = nummer;
        }
    }
}