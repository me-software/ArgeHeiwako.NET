using ArgeHeiwako.IO;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Xunit;

namespace ArgeHeiwako.Tests.IO
{
    [ExcludeFromCodeCoverage]
    public abstract class ArgeWriterTestsBase<TData, TWriter> where TWriter : IArgeWriter<TData>
    {
        private int length;

        public ArgeWriterTestsBase(int length)
        {
            this.length = length + 2;
        }

        public abstract string GetWriterName();

        public abstract TData GetInstance();

        public abstract TWriter GetWriter(Stream stream);

        public abstract void BuildBytes(Stream stream);

        protected byte[] GetBytes()
        {
            byte[] content = null;
            using (var stream = new MemoryStream())
            {
                BuildBytes(stream);
                stream.Flush();
                content = stream.ToArray();
            }

            return content;
        }

        #region Write()

        [Fact]
        public void Write_WritesSingleInstance_EqualsStringRepresentation()
        {
            byte[] content = GetBytes();
            using (var stream = new MemoryStream(content))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    Assert.Equal(GetInstance().ToString(), streamReader.ReadLine());
                    Assert.True(streamReader.EndOfStream);
                }
            }
        }

        [Fact]
        public void Write_AfterDispose_ThrowsObjectDisposedException()
        {
            using (var stream = new MemoryStream())
            {
                var writer = GetWriter(stream);
                writer.Dispose();

                var ex = Assert.Throws<ObjectDisposedException>(() => writer.Write(GetInstance()));
                Assert.Equal(GetWriterName(), ex.ObjectName);
            }
        }

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
