using Brokenegg.DotIni.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Brokenegg.DotIni.Utils
{
    public class IniUtils
    {
        public static List<string> StringToList(string text)
        {
            var context = new List<string>();
            using var stringReader = new StringReader(text);
            string line = string.Empty;

            while ((line = stringReader.ReadLine()) != null) context.Add(line.Trim());
            return context;
        }

        public static Type FindMyType(object value)
        {
            return typeof(string);
        }

        public static bool IsKeyPar(string line) => RegexExpressions.IsKeyPar(line);

        public static IniKey StripeKeyPar(string line)
        {
            var content = RegexExpressions.StripeAnything(line, RegexExpressions.KeyParRegex, new List<int>() { 1, 3 });
            return content.Any() ? new IniKey(content.FirstOrDefault(), new IniValue(content[1])) : null;
        }

        public static bool IsSection(string line) => RegexExpressions.IsSection(line);

        public static IniSection StripeSection(string line)
        {
            return new IniSection(RegexExpressions.StripeAnything(line, RegexExpressions.SectionRegex, new List<int>() { 2 }).FirstOrDefault());
        }
    }
}
