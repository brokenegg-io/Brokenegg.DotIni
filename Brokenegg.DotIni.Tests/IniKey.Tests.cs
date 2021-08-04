using Brokenegg.DotIni.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni.Tests
{
    [TestClass]
    public class IniKeyTests
    {
        [TestMethod]
        /* Check the section with empty name */
        public void InvalidSection()
        {
            Assert.ThrowsException<IniValidationException>(() =>
            {
                IniKey section = new IniKey(string.Empty, string.Empty);
            });

        }
    }
}
