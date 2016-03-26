using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Test
    /// </summary>
    public sealed class ErweiterterOrdnungsbegriffAbrechnungsunternehmen : OrdnungsbegriffAbrechnungsunternehmen
    {
        /// <summary>
        /// test
        /// </summary>
        /// <param name="liegenschaftsNummer"></param>
        /// <param name="nutzergruppenNummer"></param>
        /// <param name="wohnungsNummer"></param>
        /// <param name="nutzerfolge"></param>
        public ErweiterterOrdnungsbegriffAbrechnungsunternehmen(LiegenschaftsNummer liegenschaftsNummer, NutzergruppenNummer nutzergruppenNummer, WohnungsNummer wohnungsNummer, Nutzerfolge nutzerfolge)
            : base(liegenschaftsNummer, wohnungsNummer)
        {
        }
    }
}
