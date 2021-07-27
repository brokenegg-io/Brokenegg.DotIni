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
        /// <summary>
        /// Convert a string to List based on the new line character \n
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check if the line is a key-par value
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static bool IsKeyPar(string line) => RegexExpressions.IsKeyPar(line);
        
        /// <summary>
        /// Convert a ini key-par value to IniKey
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static IniKey StripeKeyPar(string line)
        {
            var content = RegexExpressions.StripeAnything(line, RegexExpressions.KeyParRegex, new List<int>() { 1, 3 });
            return content.Any() ? new IniKey(content.FirstOrDefault(), new IniValue(content[1])) : null;
        }

        /// <summary>
        /// Check if the line is a section
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static bool IsSection(string line) => RegexExpressions.IsSection(line);

        /// <summary>
        /// Convert a ini section to IniSection
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static IniSection StripeSection(string line)
        {
            return new IniSection(RegexExpressions.StripeAnything(line, RegexExpressions.SectionRegex, new List<int>() { 2 }).FirstOrDefault());
        }

        public static string ToStringSection(string name) => $@"[{name}]";
        public static string ToStringKeyPar(string name, string value) => $@"{name}={value}";
    }
}
