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
    public class OrdnungsbegriffeWriter : IArgeWriter<Ordnungsbegriffe>
    {
        private const int ISO_8859_15_CODE_PAGE = 28605;
        private const string LINE_END = "\r\n";
        private StreamWriter writer;

        /// <summary>
        /// Liefert das verwendete <see cref="Encoding"/>
        /// </summary>
        public static readonly Encoding WriterEncoding = Encoding.GetEncoding(ISO_8859_15_CODE_PAGE);

        /// <summary>
        /// Erstellt eine neue <see cref="OrdnungsbegriffeWriter"/>-Instanz
        /// </summary>
        /// <param name="stream">Der <see cref="Stream"/> in welchen die Informationen geschrieben werden.</param>
        public OrdnungsbegriffeWriter(Stream stream)
        {
            writer = new StreamWriter(stream, WriterEncoding);
        }

        /// <summary>
        /// Schreibt eine <see cref="Ordnungsbegriffe"/>-Instanz in den den verwendeten <see cref="Stream"/>
        /// </summary>
        /// <param name="ordnungsbegriffe"></param>
        public void Write(Ordnungsbegriffe ordnungsbegriffe)
        {
            if (disposed)
                throw new ObjectDisposedException("OrdnungsbegriffeWriter");

            writer.Write($"{ordnungsbegriffe}{LINE_END}");
        }

        #region IDisposable-Implementation
        // Flag: Has Dispose already been called?
        bool disposed = false;

        /// <summary>
        /// Öffentliche Implemntierung des Dispose-Pattern für die externe Verwendung
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Geschützte Implementierung des Dispose-Pattern
        /// </summary>
        /// <param name="disposing">Kennzeichen, ob dispose ausgeführt werden soll.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                writer.Flush();
                writer.Dispose();
            }

            disposed = true;
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~OrdnungsbegriffeWriter()
        {
            Dispose(false);
        }

        #endregion
    }
}