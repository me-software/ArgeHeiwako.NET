using ArgeHeiwako.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgeHeiwako.Tests.Data.Common
{
    public class BetragTests
    {
        public BetragTests()
        {
        }

        #region Ctor

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Betrag(null));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_EmptyString_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Betrag(string.Empty));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringLength9_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Betrag(new string('0', 9)));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_StringLength11_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Betrag(new string('0', 11)));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_Number10000000Dot01_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Betrag(100000000.01M));
            Assert.Equal("betrag", ex.ParamName);
        }

        [Fact]
        public void Ctor_Number0_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Betrag(-10000000.00M));
            Assert.Equal("betrag", ex.ParamName);
        }

        #endregion

        #region ToString()
        #endregion

    }
}
