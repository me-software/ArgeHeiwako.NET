using System;

namespace ArgeHeiwako.Data
{
    public sealed class OrdnungsbegriffWohnungsunternehmen
    {
        private readonly string ordnungsbegriff;

        public OrdnungsbegriffWohnungsunternehmen(string ordnungsbegriff)
        {
            if (ordnungsbegriff == null)
                throw new ArgumentNullException("ordnungsbegriff");

            if (ordnungsbegriff.Length > 20)
                throw new ArgumentOutOfRangeException("ordnungsbegriff");

            this.ordnungsbegriff = ordnungsbegriff.Trim();
        }

        public override string ToString()
        {
            return ordnungsbegriff.PadRight(20);
        }
    }
}