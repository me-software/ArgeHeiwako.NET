using System;
using System.IO;
using System.Text;
using ArgeHeiwako.Data;

namespace ArgeHeiwako.IO
{
    public class OrdnungsbegriffeWriter : IDisposable
    {
        private const int ISO_8859_15_CODE_PAGE = 28605;
        private const string LINE_END = "\r\n";
        private StreamWriter writer;

        public static readonly Encoding WriterEncoding = Encoding.GetEncoding(ISO_8859_15_CODE_PAGE);

        public OrdnungsbegriffeWriter(Stream stream)
        {
            writer = new StreamWriter(stream, WriterEncoding);
        }
        
        public void Write(Ordnungsbegriffe ordnungsbegriffe)
        {
            writer.Write($"{ordnungsbegriffe}{LINE_END}");
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