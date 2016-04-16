using System;
using System.Collections.Generic;
using ArgeHeiwako.Data;
using System.IO;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Diese Klasse repräsentiert eine E835 Datenaustauschdatei
    /// </summary>
    public class AnteilSteuerlicheLeistungsartFile : ArgeFile<AnteilSteuerlicheLeistungsart>
    {
        private const string LINE_END = "\r\n";

        /// <summary>
        /// Liefert die Kennzeichnung der Satzart
        /// </summary>
        public const string Satzart = "E835";

        /// <summary>
        /// Erstellt eine <see cref="AnteilSteuerlicheLeistungsartFile"/>-Instanz
        /// </summary>
        /// <param name="created"></param>
        /// <param name="datensaetze"></param>
        public AnteilSteuerlicheLeistungsartFile(DateTime created, IEnumerable<AnteilSteuerlicheLeistungsart> datensaetze)
            : base(created, Satzart, datensaetze)
        {
        }

        /// <summary>
        /// Schreibt die <see cref="AnteilSteuerlicheLeistungsart"/>-Instanzen in die Datei und nutzt das angegebene Verzeichnis
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
                using (var writer = new AnteilSteuerlicheLeistungsartWriter(fileStream))
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
        /// Schreibt die <see cref="AnteilSteuerlicheLeistungsart"/>-Instanzen in die Datei und nutzt das aktuelle Ausführungsverzeichnis
        /// </summary>
        public void Write()
        {
            Write(Environment.CurrentDirectory);
        }

        /// <summary>
        /// Erzeugt aus einem <see cref="Stream"/> eine neue <see cref="AnteilSteuerlicheLeistungsartFile"/>-Instanz
        /// </summary>
        /// <param name="stream">Der Stream aus dem gelesen wird.</param>
        /// <returns>Die ermittelte <see cref="AnteilSteuerlicheLeistungsartFile"/>-Instanz.</returns>
        public static AnteilSteuerlicheLeistungsartFile Load(Stream stream)
        {
            var datensaetze = new List<AnteilSteuerlicheLeistungsart>();
            byte[] buffer = new byte[135];
            while (stream.Read(buffer, 0, 135) > 0)
            {
                var content = OrdnungsbegriffeWriter.WriterEncoding.GetString(buffer);
                content = content.Replace(LINE_END, string.Empty);
                datensaetze.Add(AnteilSteuerlicheLeistungsart.FromString(content));
            }

            return new AnteilSteuerlicheLeistungsartFile(DateTime.Now, datensaetze);
        }
    }
}