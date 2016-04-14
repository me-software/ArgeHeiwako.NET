using System;
using System.Collections.Generic;
using ArgeHeiwako.Data;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Diese Klasse repräsentiert eine E835 Datenaustauschdatei
    /// </summary>
    public class AnteilSteuerlicheLeistungsartFile : ArgeFile<AnteilSteuerlicheLeistungsart>
    {
        /// <summary>
        /// Liefert die Kennzeichnung der Satzart
        /// </summary>
        public const string Satzart = "E835";

        /// <summary>
        /// Erstellt eine <see cref="AnteilSteuerlicheLeistungsartFile"/>-Instanz
        /// </summary>
        /// <param name="created"></param>
        /// <param name="datensaetze"></param>
        public AnteilSteuerlicheLeistungsartFile(DateTime created, IEnumerable<AnteilSteuerlicheLeistungsart> datensaetze) 
            : base(created, Satzart, datensaetze)
        {
        }
    }
}