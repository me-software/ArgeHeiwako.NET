using ArgeHeiwako.IO;
using System;
using Xunit;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ArgeHeiwako.Tests.IO
{
    [ExcludeFromCodeCoverage]
    public class ArgeFileTests
    {
        #region Ctor

        [Fact]
        public void Ctor_SatzartNull_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ArgeFileImpl(DateTime.Now, null));
            Assert.Equal("satzart", ex.ParamName);
        }

        #endregion
    }

    #region ImplClass
    [ExcludeFromCodeCoverage]
    internal class ArgeFileImpl : ArgeFile<int>
    {
        public ArgeFileImpl(DateTime now, string p)
            : base(now, p, new List<int>())
        {
        }
    }
    #endregion
}
