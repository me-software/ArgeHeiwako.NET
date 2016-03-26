using System;

namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// Generische Basisklasse für alle Nummern und ganzzahlige numerischen Felder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Nummer<T> where T : IComparable
    {
        /// <summary>
        /// Geschützter Zugriff auf den numerischen Wert der <see cref="Nummer{T}"/>-Instanz
        /// </summary>
        protected readonly T value;

        /// <summary>
        /// Erstellt eine neue <see cref="Nummer{T}"/>-Instanz
        /// </summary>
        /// <param name="valueString">Der textuelle Wert aus der Datenaustauschdatei</param>
        /// <param name="stringLength">Die festgelegte Länge des Feldes aus der Datenaustauschdatei</param>
        /// <param name="parameterName">Name des ursprünglichen Parameters</param>
        /// <param name="parseFunction">Konvertierungsfunktion aus einem String in den gewünschten Wert vom Typ <typeparamref name="T"/></param>
        protected Nummer(string valueString, int stringLength, string parameterName, Func<string, ParseResult<T>> parseFunction)
        {
            if (valueString == null)
                throw new ArgumentNullException(parameterName);

            if (valueString.Length != stringLength)
                throw new ArgumentOutOfRangeException(parameterName);

            var parseResult = parseFunction(valueString);
            if (!parseResult.Success)
                throw new ArgumentOutOfRangeException(parameterName);

            this.value = parseResult.Value;
        }

        /// <summary>
        /// Erstellt eine neue <see cref="Nummer{T}"/>-Instanz
        /// </summary>
        /// <param name="value">Der numerische Wert</param>
        /// <param name="minValue">Der festgelegte minimale numerische Wert</param>
        /// <param name="maxValue">Der festgelegte maximale numerische Wert</param>
        /// <param name="parameterName">Name des ursprünglichen Parameters</param>
        protected Nummer(T value, T minValue, T maxValue, string parameterName)
        {
            if (value.CompareTo(minValue) < 0 || value.CompareTo(maxValue) > 0)
                throw new ArgumentOutOfRangeException(parameterName);

            this.value = value;
        }

        /// <summary>
        /// Implizite Konvertierung einer <see cref="Nummer{T}"/>-Instanz in ihren numerischen Wert vom Typ <typeparamref name="T"/>
        /// </summary>
        /// <param name="nummer">Die zu konvertierende <see cref="Nummer{T}"/>-Instanz.</param>
        /// <returns>Der numerische Wert der <see cref="Nummer{T}"/></returns>
        public static implicit operator T(Nummer<T> nummer)
        {
            return nummer.value;
        }
    }
}
