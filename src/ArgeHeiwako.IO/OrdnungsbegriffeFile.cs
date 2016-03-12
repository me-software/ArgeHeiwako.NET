using System;
using System.Collections.Generic;
using ArgeHeiwako.Data;
using System.IO;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Diese Klasse repräsentiert eine Datenaustauschdatei für den A-Satz
    /// </summary>
    public sealed class OrdnungsbegriffeFile
    {
        private const string LINE_END = "\r\n";

        /// <summary>
        /// Liefert den Erstellungszeitpunkt der Datei
        /// </summary>
        public DateTime Created { get; private set; }

        /// <summary>
        /// Liefert den Dateinamen
        /// </summary>
        public string FileName
        {
            get
            {
                return $"DTA305_{Created.ToString("yyyyMMddHHmmss")}.DAT";
            }
        }

        /// <summary>
        /// Liefert die Auflistung der enthaltenen <see cref="Ordnungsbegriffe"/>-Instanzen
        /// </summary>
        public IEnumerable<Ordnungsbegriffe> Ordnungsbegriffe { get; private set; }

        /// <summary>
        /// Erstellt eine leere <see cref="OrdnungsbegriffeFile"/>-Instanz
        /// </summary>
        /// <remarks>
        /// Es wird eine leere Liste von <see cref="Data.Ordnungsbegriffe"/>-Instanzen erzeugt, sowie 
        /// der aktuelle Zeitpunkt als Erstellungszeitpunkt genutzt.
        /// </remarks>
        public OrdnungsbegriffeFile() 
            : this(DateTime.Now, new List<Ordnungsbegriffe>())
        {
        }

        /// <summary>
        /// Erstellt eine leere <see cref="OrdnungsbegriffeFile"/>-Instanz
        /// </summary>
        /// <param name="created">Erstellungszeitpunkt</param>
        public OrdnungsbegriffeFile(DateTime created)
            : this(created, new List<Ordnungsbegriffe>())
        {
        }

        /// <summary>
        /// Erstellt eine neue <see cref="OrdnungsbegriffeFile"/>-Instanz
        /// </summary>
        /// <remarks>Es wird der aktuelle Zeitpunkt als Erstellungszeitpunkt genutzt.</remarks>
        /// <param name="ordnungsbegriffe">Auflistung der zu verwendenden <see cref="Data.Ordnungsbegriffe"/>-Instanzen</param>
        public OrdnungsbegriffeFile(IEnumerable<Ordnungsbegriffe> ordnungsbegriffe) 
            : this(DateTime.Now, ordnungsbegriffe)
        {
        }

        /// <summary>
        /// Erstellt eine neue <see cref="OrdnungsbegriffeFile"/>-Instanz
        /// </summary>
        /// <param name="created">Erstellungszeitpunkt</param>
        /// <param name="ordnungsbegriffe">>Auflistung der zu verwendenden <see cref="Data.Ordnungsbegriffe"/>-Instanzen</param>
        public OrdnungsbegriffeFile(DateTime created, IEnumerable<Ordnungsbegriffe> ordnungsbegriffe)
        {
            Created = created;
            Ordnungsbegriffe = ordnungsbegriffe;
        }

        /// <summary>
        /// Schreibt die <see cref="Data.Ordnungsbegriffe"/>-Instanzen in die Datei und nutzt das aktuelle Ausführungsverzeichnis
        /// </summary>
        /// <param name="ordnungsbegriffe">Auflistung der zu schreibenden <see cref="Data.Ordnungsbegriffe"/>-Instanzen</param>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="ordnungsbegriffe"/> NULL ist.</exception>
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

        /// <summary>
        /// Erzeugt aus einem <see cref="Stream"/> eine neue <see cref="Data.Ordnungsbegriffe"/>-Instanz
        /// </summary>
        /// <param name="stream">Der Stream aus dem gelesen wird.</param>
        /// <returns>Die ermittelte <see cref="OrdnungsbegriffeFile"/>-Instanz.</returns>
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
