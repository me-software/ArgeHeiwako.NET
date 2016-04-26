using ArgeHeiwako.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace ArgeHeiwako.IO
{
    /// <summary>
    /// Diese Klasse repräsentiert eine E898-Datenaustauschdatei. 
    /// </summary>
    /// <remarks>Die innerhalb dieser Klasse referenzierten Dokumente oder Bild-Dateien sind nicht Bestandteil dieser Klasse</remarks>
    public class NutzerAbrechnungBildFile : ArgeFile<NutzerAbrechnungBild>
    {
        private const string LINE_END = "\r\n";

        /// <summary>
        /// Erstellt eine neue <see cref="NutzerAbrechnungBildFile"/>-Instanz
        /// </summary>
        /// <param name="created"></param>
        /// <param name="datensaetze"></param>
        public NutzerAbrechnungBildFile(DateTime created, IEnumerable<NutzerAbrechnungBild> datensaetze) 
            : base(created, NutzerAbrechnungBild.Satzart, datensaetze, false)
        {
        }

        /// <summary>
        /// Schreibt die <see cref="NutzerAbrechnungBild"/>-Instanzen in die Datei und nutzt das aktuelle Ausführungsverzeichnis
        /// </summary>
        public void Write()
        {
            Write(Environment.CurrentDirectory);
        }

        /// <summary>
        /// Schreibt die <see cref="NutzerAbrechnungBild"/>-Instanzen in die Datei und nutzt das angegebene Verzeichnis als Ablageort
        /// </summary>
        /// <param name="directory">Das Zielverzeichnis</param>
        /// <exception cref="ArgumentNullException">Wenn das Verzeichnis <paramref name="directory"/> NULL ist.</exception>
        public void Write(string directory)
        {
            if (directory == null)
                throw new ArgumentNullException(nameof(directory));

            var filePath = Path.Combine(directory, FileName);
            using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
            {
                using (var writer = new NutzerAbrechnungBildWriter(fileStream))
                {
                    foreach (var datensatz in Datensaetze)
                    {
                        writer.Write(datensatz);
                    }

                    fileStream.Flush();
                }
            }
        }

        /// <summary>
        /// Erzeugt aus einem <see cref="Stream"/> eine neue <see cref="NutzerAbrechnungBildFile"/>-Instanz
        /// </summary>
        /// <param name="stream">Der Stream aus dem gelesen wird.</param>
        /// <returns>Die ermittelte <see cref="NutzerAbrechnungBildFile"/>-Instanz.</returns>
        public static NutzerAbrechnungBildFile Load(Stream stream)
        {
            var datensaetze = new List<NutzerAbrechnungBild>();
            var bufferLength = NutzerAbrechnungBild.StringLength + LINE_END.Length;
            byte[] buffer = new byte[bufferLength];
            while (stream.Read(buffer, 0, bufferLength) > 0)
            {
                var content = NutzerAbrechnungBildWriter.WriterEncoding.GetString(buffer);
                content = content.Replace(LINE_END, string.Empty);
                datensaetze.Add(NutzerAbrechnungBild.FromString(content));
            }

            return new NutzerAbrechnungBildFile(DateTime.Now, datensaetze);
        }
    }
}
