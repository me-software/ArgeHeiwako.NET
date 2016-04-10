using ArgeHeiwako.Data;
using System;
using System.IO;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Implementierung des <see cref="IArgeWriter{T}"/> der sich um das Schreiben von <see cref="AnteilSteuerlicheLeistungsart"/> kümmert
    /// </summary>
    public class AnteilSteuerlicheLeistungsartWriter : IArgeWriter<AnteilSteuerlicheLeistungsart>
    {
        private StreamWriter writer;

        /// <summary>
        /// Erstellt eine neue <see cref="AnteilSteuerlicheLeistungsartWriter"/>-Instanz
        /// </summary>
        /// <param name="stream"></param>
        public AnteilSteuerlicheLeistungsartWriter(Stream stream)
        {
            writer = new StreamWriter(stream);
        }

        /// <summary>
        /// Schreibt eine Datenaustauschsatz-Instanz in die verwendete Quelle
        /// </summary>
        /// <param name="datensatz"></param>
        public void Write(AnteilSteuerlicheLeistungsart datensatz)
        {
            if (disposedValue)
                throw new ObjectDisposedException(nameof(AnteilSteuerlicheLeistungsartWriter));

            writer.Write($"{datensatz}\r\n");
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    writer.Dispose();
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Öffentliche Implemntierung des Dispose-Pattern für die externe Verwendung
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}