using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KataTDD.Lib.StringCalculatorsV2
{
    public class StringExtractor
    {
        public static ExtractResult ExtractSeparatorAndNumbers(string numbers)
        {
            Regex regex = new Regex("//(.*)\n(.*)");
            Match match = regex.Match(numbers);

            return new ExtractResult
            {
                Separators = Enumerable.ToArray(GetCustomSeparators(match.Groups[1].ToString())),
                StringToSplit = match.Groups[2].ToString()
            };
        }

        private static IEnumerable<string> GetCustomSeparators(string symbol)
        {
            if (symbol.Length == 1) return new []{symbol};
            var  matches = Regex.Matches(symbol,@"\[(.*?)\]");
            List<string> customSeparator = new List<string>();
            foreach (Match match in matches)
            {
                customSeparator.Add( match.Groups[1].ToString());
            }

            return customSeparator.ToArray();
        }

        public struct ExtractResult
        {
            public string[] Separators;
            public string StringToSplit;
        }
    }
}