using ArgeHeiwako.Data.Properties;
using System;
using System.Collections.Generic;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert ein Abrechnungsunternehmen, so wie es in der Version 3.05 im Abschnitt
    /// 11.9 des Standard-Datenaustausches definiert ist.
    /// </summary>
    public sealed class Abrechnungsunternehmen
    {
        #region Tabelle "U"

        private static readonly IDictionary<int, Abrechnungsunternehmen> unternehmen =
            new Dictionary<int, Abrechnungsunternehmen>()
            {
                {30, new Abrechnungsunternehmen(30,"Techem, Eschborn")},
                {31, new Abrechnungsunternehmen(31,"Brunata, Hamburg")},
                {32, new Abrechnungsunternehmen(32,"Brunata, Köln")} ,
                {33, new Abrechnungsunternehmen(33,"Brunata-Minol, Stuttgart")} ,
                {34, new Abrechnungsunternehmen(34,"Brunata, München")} ,
                {35, new Abrechnungsunternehmen(35,"Landis & Gyr, Berlin")} ,
                {36, new Abrechnungsunternehmen(36,"Heimer Concept, Gütersloh")} ,
                {37, new Abrechnungsunternehmen(37,"BFW, München")} ,
                {38, new Abrechnungsunternehmen(38,"BFW, Karlsruhe")} ,
                {39, new Abrechnungsunternehmen(39,"IBIA, Solingen") } ,
                {40, new Abrechnungsunternehmen(40,"ista Deutschland GmbH, Essen")} ,
                {41, new Abrechnungsunternehmen(41,"Kalorimeta, Hamburg")} ,
                {42, new Abrechnungsunternehmen(42,"ENDACOM, Frankfurt")} ,
                {43, new Abrechnungsunternehmen(43,"Schyma GmbH, Muehltal")} ,
                {44, new Abrechnungsunternehmen(44,"energie Control, Bochum")} ,
                {47, new Abrechnungsunternehmen(47,"DUO2000, Hemsbach")} ,
                {48, new Abrechnungsunternehmen(48,"A+S GmbH, Willich")} ,
                {49, new Abrechnungsunternehmen(49,"Eck.Meier GmbH, Braunschweig")} ,
                {51, new Abrechnungsunternehmen(51,"Stegmeier Messtechnik, Flein")} ,
                {52, new Abrechnungsunternehmen(52,"Tenie und Gores, Wesel")} ,
                {53, new Abrechnungsunternehmen(53,"Skibatron, Herne")} ,
                {54, new Abrechnungsunternehmen(54,"EAD, Gera")} ,
                {55, new Abrechnungsunternehmen(55,"Wärme-Komfort, Hamburg")} ,
                {57, new Abrechnungsunternehmen(57,"DHC Mess Team, Bad Deckenstedt")} ,
                {58, new Abrechnungsunternehmen(58,"MESSTRONIC Mörner, Gräfenwiesbach")} ,
                {62, new Abrechnungsunternehmen(62,"Becker & Harms, Potsdamm")} ,
                {65, new Abrechnungsunternehmen(65,"Delta-T, Mettmann")} ,
                {66, new Abrechnungsunternehmen(66,"TDH Uwe Lerch, Hamburg")} ,
                {67, new Abrechnungsunternehmen(67,"Mess-Wärme-West, Bonn(Bad Honnef)")} ,
                {68, new Abrechnungsunternehmen(68,"Deutsche KB, Nürnberg")} ,
                {69, new Abrechnungsunternehmen(69,"Delta-T Messdienst Wenzel, Herodsberg")} ,
                {70, new Abrechnungsunternehmen(70,"Delta-T Asko, Erfurt")} ,
                {71, new Abrechnungsunternehmen(71,"SVM, Schloss Holte")} ,
                {72, new Abrechnungsunternehmen(72,"Stadtwerke Halberstadt")} ,
                {73, new Abrechnungsunternehmen(73,"Stadtwerke Essen")} ,
                {75, new Abrechnungsunternehmen(75,"Fidentia Messdienst, Bamberg")} ,
                {76, new Abrechnungsunternehmen(76,"Heimer-Concept WMD-Nord, Quickborn")} ,
                {77, new Abrechnungsunternehmen(77,"Semeco, Flensburg")}
            };

        #endregion

        /// <summary>
        /// Liefert die numerische Kennung des Abrechnungsunternehmen
        /// </summary>
        public int Nummer { get; private set; }

        /// <summary>
        /// Liefert die textuelle Bezeichnung des Abrechungsunternehmens
        /// </summary>
        public string Name { get; private set; }

        internal Abrechnungsunternehmen(int nummer, string name)
        {
            Nummer = nummer;
            Name = name;
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datentausch-Datei
        /// </summary>
        /// <returns>Der formatierte String für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return $"{Nummer:00}";
        }

        /// <summary>
        /// Ermittelt aus <paramref name="abrechnungsunternehmen"/> ein Abrechnungsunternehmen aus der Tabelle U
        /// </summary>
        /// <remarks>
        /// Diese Methode soll verwendet werden, wenn aus einer Datenaustausch-Datei gelesen wird, um eine korrekte Prüfung
        /// des <see cref="Abrechnungsunternehmen"/> gewährleisten zu können.
        /// </remarks>
        /// <param name="abrechnungsunternehmen">Den Feldwert aus der Datenaustausch-Datei, welcher ein Abrechnunsunternehmen repräsentiert.</param>
        /// <returns>Die Instanz des ermittelten <see cref="Abrechnungsunternehmen"/> oder NULL</returns>
        /// <exception cref="ArgumentNullException">Wenn der Parameter <paramref name="abrechnungsunternehmen"/> NULL ist.</exception>
        /// <exception cref="ArgumentException">Wenn keine valide Kennung des <see cref="Abrechnungsunternehmen"/> im Parameter <paramref name="abrechnungsunternehmen"/> übergeben wird.</exception>
        /// <exception cref="KeyNotFoundException">Wenn für die Kennung in <paramref name="abrechnungsunternehmen"/> kein Abrechnungsunternehmen ermittelt werden kann.</exception>
        internal static Abrechnungsunternehmen FromString(string abrechnungsunternehmen)
        {
            if (abrechnungsunternehmen == null)
                throw new ArgumentNullException("abrechnungsunternehmen");

            int kennungNummeric = 0;
            if (abrechnungsunternehmen.Length == 2)
            {
                if (abrechnungsunternehmen == "  ")
                    return null;

                if (!int.TryParse(abrechnungsunternehmen, out kennungNummeric))
                    throw new ArgumentException(Resources.EXP_MSG_VALID_ABRECHNUNGSUNTERNEHMENKENNUNG, "abrechnungsunternehmen");
            }
            else
                throw new ArgumentException(Resources.EXP_MSG_VALID_ABRECHNUNGSUNTERNEHMENKENNUNG, "abrechnungsunternehmen");

            return Finde(kennungNummeric);
        }

        /// <summary>
        /// Ermittelt ein <see cref="Abrechnungsunternehmen"/> anhand der übergebenen numerischen Kennung
        /// </summary>
        /// <param name="nummer">Die numerische Kennung des <see cref="Abrechnungsunternehmen"/></param>
        /// <returns>Das ermittelte <see cref="Abrechnungsunternehmen"/></returns>
        /// <exception cref="KeyNotFoundException">Wenn für die Kennung in <paramref name="nummer"/> kein Abrechnungsunternehmen ermittelt werden kann.</exception>
        public static Abrechnungsunternehmen Finde(int nummer)
        {
            return unternehmen[nummer];
        }

        /// <summary>
        /// Ermittelt ein <see cref="Abrechnungsunternehmen"/> anhand der übergebenen numerischen Kennung
        /// </summary>
        /// <param name="nummer">Die numerische Kennung des <see cref="Abrechnungsunternehmen"/></param>
        /// <returns>Das ermittelte <see cref="Abrechnungsunternehmen"/></returns>
        /// <exception cref="KeyNotFoundException">Wenn für die Kennung in <paramref name="nummer"/> kein Abrechnungsunternehmen ermittelt werden kann.</exception>
        public static Abrechnungsunternehmen Finde(string nummer)
        {
            return unternehmen[int.Parse(nummer)];
        }
    }
}