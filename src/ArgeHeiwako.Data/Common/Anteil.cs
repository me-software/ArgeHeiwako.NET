using System;
using System.Globalization;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Numerische Angabe eines Anteils innerhalb des Datenaustausches 
    /// (Nummernformat 6,3 Stellen)
    /// </summary>
    public class Anteil
    {
        private readonly decimal anteil;

        /// <summary>
        /// Erstellt eine neue <see cref="Anteil"/>-Instanz
        /// </summary>
        /// <param name="anteil"></param>
        public Anteil(decimal anteil)
        {
            this.anteil = CheckRange(anteil);
        }

        /// <summary>
        /// Erstellt eine neue <see cref="Anteil"/>-Instanz
        /// </summary>
        /// <param name="anteil"></param>
        public Anteil(string anteil)
        {
            if (anteil == null)
                throw new ArgumentNullException(nameof(anteil));
            if (anteil.Length != 9)
                throw new ArgumentOutOfRangeException(nameof(anteil));

            decimal value = 0m;
            string anteilVal = anteil.Insert(6, ".");
            if (!decimal.TryParse(anteilVal, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                throw new ArgumentOutOfRangeException(nameof(anteil));

            this.anteil = CheckRange(value);
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            var isNegative = (anteil < 0);
            var absBetrag = Math.Abs(anteil);
            var truncated = Math.Truncate(absBetrag);
            var fracture = (absBetrag - truncated) * 1000;

            return isNegative ?
                $"-{truncated:00000}{fracture:000}" :
                $"{truncated:000000}{fracture:000}";
        }

        /// <summary>
        /// Konvertiert eine <see cref="Anteil"/>-Instanz in seinen numerischen Wert.
        /// </summary>
        /// <param name="anteil">Die zu konvertierende <see cref="Anteil"/>-Instanz</param>
        /// <returns>Den numerischen Wert der <see cref="Anteil"/>-Instanz</returns>
        public static implicit operator decimal(Anteil anteil)
        {
            return anteil.anteil;
        }

        private decimal CheckRange(decimal anteil)
        {
            if (anteil < -99999.999M || anteil > 999999.999M)
                throw new ArgumentOutOfRangeException(nameof(anteil));

            return anteil;
        }
    }
}