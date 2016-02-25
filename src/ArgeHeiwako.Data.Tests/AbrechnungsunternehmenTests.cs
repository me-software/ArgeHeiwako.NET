using System.Collections.Generic;
using Xunit;

namespace ArgeHeiwako.Data.Tests
{
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
    }
}
