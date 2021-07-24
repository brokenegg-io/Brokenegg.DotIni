﻿using Brokenegg.DotIni.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni
{
    public class IniConvert
    {
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

        public static string SerializeObject(IniFile iniFile)
        {
            var ini = new StringBuilder();
            iniFile.Sections.ForEach(s =>
            {
                ini.Append(s.ToIniString());
                s.Keys.ForEach(k =>
                {
                    ini.Append(k.ToIniString());
                });
            });

            return ini.ToString();
        }
    }
}
