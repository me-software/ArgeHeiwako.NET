using System;
using System.Diagnostics;
using System.Globalization;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse stellt eine prozentuale Angabe dar.
    /// </summary>
    public sealed class Prozent
    {
        private readonly decimal prozent;

        /// <summary>
        /// Erstellt eine neue <see cref="Prozent"/>-Instanz
        /// </summary>
        /// <param name="prozent">Der textuelle Feldwert aus der Datenaustauschdatei</param>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="prozent"/> NULL ist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Parameter <paramref name="prozent"/> außerhalb des gültigen Wertebereichs liegt.</exception>
        public Prozent(string prozent)
        {
            if (prozent == null)
            {
                Trace.TraceError("Der Parameter 'prozent' ist NULL");
                throw new ArgumentNullException("prozent");
            }

            if (prozent.Length != 5)
            {
                Trace.TraceError("Der Parameter 'prozent' hat keine Länge von 5");
                throw new ArgumentOutOfRangeException("prozent");
            }

            var prozentVal = prozent.Insert(3, ".");
            decimal value = 0M;
            if (!decimal.TryParse(prozentVal, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                throw new ArgumentException("Kein gültiger numerischer Wert.", "prozent");

            this.prozent = value;
        }

        /// <summary>
        /// Erstellt eine neue <see cref="Prozent"/>-Instanz
        /// </summary>
        /// <param name="prozent">Der numerische Prozentwert</param>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Parameter <paramref name="prozent"/> außerhalb des gültigen Wertebereichs liegt.</exception>
        public Prozent(decimal prozent)
        {
            if (prozent < 0 || prozent > 100)
                throw new ArgumentOutOfRangeException("prozent");

            this.prozent = prozent;
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            var truncated = Math.Truncate(prozent);
            var fracture = (prozent - truncated) * 100;

            return $"{truncated:000}{fracture:00}";
        }

        /// <summary>
        /// Implizite Konvertierung einer <see cref="Prozent"/>-Instanz in ihren numerischen Wert vom Typ <see cref="decimal"/>
        /// </summary>
        /// <param name="prozent">Die zu konvertierende <see cref="Prozent"/>-Instanz</param>
        /// <returns>Der numerische Wert der <see cref="Prozent"/>-Instanz</returns>
        public static implicit operator decimal(Prozent prozent)
        {
            return prozent.prozent;
        }
    }
}