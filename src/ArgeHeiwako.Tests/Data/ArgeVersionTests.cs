using ArgeHeiwako.Data;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ArgeHeiwako.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class ArgeVersionTests
    {
        [Fact]
        public void CtorNone_ToString_ReturnsDefaultVersion03p05()
        {
            var argeVersion = new ArgeVersion();
            Assert.Equal("03.05", argeVersion.ToString());
        }

        [Fact]
        public void Ctor_EmptyVersionString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ArgeVersion(string.Empty));
        }

        [Fact]
        public void Ctor_VersionString03p04_ToString_ReturnsDefaultVersion()
        {
            var argeVersion = new ArgeVersion("03.04");
            Assert.Equal("03.04", argeVersion.ToString());
        }

        [Fact]
        public void Ctor_VersionString99p99_ToString_ReturnsDefaultVersion()
        {
            var argeVersion = new ArgeVersion("99.99");
            Assert.Equal("99.99", argeVersion.ToString());
        }

        [Fact]
        public void Ctor_VersionString3p04_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ArgeVersion("3.04"));
        }
    }
}
