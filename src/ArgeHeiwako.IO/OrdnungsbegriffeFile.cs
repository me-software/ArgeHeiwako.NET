using System;
using System.Collections.Generic;
using ArgeHeiwako.Data;
using System.IO;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Test
    /// </summary>
    public sealed class OrdnungsbegriffeFile
    {
        private const string LINE_END = "\r\n";

        public DateTime Created { get; private set; }

        public string FileName
        {
            get
            {
                return $"DTA305_{Created.ToString("yyyyMMddHHmmss")}.DAT";
            }
        }

        public IEnumerable<Ordnungsbegriffe> Ordnungsbegriffe { get; private set; }
        
        public OrdnungsbegriffeFile() 
            : this(DateTime.Now, new List<Ordnungsbegriffe>())
        {
        }

        public OrdnungsbegriffeFile(DateTime created)
            : this(created, new List<Ordnungsbegriffe>())
        {
        }

        public OrdnungsbegriffeFile(IEnumerable<Ordnungsbegriffe> ordnungsbegriffe) 
            : this(DateTime.Now, ordnungsbegriffe)
        {
        }

        public OrdnungsbegriffeFile(DateTime created, IEnumerable<Ordnungsbegriffe> ordnungsbegriffe)
        {
            Created = created;
            Ordnungsbegriffe = ordnungsbegriffe;
        }

        public void Write(IEnumerable<Ordnungsbegriffe> ordnungsbegriffe)
        {
            if (ordnungsbegriffe == null)
                throw new ArgumentNullException("ordnungsbegriffe");

            var filePath = Path.Combine(Environment.CurrentDirectory, FileName);
            using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
            {
                using (var writer = new OrdnungsbegriffeWriter(fileStream))
                {
                    foreach(var begriffe in ordnungsbegriffe)
                    {
                        writer.Write(begriffe);
                    }
                }
            }
        }

        public static OrdnungsbegriffeFile Load(Stream stream)
        {
            var ordnungsbegriffe = new List<Ordnungsbegriffe>();

            byte[] buffer = new byte[130];
            while (stream.Read(buffer, 0, 130) > 0)
            {
                var content = OrdnungsbegriffeWriter.WriterEncoding.GetString(buffer);
                content = content.Replace(LINE_END, string.Empty);
                ordnungsbegriffe.Add(Data.Ordnungsbegriffe.FromString(content));
            }

            return new OrdnungsbegriffeFile(DateTime.Now, ordnungsbegriffe);
        }
    }
}
