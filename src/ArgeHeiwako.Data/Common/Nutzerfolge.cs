using System;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert den Teil der Nutzerfolge aus dem <see cref="ErweiterterOrdnungsbegriffAbrechnungsunternehmen"/>.
    /// </summary>
    public class Nutzerfolge : Nummer<short>
    {
        private static Func<string, ParseResult<short>> conversionFunction = (valueString) =>
        {
            short value = 0;
            var result = short.TryParse(valueString, out value);
            return new ParseResult<short>(result, value);
        };

        /// <summary>
        /// Erstellt eine neue <see cref="Nutzerfolge"/>-Instanz
        /// </summary>
        /// <param name="nutzerfolge">Der textuelle Wert aus dem <see cref="Nutzerfolge"/>-Feld der Datenaustauschdatei</param>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="nutzerfolge"/> NULL ist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Parameter <paramref name="nutzerfolge"/> außerhalb des gültigen Wertebereichs liegt.</exception>
        public Nutzerfolge(string nutzerfolge)
            : base(nutzerfolge, 1, "nutzerfolge", conversionFunction)
        {
        }

        /// <summary>
        /// Erstellt eine neue <see cref="Nutzerfolge"/>-Instanz
        /// </summary>
        /// <param name="nutzerfolge">Der numerische Wert aus der <see cref="Nutzerfolge"/></param>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Parameter <paramref name="nutzerfolge"/> außerhalb des gültigen Wertebereichs liegt.</exception>
        public Nutzerfolge(short nutzerfolge)
            : base(nutzerfolge, 0, 9, "nutzerfolge")
        {
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return value.ToString();
        }
    }
}