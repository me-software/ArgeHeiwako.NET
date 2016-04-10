using System;
using System.IO;
using System.Text;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Basisimplementierung der <see cref="IArgeWriter{T}"/> Schnittstelle für das Schreiben von 
    /// Datenaustauschinformationen
    /// </summary>
    /// <typeparam name="TInstance"></typeparam>
    public abstract class ArgeWriter<TInstance> : IArgeWriter<TInstance>
    {
        private const int ISO_8859_15_CODE_PAGE = 28605;
        private const string LINE_END = "\r\n";
        private StreamWriter writer;

        /// <summary>
        /// Liefert das verwendete <see cref="Encoding"/>
        /// </summary>
        public static readonly Encoding WriterEncoding = Encoding.GetEncoding(ISO_8859_15_CODE_PAGE);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        protected ArgeWriter(Stream stream)
        {
            writer = new StreamWriter(stream, WriterEncoding);
        }

        /// <summary>
        /// Schreibt eine Datenaustauschsatz-Instanz in die verwendete Quelle
        /// </summary>
        /// <param name="datensatz"></param>
        public void Write(TInstance datensatz)
        {
            if (isDisposed)
                throw new ObjectDisposedException(this.GetType().Name);

            writer.Write($"{datensatz}{LINE_END}");
        }

        #region IDisposable Support
        private bool isDisposed = false; // To detect redundant calls

        /// <summary>
        /// Private Implementierung des <see cref="IDisposable"/>-Pattern
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    writer.Dispose();
                }
                
                isDisposed = true;
            }
        }
        
        /// <summary>
        /// Öffentliche Implementierung des <see cref="IDisposable"/>-Pattern
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
