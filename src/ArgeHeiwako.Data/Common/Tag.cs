using System;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert eine Tagesangabe innerhalb der Datenaustauschdateien.
    /// </summary>
    public sealed class Tag
    {
        private readonly DateTime tag;

        /// <summary>
        /// Erstellt eine neue <see cref="Tag"/>-Instanz
        /// </summary>
        /// <param name="tag">Der textuelle Wert aus dem Feld der Datenaustauschdatei</param>
        public Tag(string tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");

            if (tag.Length != 6)
                throw new ArgumentOutOfRangeException("tag");

            int tagPart = 0;
            int monthPart = 0;
            int jahrPart = 0;
            if (!int.TryParse(tag.Substring(0, 2), out tagPart) ||
                !int.TryParse(tag.Substring(2, 2), out monthPart) ||
                !int.TryParse(tag.Substring(4, 2), out jahrPart))
            {
                throw new ArgumentOutOfRangeException("tag");
            }

            this.tag = new DateTime(jahrPart, monthPart, tagPart);
        }

        /// <summary>
        /// Erstellt eine neue <see cref="Tag"/>-Instanz
        /// </summary>
        /// <param name="tag">Der Datumswert für den darzustellenden Tag</param>
        public Tag(DateTime tag)
        {
            this.tag = tag.Date;
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return tag.ToString("ddMMyy");
        }

        /// <summary>
        /// Konvertiert eine <see cref="Tag"/>-Instanz in ihren Datumswert
        /// </summary>
        /// <param name="tag">Die zu konvertierende <see cref="Tag"/>-Instanz</param>
        /// <returns>Den Datumswert der <see cref="Tag"/>-Instanz</returns>
        public static implicit operator DateTime(Tag tag)
        {
            return tag.tag;
        }
    }
}
