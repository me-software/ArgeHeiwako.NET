using System;
using System.Collections.Generic;
using ArgeHeiwako.Data;
using System.IO;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Diese Klasse repräsentiert eine Datenaustauschdatei für den A-Satz
    /// </summary>
    public sealed class OrdnungsbegriffeFile : ArgeFile<Ordnungsbegriffe>
    {
        private const string LINE_END = "\r\n";

        /// <summary>
        /// Erstellt eine neue <see cref="OrdnungsbegriffeFile"/>-Instanz
        /// </summary>
        /// <param name="created">Erstellungszeitpunkt</param>
        /// <param name="ordnungsbegriffe">>Auflistung der zu verwendenden <see cref="Data.Ordnungsbegriffe"/>-Instanzen</param>
        public OrdnungsbegriffeFile(DateTime created, IEnumerable<Ordnungsbegriffe> ordnungsbegriffe)
            : base(created, Ordnungsbegriffe.Satzart, ordnungsbegriffe, true)
        {
        }
         
        /// <summary>
        /// Schreibt die <see cref="Data.Ordnungsbegriffe"/>-Instanzen in die Datei und nutzt das aktuelle Ausführungsverzeichnis
        /// </summary>
        public void Write()
        {
            Write(Environment.CurrentDirectory);
        }

        /// <summary>
        /// Schreibt die <see cref="Data.Ordnungsbegriffe"/>-Instanzen in die Datei und nutzt das aktuelle Ausführungsverzeichnis
        /// </summary>
        /// <param name="directory">Das Zielverzeichnis</param>
        /// <exception cref="ArgumentNullException">Wenn das Verzeichnis <paramref name="directory"/> NULL ist.</exception>
        public void Write(string directory)
        {
            if (directory == null)
                throw new ArgumentNullException("directory");

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var filePath = Path.Combine(directory, FileName);
            using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
            {
                using (var writer = new OrdnungsbegriffeWriter(fileStream))
                {
                    foreach (var begriffe in Datensaetze)
                    {
                        writer.Write(begriffe);
                    }

                    fileStream.Flush();
                }
            }
        }

        /// <summary>
        /// Erzeugt aus einem <see cref="Stream"/> eine neue <see cref="Ordnungsbegriffe"/>-Instanz
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
                ordnungsbegriffe.Add(Ordnungsbegriffe.FromString(content));
            }

            return new OrdnungsbegriffeFile(DateTime.Now, ordnungsbegriffe);
        }
    }
}
