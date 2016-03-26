namespace ArgeHeiwako.Data.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ParseResult<T>
    {
        /// <summary>
        /// Liefert den Erfolgsstatus des Parse-Vorgangs
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// Liefert den ermittelten Wert des Parse-Vorgangs
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Erstellt eine neue <see cref="ParseResult{T}"/>-Instanz
        /// </summary>
        /// <param name="success"></param>
        /// <param name="value"></param>
        public ParseResult(bool success, T value)
        {
            Success = success;
            Value = value;
        }
    }
}