using System;

namespace ArgeHeiwako.Data
{
    public sealed class ArgeVersion
    {
        private const string DEFAULT_VERSION = "03.05";
        private string versionString;

        public ArgeVersion(): this(DEFAULT_VERSION)
        {
        }

        public ArgeVersion(string versionString)
        {
            if (string.IsNullOrEmpty(versionString))
            {
                throw new ArgumentException();
            }

            if (versionString.Length != 5)
            {
                throw new ArgumentException();
            }

            this.versionString = versionString;
        }

        public override string ToString()
        {
            return versionString;
        }
    }
}