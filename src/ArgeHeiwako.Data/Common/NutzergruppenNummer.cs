using System;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert die Nutzergruppen-Nummer innerhalb des <see cref="ErweiterterOrdnungsbegriffAbrechnungsunternehmen"/>.
    /// </summary>
    public class NutzergruppenNummer
    {
        private readonly short nutzergruppenNummer;

        #region Constants

        /// <summary>
        /// Der minimale numerische Wert einer <see cref="NutzergruppenNummer"/>
        /// </summary>
        public const short MinValue = -999;

        /// <summary>
        /// Der maximale numerische Wert einer <see cref="NutzergruppenNummer"/>
        /// </summary>
        public const short MaxValue = 9999;

        #endregion

        /// <summary>
        /// Erstellt eine neue <see cref="NutzergruppenNummer"/>-Instanz
        /// </summary>
        /// <param name="nutzergruppenNummer">Der textuelle Wert aus dem Feld der Datenaustauschdatei</param>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="nutzergruppenNummer"/> NULL ist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Parameter <paramref name="nutzergruppenNummer"/> außerhalb des gültigen Wertebereichs liegt.</exception>
        public NutzergruppenNummer(string nutzergruppenNummer)
        {
            if (nutzergruppenNummer == null)
                throw new ArgumentNullException("nutzergruppenNummer");

            if (nutzergruppenNummer.Length != 4)
                throw new ArgumentOutOfRangeException("nutzergruppenNummer");

            short value = 0;
            if (!short.TryParse(nutzergruppenNummer, out value))
                throw new ArgumentOutOfRangeException("nutzergruppenNummer");

            this.nutzergruppenNummer = value;
        }

        /// <summary>
        /// Erstellt eine neue <see cref="NutzergruppenNummer"/>-Instanz
        /// </summary>
        /// <param name="nutzergruppenNummer">Der numerische Wert aus der Nutzergurppen-Nummer</param>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Parameter <paramref name="nutzergruppenNummer"/> außerhalb des gültigen Wertebereichs liegt.</exception>
        public NutzergruppenNummer(short nutzergruppenNummer)
        {
            if (nutzergruppenNummer < MinValue || nutzergruppenNummer > MaxValue)
                throw new ArgumentOutOfRangeException("nutzergruppenNummer");

            this.nutzergruppenNummer = nutzergruppenNummer;
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return (nutzergruppenNummer < 0) ?
                $"-{Math.Abs(nutzergruppenNummer):000}" :
                $"{nutzergruppenNummer:0000}";
        }

        /// <summary>
        /// Implizite Konvertierung einer <see cref="NutzergruppenNummer"/>-Instanz in ihren numerischen Wert vom Typ <see cref="short"/>
        /// </summary>
        /// <param name="nummer">Die zu konvertierende <see cref="NutzergruppenNummer"/>-Instanz.</param>
        /// <returns>Der numerische Wert der Nutzergruppen-Nummer</returns>
        public static implicit operator short(NutzergruppenNummer nummer)
        {
            return nummer.nutzergruppenNummer;
        }
    }
}