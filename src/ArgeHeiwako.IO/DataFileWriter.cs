using System;
using System.IO;
using System.Text;
using ArgeHeiwako.Data;

namespace ArgeHeiwako.IO
{
    public class DataFileWriter : IDisposable
    {
        private const int ISO_8859_15_CODE_PAGE = 28605;
        private StreamWriter writer;

        public DataFileWriter(Stream stream)
        {
            writer = new StreamWriter(stream, Encoding.GetEncoding(ISO_8859_15_CODE_PAGE));
        }

        #region IDisposable-Impl

        /// <summary>
        /// Finalizer
        /// </summary>
        ~DataFileWriter()
        {
        }

        public void Dispose()
        {
            writer.Flush();
            writer.Dispose();
        }

        public void Write(Ordnungsbegriffe ordnungsbegriffe)
        {
            writer.WriteLine(ordnungsbegriffe.ToString());
        }

        #endregion
    }
}