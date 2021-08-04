using Brokenegg.DotIni.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Brokenegg.DotIni.Tests
{
    [TestClass]
    public class IniFileTests
    {
        [TestMethod]
        public void ReadRightFile()
        {
            var iniFile = IniFile.GetFromFile(FileUtils.ToCurrentLocation("TEST.ini"));
            Assert.IsTrue(iniFile.IsValid());
        }

        [TestMethod]
        public void ReadWrongFile()
        {
            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                IniFile.GetFromFile(@".\TEST_WRONG.ini");
            });
        }
    }
}
