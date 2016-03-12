using ArgeHeiwako.Data.Properties;
using System;

namespace ArgeHeiwako.Data
{
    public sealed class ArgeVersion
    {
        private const string DEFAULT_VERSION = "03.05";
        private string versionString;

        public ArgeVersion() 
            : this(DEFAULT_VERSION)
        {
        }

        public ArgeVersion(string version)
        {
            if (version == null)
                throw new ArgumentNullException("version");

            if (version.Length != 5)
                throw new ArgumentException(Resources.EXP_MSG_VALID_ARGE_VERSION_RANGE, "version");

            if (version.Substring(2, 1) != ".")
                throw new ArgumentException(Resources.EXP_MSG_VALID_ARGE_VERSION_RANGE, "version");

            var parts = version.Split('.');
            var firstPart = parts[0];
            short firstPartNumeric = 0;
            if (!short.TryParse(firstPart, out firstPartNumeric) || firstPartNumeric < 3)
                throw new ArgumentException(Resources.EXP_MSG_VALID_ARGE_VERSION_RANGE, "version");

            var secondPart = parts[1];
            short secondPartNumeric = 0;
            if (!short.TryParse(secondPart, out secondPartNumeric))
                throw new ArgumentException(Resources.EXP_MSG_VALID_ARGE_VERSION_RANGE, "version");

            versionString = version;
        }

        public override string ToString()
        {
            return versionString;
        }
    }
}