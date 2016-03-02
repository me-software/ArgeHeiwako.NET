using ArgeHeiwako.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class AbrechnungsunternehmenTests
    {
        #region Ctor

        [Fact]
        public void Ctor_NumberName_CreatesInstance()
        {
            var instance = new Abrechnungsunternehmen(10, "Name");
            Assert.NotNull(instance);
        }

        [Fact]
        public void Ctor_NumberName_NummerEqual10()
        {
            var instance = new Abrechnungsunternehmen(10, "Name");
            Assert.Equal(10, instance.Nummer);
        }

        [Fact]
        public void Ctor_NumberName_NameEqualName()
        {
            var instance = new Abrechnungsunternehmen(10, "Name");
            Assert.Equal("Name", instance.Name);
        }

        #endregion

        #region Find()

        [Fact]
        public void Find_0_ThrowsKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() => Abrechnungsunternehmen.Find(0));
        }

        [Fact]
        public void Find_30_ReturnsTechem()
        {
            Assert.StartsWith("Techem", Abrechnungsunternehmen.Find(30).Name);
        }

        #endregion
        
        #region ToString()

        [Fact]
        public void ToString_Nummer10NameTest_Equal10()
        {
            var unternehmen = new Abrechnungsunternehmen(10, "Test");
            Assert.Equal("10", unternehmen.ToString());
        }

        [Fact]
        public void ToString_Nummer1NameTest_Equal01()
        {
            var unternehmen = new Abrechnungsunternehmen(1, "Test");
            Assert.Equal("01", unternehmen.ToString());
        }

        #endregion

        #region FromString()

        [Fact]
        public void FromString_Null_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Abrechnungsunternehmen.FromString(null));
            Assert.Equal("abrechnungsunternehmen", ex.ParamName);
        }

        [Fact]
        public void FromString_StringEmpty_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Abrechnungsunternehmen.FromString(string.Empty));
            Assert.Equal("abrechnungsunternehmen", ex.ParamName);
            Assert.StartsWith("Eine valide Kennung besteht aus 2 numerischen Zeichen.", ex.Message);
        }

        [Fact]
        public void FromString_String1Char_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Abrechnungsunternehmen.FromString(" "));
            Assert.Equal("abrechnungsunternehmen", ex.ParamName);
            Assert.StartsWith("Eine valide Kennung besteht aus 2 numerischen Zeichen.", ex.Message);
        }

        [Fact]
        public void FromString_String2Space_ThrowsArgumentException()
        {
            Assert.Null(Abrechnungsunternehmen.FromString("  "));
        }

        [Fact]
        public void FromString_ZeroZero_ThrowsKeyNotFoundException()
        {
            var ex = Assert.Throws<KeyNotFoundException>(() => Abrechnungsunternehmen.FromString("00"));
        }

        [Fact]
        public void FromString_30_ReturnsTechem()
        {
            Assert.Equal(Abrechnungsunternehmen.Find(30).ToString(), Abrechnungsunternehmen.FromString("30").ToString());
        }

        #endregion
    }
}
