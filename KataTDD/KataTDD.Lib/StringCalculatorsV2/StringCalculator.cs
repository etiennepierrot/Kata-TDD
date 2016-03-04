using System;
using System.Collections.Generic;
using System.Linq;

namespace KataTDD.Lib.StringCalculatorsV2
{
    public class StringCalculator
    {
        private readonly ILogger _logger;
        private readonly IWebService _webService;

        private const string DefaultSeparator = ",";
        private const string NewLine = "\n";
        private const string CustomSepatoratorConfig = "//";

        public StringCalculator(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int Add(string numbers)
        {
            if (numbers == string.Empty) return 0;

            var tokens = IsCustomSeparatorConfigured(numbers)
                ? TokenizeWithCustomSeparator(numbers)
                : TokenWithDefaultSeparator(numbers);

            int[] intNumbers = GetNumbers(tokens);

            int sum = intNumbers.Sum();
            LogSum(sum);
            return sum;
        }

        private void LogSum(int sum)
        {
            try
            {
                _logger.Write(sum.ToString());
            }
            catch (Exception)
            {
                _webService.Notify("logger fail");
            }
        }

        private string[] TokenWithDefaultSeparator(string numbers)
        {
            return numbers.Split(new[] {DefaultSeparator, NewLine}, StringSplitOptions.None);
        }

        private int[] GetNumbers(string[] tokens)
        {
            int[] intNumbers = tokens.Select(int.Parse).ToArray();
            CheckNegativeNumbers(intNumbers);
            return FilterAbove1000(intNumbers).ToArray();
        }

        private IEnumerable<int> FilterAbove1000(int[] intNumbers)
        {
            return intNumbers.Where(n => n <= 1000);
        }

        private void CheckNegativeNumbers(int[] intNumbers)
        {
            if (!intNumbers.Any(n => n < 0)) return;
            string message = intNumbers
                .Where(n => n < 0)
                .Aggregate("negatives not allowed", (current, intNumber) => current + (" " + intNumber));

            throw new NegativeNotAllowedException(message);
        }

        private string[] TokenizeWithCustomSeparator(string numbers)
        {
            StringExtractor.ExtractResult extractResult = StringExtractor.ExtractSeparatorAndNumbers(numbers);
            string stringToTokenize = extractResult.StringToSplit;
            string[] separators = AddNewLine(extractResult.Separators);
            return stringToTokenize.Split(separators, StringSplitOptions.None);
        }

        private string[] AddNewLine(string[] separator)
        {
            List<string> separators = separator.ToList();
            separators.Add(NewLine);
            return separators.ToArray();
        }


        private bool IsCustomSeparatorConfigured(string numbers)
        {
            return numbers.StartsWith(CustomSepatoratorConfig);
        }
    }
}