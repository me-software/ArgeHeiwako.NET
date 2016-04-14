using ArgeHeiwako.Data;
using ArgeHeiwako.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArgeHeiwako.Tests.IO
{
    public class AnteilSteuerlicheLeistungsartFileTests : FileTestsBase<AnteilSteuerlicheLeistungsartFile, AnteilSteuerlicheLeistungsart>
    {
        protected override AnteilSteuerlicheLeistungsartFile GetFileInstance()
        {
            return new AnteilSteuerlicheLeistungsartFile(DateTime.Now, new List<AnteilSteuerlicheLeistungsart>());
        }

        #region FileName

        [Fact]
        public void FileName_Get_StartsWithDTE835_()
        {
            var file = GetFileInstance();
            Assert.StartsWith("DTE835305_", file.FileName);
        }

        #endregion
    }
}
