using System;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Die Pfadangabe zur Bilddatei eines gelieferten E898 Datensatzes.
    /// </summary>
    public class BilddateiPfad
    {
        /// <summary>
        /// Die maximale Länge des <see cref="BilddateiPfad"/>s
        /// </summary>
        public const int MaxLength = 56;

        private string bilddateiPfad;

        /// <summary>
        /// Erstellt eine neue <see cref="BilddateiPfad"/>-Instanz
        /// </summary>
        /// <param name="bilddateiPfad">Der textuelle Wert des <see cref="BilddateiPfad"/>s</param>
        /// <exception cref="ArgumentNullException">Wenn der textuelle Wert <paramref name="bilddateiPfad"/> NULL ist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der textuelle Wert <paramref name="bilddateiPfad"/> leer oder länger als <see cref="MaxLength"/> ist.</exception>
        public BilddateiPfad(string bilddateiPfad)
        {
            if (bilddateiPfad == null)
                throw new ArgumentNullException(nameof(bilddateiPfad));

            if (bilddateiPfad.Length == 0 || bilddateiPfad.Length > MaxLength)
                throw new ArgumentOutOfRangeException(nameof(bilddateiPfad));
            
            this.bilddateiPfad = bilddateiPfad.Trim();
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return bilddateiPfad.PadRight(MaxLength);
        }
    }
}