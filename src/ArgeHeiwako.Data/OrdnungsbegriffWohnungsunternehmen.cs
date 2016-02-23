namespace ArgeHeiwako.Data
{
    public sealed class OrdnungsbegriffWohnungsunternehmen
    {
        private string ordnungsbegriff;

        public OrdnungsbegriffWohnungsunternehmen(string ordnungsbegriff)
        {
            this.ordnungsbegriff = ordnungsbegriff;
        }

        public override string ToString()
        {
            return ordnungsbegriff.PadRight(20);
        }
    }
}