using System;
using System.Collections.Generic;

namespace ArgeHeiwako.Data
{
    public sealed class Abrechnungsunternehmen
    {
        #region Tabelle "U"
        private static readonly IDictionary<int, Abrechnungsunternehmen> unternehmen = new Dictionary<int, Abrechnungsunternehmen>()
        {
          {30, new Abrechnungsunternehmen(30,"Techem, Eschborn")}

        , {31, new Abrechnungsunternehmen(31,"Brunata, Hamburg")}
        , {32, new Abrechnungsunternehmen(32,"Brunata, Köln")}
        , {33, new Abrechnungsunternehmen(33,"Brunata-Minol, Stuttgart")}
        , {34, new Abrechnungsunternehmen(34,"Brunata, München")}
        , {35, new Abrechnungsunternehmen(35,"Landis & Gyr, Berlin")}
        , {36, new Abrechnungsunternehmen(36,"Heimer Concept, Gütersloh")}
        , {37, new Abrechnungsunternehmen(37,"BFW, München")}
        , {38, new Abrechnungsunternehmen(38,"BFW, Karlsruhe")}
        , {39, new Abrechnungsunternehmen(39,"IBIA, Solingen") }
        , {40, new Abrechnungsunternehmen(40,"ista Deutschland GmbH, Essen")}
        , {41, new Abrechnungsunternehmen(41,"Kalorimeta, Hamburg")}
        , {42, new Abrechnungsunternehmen(42,"ENDACOM, Frankfurt")}
        , {43, new Abrechnungsunternehmen(43,"Schyma GmbH, Muehltal")}
        , {44, new Abrechnungsunternehmen(44,"energie Control, Bochum")}
        , {47, new Abrechnungsunternehmen(47,"DUO2000, Hemsbach")}
        , {48, new Abrechnungsunternehmen(48,"A+S GmbH, Willich")}
        , {49, new Abrechnungsunternehmen(49,"Eck.Meier GmbH, Braunschweig")}
        , {51, new Abrechnungsunternehmen(51,"Stegmeier Messtechnik, Flein")}
        , {52, new Abrechnungsunternehmen(52,"Tenie und Gores, Wesel")}
        , {53, new Abrechnungsunternehmen(53,"Skibatron, Herne")}
        , {54, new Abrechnungsunternehmen(54,"EAD, Gera")}
        , {55, new Abrechnungsunternehmen(55,"Wärme-Komfort, Hamburg")}
        , {57, new Abrechnungsunternehmen(57,"DHC Mess Team, Bad Deckenstedt")}
        , {58, new Abrechnungsunternehmen(58,"MESSTRONIC Mörner, Gräfenwiesbach")}
        , {62, new Abrechnungsunternehmen(62,"Becker & Harms, Potsdamm")}
        , {65, new Abrechnungsunternehmen(65,"Delta-T, Mettmann")}
        , {66, new Abrechnungsunternehmen(66,"TDH Uwe Lerch, Hamburg")}
        , {67, new Abrechnungsunternehmen(67,"Mess-Wärme-West, Bonn(Bad Honnef)")}
        , {68, new Abrechnungsunternehmen(68,"Deutsche KB, Nürnberg")}
        , {69, new Abrechnungsunternehmen(69,"Delta-T Messdienst Wenzel, Herodsberg")}
        , {70, new Abrechnungsunternehmen(70,"Delta-T Asko, Erfurt")}
        , {71, new Abrechnungsunternehmen(71,"SVM, Schloss Holte")}
        , {72, new Abrechnungsunternehmen(72,"Stadtwerke Halberstadt")}
        , {73, new Abrechnungsunternehmen(73,"Stadtwerke Essen")}
        , {75, new Abrechnungsunternehmen(75,"Fidentia Messdienst, Bamberg")}
        , {76, new Abrechnungsunternehmen(76,"Heimer-Concept WMD-Nord, Quickborn")}
        , {77, new Abrechnungsunternehmen(77,"Semeco, Flensburg")}
        };

        public static Abrechnungsunternehmen Find(int nummer)
        {
            return unternehmen[nummer];
        }

        #endregion

        public int Nummer { get; private set; }

        public string Name { get; private set; }

        internal Abrechnungsunternehmen(int nummer, string name)
        {
            Nummer = nummer;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Nummer:00}";
        }
    }
}