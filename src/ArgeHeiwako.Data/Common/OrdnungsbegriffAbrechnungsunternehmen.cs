﻿using System;
using System.Collections.Generic;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert den Ordnungsbegriff eines Abrechnungsunternehmens
    /// </summary>
    /// <remarks>
    /// Ein Abrechnungsunternehmen verwendet grundsätzlich den Begriff einer Liegenschaft. Eine Liegenschaft ist in 
    /// unterschiedliche Einheiten gegliedert, unter denen die Kosten aufgeteilt werden. 
    /// </remarks>
    public class OrdnungsbegriffAbrechnungsunternehmen
    {
        private readonly LiegenschaftsNummer liegenschaftsNummer;
        private readonly WohnungsNummer wohnungsNummer;

        /// <summary>
        /// Erstellt eine neue <see cref="OrdnungsbegriffAbrechnungsunternehmen"/>-Instanz
        /// </summary>
        /// <param name="liegenschaftsNummer">Identifikationsnummer der Liegenschaft</param>
        /// <param name="wohnungsNummer">Identifikationsnummer der Wohnung / Einheit</param>
        public OrdnungsbegriffAbrechnungsunternehmen(LiegenschaftsNummer liegenschaftsNummer, WohnungsNummer wohnungsNummer)
        {
            if (liegenschaftsNummer == null)
                throw new ArgumentNullException("liegenschaftsNummer");

            if (wohnungsNummer == null)
                throw new ArgumentNullException("wohnungsNummer");

            this.liegenschaftsNummer = liegenschaftsNummer;
            this.wohnungsNummer = wohnungsNummer;
        }

        /// <summary>
        /// Liefert die Liegenschaftsnummer
        /// </summary>
        public object LiegenschaftsNummer
        {
            get { return liegenschaftsNummer; }
        }

        /// <summary>
        /// Liefert die Wohnungsnummer
        /// </summary>
        public WohnungsNummer WohnungsNummer
        {
            get { return wohnungsNummer; }
        }

        /// <summary>
        ///Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return $"{liegenschaftsNummer}{wohnungsNummer}";
        }
    }
}