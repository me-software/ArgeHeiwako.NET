using ArgeHeiwako.Data.Properties;
using System;

namespace ArgeHeiwako.Data
{
    /// <summary>
    /// Diese Klasse repräsentiert die Nummer des Kunden, unter der er beim Abrechnungsunternehmen geführt wird.
    /// </summary>
    public sealed class KundenNummer
    {
        /// <summary>
        /// Der maximal gültige Wert für eine <see cref="KundenNummer"/>
        /// </summary>
        public const long MaxValue = 9999999999;

        /// <summary>
        /// Der minimal gültige Wert für eine <see cref="KundenNummer"/>
        /// </summary>
        public const long MinValue = -999999999;

        private readonly long nummer;

        /// <summary>
        /// Erstellt eine neue <see cref="KundenNummer"/>-Instanz
        /// </summary>
        /// <param name="nummer">Die Nummer des Kunden aus einer Datenaustausch-Datei in Form eines <see cref="string"/></param>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="nummer"/> NULL ist.</exception>
        /// <exception cref="ArgumentException">Wenn keine valide Kundennummer in <paramref name="nummer"/> angegeben wurde.</exception>
        public KundenNummer(string nummer)
        {
            if (nummer == null)
                throw new ArgumentNullException("nummer");

            if (nummer.Length != 10)
                throw new ArgumentException(Resources.EXP_MSG_VALID_KUNDENNUMMER_LENGTH, "nummer");

            long value = 0;
            if (!long.TryParse(nummer, out value))
                throw new ArgumentException();

            this.nummer = Init(value);
        }

        /// <summary>
        /// Erstellt eine neue <see cref="KundenNummer"/>-Instanz
        /// </summary>
        /// <param name="nummer">Der numerische Wert der Nummer des Kunden</param>
        /// <exception cref="ArgumentException">Wenn keine valide Kundennummer in <paramref name="nummer"/> angegeben wurde.</exception>
        public KundenNummer(long nummer)
        {
            this.nummer = Init(nummer);
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return nummer < 0 ? 
                string.Format("{0:000000000}", nummer) : 
                string.Format("{0:0000000000}", nummer);
        }

        private long Init(long nummer)
        {
            if (nummer > MaxValue)
                throw new ArgumentException();
            if (nummer < MinValue)
                throw new ArgumentException();

            return nummer;
        }
    }
}