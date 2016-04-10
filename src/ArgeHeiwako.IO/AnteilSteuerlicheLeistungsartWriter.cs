using ArgeHeiwako.Data;
using System.IO;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Implementierung des <see cref="IArgeWriter{T}"/> der sich um das Schreiben von <see cref="AnteilSteuerlicheLeistungsart"/> kümmert
    /// </summary>
    public class AnteilSteuerlicheLeistungsartWriter : ArgeWriter<AnteilSteuerlicheLeistungsart>
    {
        /// <summary>
        /// Erstellt eine neue <see cref="AnteilSteuerlicheLeistungsartWriter"/>-Instanz
        /// </summary>
        /// <param name="stream"></param>
        public AnteilSteuerlicheLeistungsartWriter(Stream stream)
            : base(stream)
        {
        }
    }
}