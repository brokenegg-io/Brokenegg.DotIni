using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brokenegg.DotIni.Tests
{
    [TestClass]
    public class IniConverterTest
    {
        [TestMethod]
        public void RightFileFormation()
        {
            string test = $@"
                [SECTION]
                test=None
                date=25/02/2021
                number=52
                currency=25.9
                cientific=30x10e40
            ";

            var ini = IniConvert.DeserializeObject(test);
            Assert.IsTrue(ini.Sections.Count > 0);
        }

        [TestMethod]
        public void RightSerialization()
        {
            var ini = new IniFile();
            ini.AddSection("section");
            ini.AddKeyParLastSection("test", "none");
            ini.ToString();
        }
    }
}
