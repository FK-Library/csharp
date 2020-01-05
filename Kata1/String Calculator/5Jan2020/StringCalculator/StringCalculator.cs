using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata1
{
    public class StringCalculator
    {
        public static List<Char> delimiters = new List<Char> { ',', '\n' };
        public int Add(string numbers)
        {
           

            if (string.IsNullOrEmpty(numbers)) return 0;

            numbers = ParseForNewDelimiter(numbers, delimiters);

            if (!delimiters.Where(
                delimiter => numbers.Count(number => number == delimiter) > 0)
                .Any()
                )
            {
                var input = int.Parse(numbers);
                HandleNegativeInput(input);
                return input; //return single input
            }



            return Sum(numbers, delimiters);
        }

        private static string ParseForNewDelimiter(string numbers, List<char> delimiters)
        { // if we have // in the begining of the 

            if (numbers.Contains("//"))
            {
                delimiters.Add(numbers[2]); //Add new delimiter
                numbers = numbers.Substring(4); // input numbers without delimiter
            }

            return numbers;
        }

        private static int Sum(string numbers, List<char> delimiters)
        {
            var numbersList = new List<int>();
            Array.ForEach(
                numbers.Split(delimiters.ToArray()),
                s =>
                    {
                        var number = int.Parse(s);
                        numbersList.Add(number);
                    }
                );
            HandleNegativeInput(numbersList);
            return numbersList.Sum();
        }

        private static void HandleNegativeInput(int number)
        {
            if (number < 0)
            {
                throw new Exception("negatives not allowed ");
            }
        }

        private static void HandleNegativeInput(List<int> numbers)
        {
            var negativeNumbers = new List<int>();
            var negativesInMessage = "";

            negativeNumbers.AddRange(numbers.Where(n => n < 0));
            if (negativeNumbers !=null && negativeNumbers.Count()>0) //if multiple negatives
            {
                if (negativeNumbers.Count() > 1)
                {
                    foreach (var n in negativeNumbers)
                    {
                        negativesInMessage += n.ToString();
                    }
                }
                throw new Exception($"negatives not allowed {negativesInMessage}");               
            }
        }
    }
}
