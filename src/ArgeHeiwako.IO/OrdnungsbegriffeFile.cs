using System;
using System.Collections.Generic;
using ArgeHeiwako.Data;
using System.IO;

namespace ArgeHeiwako.IO
{
    public sealed class OrdnungsbegriffeFile
    {
        public DateTime Created { get; private set; }

        public string FileName
        {
            get
            {
                return $"DTA305_{Created.ToString("yyyyMMddHHmmss")}.DAT";
            }
        }

        public OrdnungsbegriffeFile(DateTime created)
        {
            Created = created;
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
    }
}
