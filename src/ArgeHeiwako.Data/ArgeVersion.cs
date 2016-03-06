using ArgeHeiwako.Data.Properties;
using System;

namespace ArgeHeiwako.Data
{
    public sealed class ArgeVersion
    {
        private const string DEFAULT_VERSION = "03.05";
        private string versionString;

        public ArgeVersion() : this(DEFAULT_VERSION)
        {
        }

        public ArgeVersion(string versionString)
        {
            if (string.IsNullOrEmpty(versionString))
                throw new ArgumentException();

            if (versionString.Length != 5)
                throw new ArgumentException();

            if (versionString.Substring(2, 1) != ".")
                throw new ArgumentException(Resources.EXP_MSG_VALID_ARGE_VERSION_RANGE);

            var parts = versionString.Split('.');
            var firstPart = parts[0];
            short firstPartNumeric = 0;
            if (!short.TryParse(firstPart, out firstPartNumeric) || firstPartNumeric < 3)
                throw new ArgumentException(Resources.EXP_MSG_VALID_ARGE_VERSION_RANGE);

            var secondPart = parts[1];
            short secondPartNumeric = 0;
            if (!short.TryParse(secondPart, out secondPartNumeric))
                throw new ArgumentException(Resources.EXP_MSG_VALID_ARGE_VERSION_RANGE);

            this.versionString = versionString;
        }

        public override string ToString()
        {
            return versionString;
        }
    }
}