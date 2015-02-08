using System;
using System.Collections.Generic;
using System.Linq;

namespace KataTDD.Lib.StringCalculators
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            CheckValidInput(numbers);

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<char> listSeparator = GetListSeparator(numbers);

            string[] splittedNumber = numbers.Split(listSeparator.ToArray());

            return splittedNumber.Sum(strNumber => IntParser(strNumber));
        }

        private static List<char> GetListSeparator(string numbers)
        {
            char firstChar = numbers[0];

            bool isDigit = Char.IsDigit(firstChar);

            List<char> listSeparator = new List<char> {',', '\n'};

            if (!isDigit)
            {
                listSeparator.Add(firstChar);
            }
            return listSeparator;
        }


        private int IntParser(string strNumber)
        {

            if (string.IsNullOrEmpty(strNumber))
            {
                return 0;
            }
            else
            {
                var intParser = int.Parse(strNumber);
                if (intParser < 0)
                {
                    throw new NegativesNotAllowedException();
                }
                return intParser;
            }
        }

        private void CheckValidInput(string numbers)
        {
            if (numbers == null) throw new ArgumentNullException("numbers");
            if (numbers.Contains("\n,"))
            {
                throw new ArgumentException();
            }
        }
    }
}