using System;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Schnittstellenbeschreibung eines allgemeinen Datenaustausch-Writers, der in der Lage ist,
    /// Datenaustauschsäte vom Typ <typeparam name="T"></typeparam> in einen Stream zu schreiben.
    /// </summary>
    public interface IArgeWriter<T> : IDisposable
    {
        /// <summary>
        /// Schreibt eine Datenaustauschsatz-Instanz in die verwendete Quelle
        /// </summary>
        /// <param name="datensatz"></param>
        void Write(T datensatz);
    }
}
