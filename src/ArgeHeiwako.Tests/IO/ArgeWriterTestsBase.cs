using ArgeHeiwako.IO;
using System.Linq;
using Xunit;

namespace ArgeHeiwako.Tests.IO
{
    public abstract class ArgeWriterTestsBase<T>
    {
        private int length;

        public ArgeWriterTestsBase(int length)
        {
            this.length = length;
        }

        public abstract T GetInstance();

        public abstract byte[] GetBytes();

        #region Write()

        [Fact]
        public void Write_SingleInstance_ByteLengthEqualLength()
        {
            var content = GetBytes();
            Assert.Equal(length, content.Length);
        }

        [Fact]
        public void Write_SingleInstance_SecondLastByteEqualCR()
        {
            byte[] content = GetBytes();
            Assert.Equal("\r", OrdnungsbegriffeWriter.WriterEncoding.GetString(content.Skip(length - 2).Take(1).ToArray()));
        }

        [Fact]
        public void Write_SingleInstance_LastByteEqualLF()
        {
            byte[] content = GetBytes();
            Assert.Equal("\n", OrdnungsbegriffeWriter.WriterEncoding.GetString(content.Skip(length - 1).Take(1).ToArray()));
        }

        #endregion
    }
}
