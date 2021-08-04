using Brokenegg.DotIni.Exceptions;
using Brokenegg.DotIni.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni
{
    public class IniConvert
    {
        /// <summary>
        /// Deserialize object to IniFile
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IniFile DeserializeObject(string text)
        {
            List<string> lines = IniUtils.StringToList(text);

            var ini = new IniFile();
            lines.ForEach(p =>
            {
                if (IniUtils.IsKeyPar(p) && !ini.HasSection()) ini.AddDefaultSection();
                if (IniUtils.IsKeyPar(p)) ini.AddKeyParLastSection(IniUtils.StripeKeyPar(p));
                if (IniUtils.IsSection(p)) ini.AddSection(IniUtils.StripeSection(p));
            });
            return ini;
        }
        /// <summary>
        /// SerializeObject
        /// </summary>
        /// <param name="iniFile"></param>
        /// <returns></returns>
        public static string SerializeObject(IniFile iniFile) => iniFile.ToString();
    }
}
