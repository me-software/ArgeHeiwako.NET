using System;
using System.Globalization;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert einen Betrag (Geldwert) innerhalb einer Datenaustauschdatei
    /// </summary>
    public sealed class Betrag
    {
        private decimal betrag;

        /// <summary>
        /// Erstellt eine neue <see cref="Betrag"/>-Instanz
        /// </summary>
        /// <param name="betrag">Der numerische Wert des Betrags</param>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Parameter <paramref name="betrag"/> außerhalb des gültigen Wertebereichs liegt.</exception>
        public Betrag(decimal betrag)
        {
            this.betrag = CheckRange(betrag);
        }

        /// <summary>
        /// Erstellt eine neue <see cref="Betrag"/>-Instanz
        /// </summary>
        /// <param name="betrag">Der textuelle Feldwert aus der Datenaustauschdatei</param>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="betrag"/> NULL ist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Parameter <paramref name="betrag"/> außerhalb des gültigen Wertebereichs liegt.</exception>
        public Betrag(string betrag)
        {
            if (betrag == null)
                throw new ArgumentNullException("betrag");

            if (betrag.Length != 10)
                throw new ArgumentOutOfRangeException("betrag");

            decimal value = 0m;
            string betragVal = betrag.Insert(8, ".");
            if (!decimal.TryParse(betragVal, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                throw new ArgumentException("Kein gültiger numerischer String", "betrag");

            this.betrag = CheckRange(value);
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            var isNegative = (betrag < 0);
            var absBetrag = Math.Abs(betrag);
            var truncated = Math.Truncate(absBetrag);
            var fracture = (absBetrag - truncated) * 100;

            return isNegative ?
                $"-{truncated:0000000}{fracture:00}" : 
                $"{truncated:00000000}{fracture:00}";
        }

        /// <summary>
        /// Konvertiert eine <see cref="Betrag"/>-Instanz in seinen numerischen Wert.
        /// </summary>
        /// <param name="betrag">Die zu konvertierende <see cref="Betrag"/>-Instanz</param>
        /// <returns>Den numerischen Wert der <see cref="Betrag"/>-Instanz</returns>
        public static implicit operator decimal(Betrag betrag)
        {
            return betrag.betrag;
        }

        private decimal CheckRange(decimal value)
        {
            if (value < -9999999.99M || value > 99999999.99M)
                throw new ArgumentOutOfRangeException("betrag");

            return value;
        }
    }
}
