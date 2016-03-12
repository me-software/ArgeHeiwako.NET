using ArgeHeiwako.Data.Properties;
using System;

namespace ArgeHeiwako.Data
{
    /// <summary>
    /// Diese Klasse repräsentiert den Teil der Wohnungsnummer innerhalb des <see cref="OrdnungsbegriffAbrechnungsunternehmen"/>
    /// </summary>
    public sealed class WohnungsNummer
    {
        private readonly short wohnungsnummer;

        /// <summary>
        /// Erstellt eine neue <see cref="WohnungsNummer"/>-Instanz
        /// </summary>
        /// <param name="wohnungsnummer">Der numerische Wert der Wohnungsnummer</param>
        /// <exception cref="ArgumentOutOfRangeException">Wenn die <paramref name="wohnungsnummer"/> außerhalb des festgelegten Bereiches von -999 bis 9999 liegt.</exception>
        public WohnungsNummer(short wohnungsnummer)
        {
            this.wohnungsnummer = CheckRange(wohnungsnummer);
        }

        /// <summary>
        /// Erstellt eine neue <see cref="WohnungsNummer"/>-Instanz
        /// </summary>
        /// <param name="wohnungsnummer">Der Feldwert für die Wohnungsnummer aus dem Ordnungsbegriff des Abrechnungsunternehmens</param>
        /// <exception cref="ArgumentNullException">Wenn die <paramref name="wohnungsnummer"/> NULL ist</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn die <paramref name="wohnungsnummer"/> länger als 4 Zeichen ist, oder außerhalb des festgelegten Bereiches von -999 bis 9999 liegt.</exception>
        /// <exception cref="ArgumentException">Wenn die <paramref name="wohnungsnummer"/> nicht numerisch ist.</exception>
        public WohnungsNummer(string wohnungsnummer)
        {
            if (wohnungsnummer == null)
                throw new ArgumentNullException("wohnungsnummer", Resources.EXP_MSG_VALID_WOHNUNGSNUMMER);

            if (wohnungsnummer.Length != 4)
                throw new ArgumentOutOfRangeException("wohnungsnummer", Resources.EXP_MSG_VALID_WOHNUNGSNUMMER);

            short nummer = 0;
            if (!short.TryParse(wohnungsnummer, out nummer))
                throw new ArgumentException(Resources.EXP_MSG_VALID_WOHNUNGSNUMMER, "wohnungsnummer");

            this.wohnungsnummer = CheckRange(nummer);
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (wohnungsnummer < 0) ? 
                $"-{Math.Abs(wohnungsnummer):000}":
                $"{wohnungsnummer:0000}";
        }

        /// <summary>
        /// Implizite Konvertierung einer <see cref="WohnungsNummer"/>-Instanz in ihren numerischen Wert vom Typ <see cref="short"/>
        /// </summary>
        /// <param name="nummer">Die zu konvertierende <see cref="WohnungsNummer"/>-Instanz</param>
        public static implicit operator short(WohnungsNummer nummer)
        {
            return nummer.wohnungsnummer;
        }

        private short CheckRange(short wohnungsnummer)
        {
            if (wohnungsnummer < -999 || wohnungsnummer > 9999)
                throw new ArgumentOutOfRangeException("wohnungsnummer", Resources.EXP_MSG_VALID_WOHNUNGSNUMMER);

            return wohnungsnummer;
        }
    }
}