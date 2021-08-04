using Brokenegg.DotIni.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni.Tests
{
    [TestClass]
    public class SectionTests
    {
        [TestMethod]
        /* Check the section with empty name */
        public void InvalidSection()
        {
            Assert.ThrowsException<IniValidationException>(() =>
            {
                IniSection section = new IniSection(string.Empty);
            });
            
        }

        [TestMethod]
        /* Check the section with spaces on the name*/
        public void InvalidSectionWithSpaces()
        {
            Assert.ThrowsException<IniValidationException>(() =>
            {
                IniSection section = new IniSection("name of the section");
            });
        }

        [TestMethod]
        /* Check the section with invalid characters on the name */
        public void InvalidSectionWithChars()
        {
            Assert.ThrowsException<IniValidationException>(() =>
            {
                IniSection section = new IniSection("çãÇÃüÜ");
            });
        }

        [TestMethod]
        /* Check a valid section */
        public void ValidSection()
        {
            var inifile = new FakeObjects.FakeIniFile();
            IniSection section = new IniSection("default");
            inifile.AddSection(section);
            Assert.IsTrue(section.IsValid());
        }

        [TestMethod]
        public void AddingInvalidKey()
        {
            var inifile = new FakeObjects.FakeIniFile();
            inifile.AddSection("default");
            Assert.ThrowsException<Brokenegg.DotIni.Exceptions.KeyNotFoundException>(() => 
            {
                inifile.AddKeyParLastSection(null);
            });            
        }

        [TestMethod]
        public void AddingKeyWithNoSection()
        {
            var inifile = new FakeObjects.FakeIniFile();
            Assert.ThrowsException<SectionNotFoundException>(() =>
            {
                inifile.AddKeyParLastSection("broken", "egg");
            });
        }
    }
}
