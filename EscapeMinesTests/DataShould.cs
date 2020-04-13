using DataAccess;
using NUnit.Framework;
using System;
using System.IO;
using System.IO.Abstractions.TestingHelpers;

namespace EscapeMines.Tests
{
    public class DataShould
    {

        [Test]
        public void InvalidPath()
        {
            var mock = new MockFileData("");
            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddFile(@"c:\root\Settings.txt", mock);
            var sutData = new Data(@"c:\Settings.txt", mockFileSystem);
            Assert.Throws<FileNotFoundException>(() => sutData.ReadData());
            
        }

        [Test]
        public void InvalidReadEmpty()
        {
            var mock = new MockFileData("");
            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddFile(@"c:\root\Settings.txt", mock);

            var sutData = new Data(@"c:\root\Settings.txt", mockFileSystem);
            var ex = Assert.Throws<ArgumentNullException>(() => sutData.ReadData());
            Assert.That(ex.ParamName, Is.EqualTo("lines"));
        }

        [Test]
        public void InvalidReadLessThanFour()
        {
            var mock = new MockFileData("line\nline\nline");
            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddFile(@"c:\root\Settings.txt", mock);

            var sutData = new Data(@"c:\root\Settings.txt", mockFileSystem);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sutData.ReadData());
            Assert.That(ex.ParamName, Is.EqualTo("lines"));
        }
    }
}
