using System;
using System.Collections.Generic;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Unterscheidung der unterschiedlichen Dokumentarten, die in der E898-Satzart 
    /// ausgetauscht werden können.
    /// </summary>
    public sealed class Dokumentart
    {
        private static IDictionary<string, Dokumentart> mapping = new Dictionary<string, Dokumentart>();

        /// <summary>
        /// Heizkostenabrechnung
        /// </summary>
        public static Dokumentart Heizkostenabrechnung = new Dokumentart("HKA");
        
        /// <summary>
        /// Betriebskostenabrechnung
        /// </summary>
        public static Dokumentart Betriebskostenabrechnung = new Dokumentart("BKA");

        /// <summary>
        /// Verbrauchsdatenanalyse
        /// </summary>
        public static Dokumentart Verbrauchsdatenanalyse = new Dokumentart("VDA");


        private string shortString;

        private Dokumentart(string shortString)
        {
            this.shortString = shortString;
            mapping.Add(shortString, this);
        }

        /// <summary>
        /// Konvertiert einen <see cref="string"/> in eine <see cref="Dokumentart"/>-Instanz
        /// </summary>
        /// <param name="dokumentartString">Den zu konvertierenden <see cref="string"/></param>
        /// <returns>Die konvertierte <see cref="Dokumentart"/>-Instanz</returns>
        /// <exception cref="InvalidCastException">Wenn der <see cref="string"/> aus <paramref name="dokumentartString"/> nicht in eine <see cref="Dokumentart"/> konvertiert werden kann</exception>
        public static explicit operator Dokumentart(string dokumentartString)
        {
            Dokumentart dokumentart = null;
            if (mapping.TryGetValue(dokumentartString, out dokumentart))
                return dokumentart;

            throw new InvalidCastException();
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return shortString;
        }
    }
}
