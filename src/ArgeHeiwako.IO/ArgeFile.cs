﻿using System;
using System.Collections.Generic;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Basisimplementierung einer Datenaustauschdatei
    /// </summary>
    public abstract class ArgeFile<TData> : IArgeFile<TData>
    {
        private readonly DateTime created;
        private readonly string satzart;
        private IEnumerable<TData> datensaetze;

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
        /// Liefert die in der Datei enthaltenen Datensätze 
        /// </summary>
        public IEnumerable<TData> Datensaetze
        {
            get { return datensaetze; }
        }

        /// <summary>
        /// Erstellt eine neue <see cref="ArgeFile{TData}"/>-Instanz
        /// </summary>
        /// <param name="created">Der Erstellungszeitpunkt der Datei</param>
        /// <param name="satzart">Die Satzart der Datei</param>
        /// <param name="datensaetze">Die Datensätze für die Datenaustauschdatei</param>
        public ArgeFile(DateTime created, string satzart, IEnumerable<TData> datensaetze)
        {
            #region Contracts
            if (satzart == null)
                throw new ArgumentNullException(nameof(satzart));
            #endregion

            this.datensaetze = datensaetze;
            this.created = created;
            this.satzart = satzart;
        }
    }
}
