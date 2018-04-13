using ArgeHeiwako.Data.Common;
using System;

namespace ArgeHeiwako.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Abrechnungssatz
    {
        private ArgeVersion argeVersion;
        private Kostenart kostenart;
        private KundenNummer kundenNummer;
        private Tag letzterTagNutzungszeitraum;
        private OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen;
        private OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen;
        private Waehrung waehrung;

        /// <summary>
        /// Erstellt eine neue <see cref="Abrechnungssatz"/>-Instanz
        /// </summary>
        /// <param name="argeVersion">Die Version für den Datenaustausch</param>
        /// <param name="kundenNummer"></param>
        /// <param name="ordnungsbegriffAbrechnungsunternehmen"></param>
        /// <param name="ordnungsbegriffWohnungsunternehmen"></param>
        /// <param name="letzterTagNutzungszeitraum"></param>
        /// <param name="kostenart"></param>
        /// <param name="waehrung"></param>
        /// <param name="gesamtkostenBrutto"></param>
        /// <param name="gesamtkostenNetto"></param>
        /// <param name="vorauszahlungBrutto"></param>
        /// <param name="vorauszahlungNetto"></param>
        /// <param name="neueVorauszahlungMonatlichBrutto"></param>
        /// <param name="neueVorauszahlungMontatlichNetto"></param>
        /// <param name="umlageausfallwagnis"></param>
        /// <param name="saldoBrutto"></param>
        /// <param name="saldoNetto"></param>
        /// <param name="verbrauchsanteile"></param>
        /// <param name="einheitVerbrauchsanteile"></param>
        /// <param name="ableseKennzeichen"></param>
        /// <param name="nutzername"></param>
        public Abrechnungssatz(
            ArgeVersion argeVersion,
            KundenNummer kundenNummer,
            OrdnungsbegriffAbrechnungsunternehmen ordnungsbegriffAbrechnungsunternehmen,
            OrdnungsbegriffWohnungsunternehmen ordnungsbegriffWohnungsunternehmen,
            Tag letzterTagNutzungszeitraum,
            Kostenart kostenart,
            Waehrung waehrung,
            Betrag gesamtkostenBrutto = null,
            Betrag gesamtkostenNetto = null,
            Betrag vorauszahlungBrutto = null,
            Betrag vorauszahlungNetto = null,
            Betrag neueVorauszahlungMonatlichBrutto = null,
            Betrag neueVorauszahlungMontatlichNetto = null,
            Betrag umlageausfallwagnis = null,
            Betrag saldoBrutto = null,
            Betrag saldoNetto = null,
            Anteil verbrauchsanteile = null,
            Einheit einheitVerbrauchsanteile = null,
            Ablesekennzeichen ableseKennzeichen = null,
            Name nutzername = null)
        {
            this.argeVersion = argeVersion ?? throw new ArgumentNullException(nameof(argeVersion));
            this.kundenNummer = kundenNummer ?? throw new ArgumentNullException(nameof(kundenNummer));
            this.ordnungsbegriffAbrechnungsunternehmen = ordnungsbegriffAbrechnungsunternehmen ?? throw new ArgumentNullException(nameof(ordnungsbegriffAbrechnungsunternehmen));
            this.ordnungsbegriffWohnungsunternehmen = ordnungsbegriffWohnungsunternehmen ?? throw new ArgumentNullException(nameof(ordnungsbegriffWohnungsunternehmen));
            this.letzterTagNutzungszeitraum = letzterTagNutzungszeitraum ?? throw new ArgumentNullException(nameof(letzterTagNutzungszeitraum));
            this.kostenart = kostenart ?? throw new ArgumentNullException(nameof(kostenart));
            this.waehrung = waehrung ?? throw new ArgumentNullException(nameof(waehrung));


        }
    }
}