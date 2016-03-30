using System;
using System.Linq;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert die Abrechnungsfolgenummer, mit der es möglich ist, innerhalb eines Abrechnungszeitraums für einen Nutzer separate Abrechnungen 
    /// ausweisen zu können
    /// </summary>
    public sealed class AbrechnungsfolgeNummer
    {
        private static readonly string[] validValues = new[] { " ", "1", "2" };

        private readonly string abrechnungsfolgeNummer;

        /// <summary>
        /// Erstellt eine neue <see cref="AbrechnungsfolgeNummer"/>-Instanz
        /// </summary>
        /// <param name="abrechnungsfolgeNummer">Der Wert oder das textuelle Feld aus der Datenaustauschdatei</param>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="abrechnungsfolgeNummer"/> NULL ist.</exception>
        public AbrechnungsfolgeNummer(string abrechnungsfolgeNummer)
        {
            if (abrechnungsfolgeNummer == null)
                throw new ArgumentNullException("abrechnungsfolgeNummer");

            if (abrechnungsfolgeNummer.Length != 1 || validValues.All(x => x != abrechnungsfolgeNummer))
                throw new ArgumentOutOfRangeException("abrechnungsfolgeNummer");

            this.abrechnungsfolgeNummer = abrechnungsfolgeNummer;
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return abrechnungsfolgeNummer;
        }
    }
}