using System;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Basisimplementierung einer Datenaustauschdatei
    /// </summary>
    public abstract class ArgeFile : IArgeFile
    {
        private readonly DateTime created;
        private readonly string satzart;

        /// <summary>
        /// Liefert den Erstellungszeitpunkt der Datei
        /// </summary>
        public DateTime Created
        {
            get
            {
                return created;
            }
        }

        /// <summary>
        /// Liefert den Dateinamen der Datenaustauschdatei
        /// </summary>
        public string FileName
        {
            get
            {
                return $"DT{satzart}305_{Created.ToString("yyyyMMddHHmmss")}.DAT";
            }
        }

        /// <summary>
        /// Erstellt eine neue <see cref="ArgeFile"/>-Instanz
        /// </summary>
        /// <param name="created">Der Erstellungszeitpunkt der Datei</param>
        /// <param name="satzart">Die Satzart der Datei</param>
        public ArgeFile(DateTime created, string satzart)
        {
            #region Contracts
            if (satzart == null)
                throw new ArgumentNullException(nameof(satzart));
            #endregion

            this.created = created;
            this.satzart = satzart;
        }
    }
}
