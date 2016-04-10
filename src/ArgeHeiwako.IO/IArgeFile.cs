using System;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Dies ist die gemeinsame Schnittstelle für alle Datenaustauschdateien
    /// </summary>
    public interface IArgeFile
    {
        /// <summary>
        /// Liefert den Erstellungszeitpunkt der Datei
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// Liefert den Dateinamen der Datenaustauschdatei
        /// </summary>
        string FileName { get; }
    }
}