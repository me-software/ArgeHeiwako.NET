using System;
using System.Diagnostics;
using System.Globalization;

namespace ArgeHeiwako.Data.Common
{
    public sealed class Prozent
    {
        private readonly decimal prozent;

        public Prozent(string prozent)
        {
            if (prozent == null)
            {
                Trace.TraceError("Der Parameter 'prozent' ist NULL");
                throw new ArgumentNullException("prozent");
            }

            if (prozent.Length != 5)
            {
                Trace.TraceError("Der Parameter 'prozent' hat keine Länge von 5");
                throw new ArgumentOutOfRangeException("prozent");
            }

            var prozentVal = prozent.Insert(3, ".");
            this.prozent = decimal.Parse(prozentVal, CultureInfo.InvariantCulture);
        }

        public Prozent(decimal prozent)
        {
            if (prozent < 0 || prozent > 100)
                throw new ArgumentOutOfRangeException("prozent");

            this.prozent = prozent;
        }

        public override string ToString()
        {
            var truncated = Math.Truncate(prozent);
            var fracture = (prozent - truncated) * 100;
            
            return $"{truncated:000}{fracture:00}";
        }

        public static implicit operator decimal(Prozent prozent)
        {
            return prozent.prozent;
        }
    }
}