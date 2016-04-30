using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    [ExcludeFromCodeCoverage]
    public class DokumentartTests
    {
        [Fact]
        public void Heizkostenabrechnung_ToString_ReturnsHKA()
        {
            Assert.Equal("HKA", Dokumentart.Heizkostenabrechnung.ToString());
        }

        [Fact]
        public void Betriebskostenabrechnung_ToString_ReturnsBKA()
        {
            Assert.Equal("BKA", Dokumentart.Betriebskostenabrechnung.ToString());
        }

        [Fact]
        public void Verbrauchsdatenanalyse_ToString_ReturnsVDA()
        {
            Assert.Equal("VDA", Dokumentart.Verbrauchsdatenanalyse.ToString());
        }

        #region explicit_Operator Dokumentart_string

        [Fact]
        public void expOperator_StringHKA_ReturnsHeizkostenabrechnung()
        {
            Assert.Equal(Dokumentart.Heizkostenabrechnung, (Dokumentart)"HKA");
        }

        [Fact]
        public void expOperator_StringBKA_ReturnsBetriebskostenabrechnung()
        {
            Assert.Equal(Dokumentart.Betriebskostenabrechnung, (Dokumentart)"BKA");
        }

        [Fact]
        public void expOperator_StringVDA_ReturnsVerbrauchsdatenanalyse()
        {
            Assert.Equal(Dokumentart.Verbrauchsdatenanalyse, (Dokumentart)"VDA");
        }

        [Fact]
        public void expOperator_StringSome_ThrowsInvalidCastException()
        {
            var ex = Assert.Throws<InvalidCastException>(() => (Dokumentart)"Some");
        }

        #endregion
    }
}
