using System;
using System.Collections.Generic;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Diese Klasse repräsentiert die im Datenaustausch definierten Einheiten für entsprechende Angaben innerhalb 
    /// der Datenaustauschdatei gemäß der Tabelle "E"
    /// </summary>
    public sealed class Einheit
    {
        #region Tabelle "E"

        private static readonly IDictionary<string, Einheit> einheiten = new Dictionary<string, Einheit>
        {
            { "001", GJ = new Einheit("001","GJ") },
            { "002", MWh = new Einheit("002","MWh") },
            { "003", Kubikmeter = new Einheit("003","m³") },
            { "004", Kalorien = new Einheit("004","kcal") },
            { "005", KilowattStunde = new Einheit("005","kWh") },
            { "010", QmWohnflaeche = new Einheit("010","m² Wohnfläche") },
            { "011", QmBeheizteWohnflaeche = new Einheit("011","m² beheizte Wohnfläche") },
            { "012", CmUmbauterRaum = new Einheit("012","m³ umbauter Raum") },
            { "014", CmBeheizterUmbauterRaum = new Einheit("014","m³ beheizter umbauter Wohnraum") },
            { "015", VariablesTextfeld = new Einheit("015","variables Textfeld für Schlüssel") },
            { "016", Miteigentumsanteil = new Einheit("016","Miteigentumsanteil") },
            { "017", QmNutzflaeche = new Einheit("017","m² Nutzfläche") },
            { "020", Anschlusswert = new Einheit("020","Anschlusswert") },
            { "021", Zaehler = new Einheit("021","Zähler") },
            { "022", Wohnung = new Einheit("022","Wohnung") },
            { "023", Abrechnung = new Einheit("023","Abrechnung") },
            { "030", Verbrauchseinheiten = new Einheit("030","Verbrauchseinheiten (VE)") },
            { "031", Verbrauchswerte = new Einheit("031","Verbrauchswerte") },
            { "032", Striche = new Einheit("032","Striche (Venturi)") },
            { "033", KilojouleProSekunde = new Einheit("033","1000 J/Sec.") },
            { "034", PersonenMalMonate = new Einheit("034","Personen x Monate") },
            { "035", Personen = new Einheit("035","Personen") },
            { "040", Prozent = new Einheit("040","Prozent") },
            { "041", Jahre = new Einheit("041","Jahr") },
            { "042", Monate = new Einheit("042","Monat") },
            { "043", Tage = new Einheit("043","Tage") },
            { "044", Gradtage = new Einheit("044","Gradtage") },
            { "045", PromilleAnteile = new Einheit("045","‰ – Anteile") },
            { "046", AnzahlRauchwarnmelder = new Einheit("046","Anzahl Rauchwarnmelder") }
        };

        #endregion

        #region Schnellzugriff auf Einheiten

        /// <summary>
        /// GJ
        /// </summary>
        public static Einheit GJ { get; private set; }

        /// <summary>
        /// MWh
        /// </summary>
        public static Einheit MWh { get; private set; }

        /// <summary>
        /// m³
        /// </summary>
        public static Einheit Kubikmeter { get; private set; }

        /// <summary>
        /// kcal
        /// </summary>
        public static Einheit Kalorien { get; private set; }

        /// <summary>
        /// kWh
        /// </summary>
        public static Einheit KilowattStunde { get; private set; }

        /// <summary>
        /// m² Wohnfläche
        /// </summary>
        public static Einheit QmWohnflaeche { get; private set; }

        /// <summary>
        /// m² beheizte Wohnfläche
        /// </summary>
        public static Einheit QmBeheizteWohnflaeche { get; private set; }

        /// <summary>
        /// m³ umbauter Raum
        /// </summary>
        public static Einheit CmUmbauterRaum { get; private set; }

        /// <summary>
        /// m³ beiheiter umbauter Raum
        /// </summary>
        public static Einheit CmBeheizterUmbauterRaum { get; private set; }

        /// <summary>
        /// Variables Textfeld für Einheit
        /// </summary>
        public static Einheit VariablesTextfeld { get; private set; }

        /// <summary>
        /// Miteigentumsanteil
        /// </summary>
        public static Einheit Miteigentumsanteil { get; private set; }

        /// <summary>
        /// m² Nutzfläche
        /// </summary>
        public static Einheit QmNutzflaeche { get; private set; }

        /// <summary>
        /// Anschlusswert
        /// </summary>
        public static Einheit Anschlusswert { get; private set; }

        /// <summary>
        /// Zähler
        /// </summary>
        public static Einheit Zaehler { get; private set; }

        /// <summary>
        /// Wohnung
        /// </summary>
        public static Einheit Wohnung { get; private set; }

        /// <summary>
        /// Abrechnung
        /// </summary>
        public static Einheit Abrechnung { get; private set; }

        /// <summary>
        /// Verbrauchseinheiten
        /// </summary>
        public static Einheit Verbrauchseinheiten { get; private set; }

        /// <summary>
        /// Verbrauchswerte
        /// </summary>
        public static Einheit Verbrauchswerte { get; private set; }

        /// <summary>
        /// Striche
        /// </summary>
        public static Einheit Striche { get; private set; }

        /// <summary>
        /// 1000 J/Sek.
        /// </summary>
        public static Einheit KilojouleProSekunde { get; private set; }

        /// <summary>
        /// Personen x Monate
        /// </summary>
        public static Einheit PersonenMalMonate { get; private set; }

        /// <summary>
        /// Personen
        /// </summary>
        public static Einheit Personen { get; private set; }

        /// <summary>
        /// Jahre
        /// </summary>
        public static Einheit Jahre { get; private set; }

        /// <summary>
        /// Monate
        /// </summary>
        public static Einheit Monate { get; private set; }

        /// <summary>
        /// Tage
        /// </summary>
        public static Einheit Tage { get; private set; }

        /// <summary>
        /// Gradtage
        /// </summary>
        public static Einheit Gradtage { get; private set; }

        /// <summary>
        /// Promille Anteile
        /// </summary>
        public static Einheit PromilleAnteile { get; private set; }

        /// <summary>
        /// Anzahl Rauchmelder
        /// </summary>
        public static Einheit AnzahlRauchwarnmelder { get; private set; }

        /// <summary>
        /// Prozent
        /// </summary>
        public static Einheit Prozent { get; private set; }

        #endregion

        private readonly string schluessel;
        private readonly string bezeichnung;

        /// <summary>
        /// Liefert den Schlüssel der Einheit
        /// </summary>
        public string Schluessel { get { return schluessel; } }

        /// <summary>
        /// Liefert die Beschreibung der Einheit zu dem Schlüssel
        /// </summary>
        public string Bezeichnung { get { return bezeichnung; } }

        private Einheit(string schluessel, string bezeichnung)
        {
            this.schluessel = schluessel;
            this.bezeichnung = bezeichnung;
        }

        /// <summary>
        /// Liefert die formatierte Ausgabe für die Verwendung in einer Datenaustauschdatei
        /// </summary>
        /// <returns>Der formatierte <see cref="string"/> für die Datenaustauschdatei</returns>
        public override string ToString()
        {
            return schluessel;
        }

        /// <summary>
        /// Ermittelt die <see cref="Einheit"/> aus der textuellen Repräsentation der Datenaustauschdatei 
        /// </summary>
        /// <param name="einheit">Der textuelle Wert aus dem Feld der Datenaustauschdatei</param>
        /// <returns>Die ermittelte <see cref="Einheit"/></returns>
        /// <exception cref="ArgumentNullException">Wenn als <paramref name="einheit"/> NULL übergeben wird.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Wenn als <paramref name="einheit"/> ein ungültiger Wert übergeben wird.</exception>
        public static Einheit FromString(string einheit)
        {
            if (einheit == null)
                throw new ArgumentNullException(nameof(einheit));
            if (einheit.Length == 0 || !einheiten.ContainsKey(einheit))
                throw new ArgumentOutOfRangeException(nameof(einheit));

            return einheiten[einheit];
        }
    }
}