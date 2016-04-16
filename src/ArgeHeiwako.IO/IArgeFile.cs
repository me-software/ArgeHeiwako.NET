using System;
using System.Collections.Generic;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Dies ist die gemeinsame Schnittstelle für alle Datenaustauschdateien
    /// </summary>
    /// <typeparam name="TData">Typ des Datenaustauschsatzes</typeparam>
    public interface IArgeFile<TData>
    {
        /// <summary>
        /// Liefert den Erstellungszeitpunkt der Datei
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// Liefert den Dateinamen der Datenaustauschdatei
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Liefert die in der Datei enthaltenen Datensätze des Datenaustauschsatzes
        /// </summary>
        IEnumerable<TData> Datensaetze { get; }
    }
}