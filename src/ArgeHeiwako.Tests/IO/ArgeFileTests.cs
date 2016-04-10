using ArgeHeiwako.IO;
using System;
using Xunit;

namespace ArgeHeiwako.Tests.IO
{
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
    internal class ArgeFileImpl : ArgeFile
    {
        public ArgeFileImpl(DateTime now, string p)
            : base(now, p)
        {
        }
    }
    #endregion
}
