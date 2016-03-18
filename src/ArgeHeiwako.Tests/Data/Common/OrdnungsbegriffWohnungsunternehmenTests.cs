using ArgeHeiwako.Data.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class OrdnungsbegriffWohnungsunternehmenTests
    {
        #region Ctor

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OrdnungsbegriffWohnungsunternehmen(null));
        }

        [Fact]
        public void Ctor_StringLengthMoreThan20_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new OrdnungsbegriffWohnungsunternehmen(new string(' ', 21)));
        }

        [Fact]
        public void Ctor_TestString_ToStringLength20()
        {
            var ordnungsbegriff = new OrdnungsbegriffWohnungsunternehmen("TestString");
            Assert.Equal(20, ordnungsbegriff.ToString().Length);
        }

        [Fact]
        public void Ctor_TestString_ToStringEqualTestString10Spaces()
        {
            var ordnungsbegriff = new OrdnungsbegriffWohnungsunternehmen("TestString");
            Assert.Equal("TestString          ", ordnungsbegriff.ToString());
        }

        #endregion
    }
}
