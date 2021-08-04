using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Brokenegg.DotIni.Settings
{
    public class RegexExpressions
    {
        public static string SectionRegex { get { return @"(\[)([a-zA-Z]{0,})(\])"; } }
        public static string KeyParRegex { get { return @"([a-zA-Z]{0,})(=)(.{0,})"; } }

        public static bool IsKeyPar(string line) => Regex.IsMatch(line, KeyParRegex);
        public static bool IsSection(string line) => Regex.IsMatch(line, SectionRegex);

        public static List<string> StripeAnything(string line, string pattern, List<Int32> positions)
        {
            var match = Regex.Matches(line.Trim(), pattern)?.FirstOrDefault();

            if (match == null) return new List<string>();

            var groups = new Dictionary<int, Group>();

            for (int i = 0; i < match.Groups.Count; i++) groups.Add(groups.Count(), match.Groups[i]);

            var test = groups.Where(p => positions.Contains(p.Key)).ToList();
            return test.Select(p => p.Value.Value.ToString()).ToList();
        }

        public static bool OnlyLetters(string value) =>   Regex.IsMatch(value, @"^[a-zA-Z]+$");
    }
}
