using System;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Satzfolgenummer innerhalb eines Datenaustausch-Satzes
    /// </summary>
    public sealed class Satzfolgenummer
    {
        private readonly int satzfolgenummer;

        /// <summary>
        /// Erstellt eine neue <see cref="Satzfolgenummer"/>-Instanz
        /// </summary>
        /// <param name="satzfolgenummer">Der numerische Wert der Satzfolgenummer.</param>
        public Satzfolgenummer(int satzfolgenummer)
        {
            if (satzfolgenummer < -999999 || satzfolgenummer > 9999999)
                throw new ArgumentOutOfRangeException("satzfolgenummer");

            this.satzfolgenummer = satzfolgenummer;
        }

        /// <summary>
        /// Erstellt eine neue <see cref="Satzfolgenummer"/>-Instanz
        /// </summary>
        /// <param name="satzfolgenummer">Der textuelle Wert der Satzfolgenummer aus Datenaustauschdatei.</param>
        public Satzfolgenummer(string satzfolgenummer)
        {
            if (satzfolgenummer == null)
                throw new ArgumentNullException("satzfolgenummer");

            if (satzfolgenummer.Length != 7)
                throw new ArgumentOutOfRangeException("satzfolgenummer");

            int value = 0;
            if (!int.TryParse(satzfolgenummer, out value))
                throw new ArgumentOutOfRangeException("satzfolgenummer");

            this.satzfolgenummer = value;
        }

        /// <summary>
        /// Implizite Konvertierung einer <see cref="Satzfolgenummer"/>-Instanz in den numerischen Wert vom Typ <see cref="int"/>
        /// </summary>
        /// <param name="folgenummer">Die zu konvertierende <see cref="Satzfolgenummer"/>-Instanz</param>
        /// <returns>Der numerische Wert der Satzfolgenummer</returns>
        public static implicit operator int(Satzfolgenummer folgenummer)
        {
            return folgenummer.satzfolgenummer;
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return (satzfolgenummer < 0) ? $"-{Math.Abs(satzfolgenummer):000000}" : $"{satzfolgenummer:0000000}";
        }
    }
}
