using System;
using System.IO;
using System.Text;
using ArgeHeiwako.Data;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Diese Klasse wird genutzt, um die Informationen über <see cref="Ordnungsbegriffe"/> in einen Stream zu 
    /// schreiben.
    /// </summary>
    public class OrdnungsbegriffeWriter : ArgeWriter<Ordnungsbegriffe>
    {
        /// <summary>
        /// Erstellt eine neue <see cref="OrdnungsbegriffeWriter"/>-Instanz
        /// </summary>
        /// <param name="stream">Der <see cref="Stream"/> in welchen die Informationen geschrieben werden.</param>
        public OrdnungsbegriffeWriter(Stream stream)
            : base(stream)
        {
        }
    }
}