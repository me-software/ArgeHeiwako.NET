using ArgeHeiwako.Data.Properties;
using System;

namespace ArgeHeiwako.Data
{
    /// <summary>
    /// Diese Klasse repräsentiert die von der ARGE vorgegebene Versionierung innerhalb des 
    /// Standard-Datenaustausches
    /// </summary>
    public sealed class ArgeVersion
    {
        private const string DEFAULT_VERSION = "03.05";

        private string versionString;

        /// <summary>
        /// Erstellt eine neue <see cref="ArgeVersion"/>-Instanz. 
        /// Es wird die aktuell implementierte Version des Standard-Datenaustausches verwendet.
        /// </summary>
        public ArgeVersion() : this(DEFAULT_VERSION)
        {
        }

        /// <summary>
        ///  Erstellt eine neue <see cref="ArgeVersion"/>-Instanz. 
        /// </summary>
        /// <param name="version">Die zu verwendende Version des Standard-Datenaustausches</param>
        /// <remarks>
        /// Durch die Nicht-Verwendung der Standard-Implementierung kann es zu Inkonsistenzen während der Verarbeitung kommen.
        /// </remarks>
        /// <exception cref="ArgumentException">Wenn der <paramref name="version"/> nicht korrekt angegeben wird.</exception>
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

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return versionString;
        }
    }
}