using System;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert eine Bilddateifolge-Nummer innerhalb des E898 Satzes 
    /// </summary>
    public sealed class BilddateiFolgeNummer : Nummer<int>
    {
        #region Constants

        /// <summary>
        /// Der maximale numerische Wert der <see cref="BilddateiFolgeNummer"/>
        /// </summary>
        public const int MinValue = -99;

        /// <summary>
        /// Der maximale numerische Wert der <see cref="BilddateiFolgeNummer"/>
        /// </summary>
        public const int MaxValue = 999;

        #endregion

        /// <summary>
        /// Erstellt eine neue <see cref="BilddateiFolgeNummer"/>-Instanz
        /// </summary>
        /// <param name="bilddateiFolgeNummer">Der textuelle Wert aus der Datenaustausch-Datei</param>
        public BilddateiFolgeNummer(string bilddateiFolgeNummer)
            : base(bilddateiFolgeNummer, 3, nameof(bilddateiFolgeNummer), valueString =>
            {
                int value = 0;
                var success = int.TryParse(valueString, out value);
                return new ParseResult<int>(success, value);
            })
        {
        }

        /// <summary>
        /// Erstellt eine neue <see cref="BilddateiFolgeNummer"/>-Instanz
        /// </summary>
        /// <param name="bilddateiFolgeNummer">Der numerische Wert der <see cref="BilddateiFolgeNummer"/></param>
        public BilddateiFolgeNummer(int bilddateiFolgeNummer)
            : base(bilddateiFolgeNummer, MinValue, MaxValue, nameof(bilddateiFolgeNummer))
        {
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            var isNegative = value < 0;
            return isNegative ?
                $"-{(Math.Abs(value)):00}" :
                $"{value:000}";
        }
    }
}