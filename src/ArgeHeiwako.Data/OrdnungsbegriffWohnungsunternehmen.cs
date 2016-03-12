using System;

namespace ArgeHeiwako.Data
{
    /// <summary>
    /// Diese Klasse repräsentiert den Ordnungsbegriff eines Wohnungsunternehmens
    /// </summary>
    /// <remarks>
    /// Dieser Ordnungsbegriff wird von einem Wohnungsunternehmen verwendet,
    /// um eine Einheit / Wohnung innerhalb einer Liegenschaft des Abrechnungsunternehmen zu identifizieren.
    /// </remarks>
    public sealed class OrdnungsbegriffWohnungsunternehmen
    {
        private readonly string ordnungsbegriff;

        /// <summary>
        /// Erstellt eine neue <see cref="OrdnungsbegriffWohnungsunternehmen"/>-Instanz
        /// </summary>
        /// <param name="ordnungsbegriff">Die Kennung des Wohnungsunternehmens zur Identifizierung</param>
        /// <exception cref="ArgumentNullException">Wenn der <paramref name="ordnungsbegriff"/> NULL ist.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der <paramref name="ordnungsbegriff"/> länger als 20 Zeichen ist.</exception>
        public OrdnungsbegriffWohnungsunternehmen(string ordnungsbegriff)
        {
            if (ordnungsbegriff == null)
                throw new ArgumentNullException("ordnungsbegriff");

            if (ordnungsbegriff.Length > 20)
                throw new ArgumentOutOfRangeException("ordnungsbegriff");

            this.ordnungsbegriff = ordnungsbegriff.Trim();
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ordnungsbegriff.PadRight(20);
        }
    }
}