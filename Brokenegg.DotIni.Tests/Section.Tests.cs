using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni.Tests
{
    [TestClass]
    public class Section
    {


        [TestMethod]
        public void InvalidSection()
        {
            var inifile = new FakeObjects.FakeIniFile();
            IniSection section = new IniSection(string.Empty);
            inifile.AddSection(section);
            Assert.IsFalse(section.IsValid());
        }

        [TestMethod]
        public void InvalidSectionWithSpaces()
        {
            var inifile = new FakeObjects.FakeIniFile();
            IniSection section = new IniSection("name of the section");
            inifile.AddSection(section);
            Assert.IsFalse(section.IsValid());
        }

        [TestMethod]
        public void InvalidSectionWithChars()
        {
            var inifile = new FakeObjects.FakeIniFile();
            IniSection section = new IniSection("çãÇÃüÜ");
            inifile.AddSection(section);
            Assert.IsFalse(section.IsValid());
        }

        public void ValidSection()
        {
            var inifile = new FakeObjects.FakeIniFile();
            IniSection section = new IniSection("default");
            inifile.AddSection(section);
            Assert.IsFalse(section.IsValid());
        }
    }
}
