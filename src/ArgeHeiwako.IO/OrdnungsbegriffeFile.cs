using System;

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

        private OrdnungsbegriffeFile()
            : this(DateTime.Now)
        {
        }

        public OrdnungsbegriffeFile(DateTime created)
        {
            Created = created;
        }
    }
}
