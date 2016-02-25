using System;
using System.IO;
using System.Text;
using ArgeHeiwako.Data;

namespace ArgeHeiwako.IO
{
    public class OrdnungsbegriffeWriter : IDisposable
    {
        public static readonly Encoding WriterEncoding = Encoding.GetEncoding(ISO_8859_15_CODE_PAGE);

        private const int ISO_8859_15_CODE_PAGE = 28605;
        private StreamWriter writer;

        public OrdnungsbegriffeWriter(Stream stream)
        {
            writer = new StreamWriter(stream, WriterEncoding);
        }
        
        public void Write(Ordnungsbegriffe ordnungsbegriffe)
        {
            writer.WriteLine(ordnungsbegriffe.ToString());
        }

        #region IDisposable-Impl

        public void Dispose()
        {
            writer.Flush();
            writer.Dispose();
        }
        
        #endregion
    }
}