using ArgeHeiwako.IO;
using System;
using Xunit;

namespace ArgeHeiwako.Tests.IO
{
    public class OrdnungsbegriffeFileTests
    {
        #region Ctor

        [Fact]
        public void Ctor_DateTime_CreatedEqualsDateTime()
        {
            var dateTime = DateTime.Now;
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(dateTime);
            Assert.Equal(dateTime, ordnungsbegriffeFile.Created);
        }

        #endregion

        #region FileName

        [Fact]
        public void FileName_StartsWithDTA305()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(DateTime.Now);
            Assert.StartsWith("DTA305_", ordnungsbegriffeFile.FileName);
        }

        [Fact]
        public void FileName_ExtensionDotDAT()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(DateTime.Now);
            Assert.EndsWith(".DAT", ordnungsbegriffeFile.FileName);
        }

        [Fact]
        public void FileName_LengthEqual25()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(DateTime.Now);
            Assert.Equal(25, ordnungsbegriffeFile.FileName.Length);
        }

        [Fact]
        public void FileName_DatePartEqual20150101()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(new DateTime(2015, 1, 1));
            Assert.Equal("20150101", ordnungsbegriffeFile.FileName.Substring(7, 8));
        }

        [Fact]
        public void FileName_TimePartEqual161510()
        {
            var ordnungsbegriffeFile = new OrdnungsbegriffeFile(new DateTime(2015, 1, 1, 16, 15, 10));
            Assert.Equal("161510", ordnungsbegriffeFile.FileName.Substring(15, 6));
        }

        #endregion
    }
}
