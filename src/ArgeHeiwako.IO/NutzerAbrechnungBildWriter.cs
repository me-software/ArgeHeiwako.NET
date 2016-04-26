using ArgeHeiwako.Data;
using System.IO;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Implementierung des <see cref="IArgeWriter{T}"/> der sich um das Schreiben von <see cref="NutzerAbrechnungBild"/> kümmert
    /// </summary>
    public class NutzerAbrechnungBildWriter : ArgeWriter<NutzerAbrechnungBild>
    {
        /// <summary>
        /// Erstellt eine neue <see cref="NutzerAbrechnungBildWriter"/>-Instanz
        /// </summary>
        /// <param name="stream">Der <see cref="Stream"/> in welchen der Inhalt geschrieben werden soll.</param>
        public NutzerAbrechnungBildWriter(Stream stream) 
            : base(stream)
        {
        }
    }
}
