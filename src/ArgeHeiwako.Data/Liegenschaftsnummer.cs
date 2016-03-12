using ArgeHeiwako.Data.Properties;
using System;

namespace ArgeHeiwako.Data
{
    /// <summary>
    /// Diese Klasse repräsentiert den Teil der Liegenschaftsnummer innerhalb des <see cref="OrdnungsbegriffAbrechnungsunternehmen"/>
    /// </summary>
    public sealed class LiegenschaftsNummer
    {
        private readonly int liegenschaftsnummer;

        /// <summary>
        /// Erstellt eine <see cref="LiegenschaftsNummer"/>-Instanz auf Basis des Feldwertes aus der Datenaustausch-Datei
        /// </summary>
        /// <param name="liegenschaftsnummer">Der Feldwert für die Liegenschaftsnummer aus dem Ordnungsbegriff des Abrechnungsunternehmens</param>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="liegenschaftsnummer"/> NULL ist</exception>
        /// <exception cref="ArgumentException">Wenn keine valide Liegenschaftsnummer im Parameter <paramref name="liegenschaftsnummer"/> angegeben wird</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn eine Liegenschaftsnummer außerhalb des gültigen Wertebereichs im Parameter <paramref name="liegenschaftsnummer"/> angegeben wird</exception>
        public LiegenschaftsNummer(string liegenschaftsnummer)
        {
            if (liegenschaftsnummer == null)
                throw new ArgumentNullException("liegenschaftsnummer");

            if (liegenschaftsnummer.Length != 9)
                throw new ArgumentException(Resources.EXP_MSG_VALID_LIEGENSCHAFTSNUMMER, "liegenschaftsnummer");

            int nummer = 0;
            if (!int.TryParse(liegenschaftsnummer, out nummer))
                throw new ArgumentException(Resources.EXP_MSG_VALID_LIEGENSCHAFTSNUMMER, "liegenschaftsnummer");
            
            this.liegenschaftsnummer = CheckNumericRange(nummer);
        }

        /// <summary>
        /// Erstellt eine neue <see cref="LiegenschaftsNummer"/>-Instanz auf Basis des numerischen Wertes 
        /// </summary>
        /// <param name="liegenschaftsnummer">Der numerische Wert der Liegenschaftsnummer</param>
        /// <exception cref="ArgumentOutOfRangeException">Wenn eine Liegenschaftsnummer außerhalb des gültigen Wertebereichs im Parameter <paramref name="liegenschaftsnummer"/> angegeben wird</exception>
        public LiegenschaftsNummer(int liegenschaftsnummer)
        {
            this.liegenschaftsnummer = CheckNumericRange(liegenschaftsnummer);
        }

        /// <summary>
        /// Implizite Konvertierung einer <see cref="LiegenschaftsNummer"/>-Instanz in ihren numerischen Wert vom Typ <see cref="int"/>
        /// </summary>
        /// <param name="nummer">Die zu konvertierende <see cref="LiegenschaftsNummer"/>-Instanz</param>
        /// <returns>Der numerische Wert der <see cref="LiegenschaftsNummer"/></returns>
        public static implicit operator int(LiegenschaftsNummer nummer)
        {
            return nummer.liegenschaftsnummer;
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return (liegenschaftsnummer < 0) ?
                $"-{Math.Abs(liegenschaftsnummer):00000000}" :
                $"{liegenschaftsnummer:000000000}";
        }
        
        private int CheckNumericRange(int liegenschaftsnummer)
        {
            if (liegenschaftsnummer > 999999999 || liegenschaftsnummer < -99999999)
                throw new ArgumentOutOfRangeException("liegenschaftsnummer");
            return liegenschaftsnummer;
        }
    }
}