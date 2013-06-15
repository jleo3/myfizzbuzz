// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace

using System.Collections.Generic;
using Machine.Specifications;

namespace MyFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class FizzBuzz
    {
        private readonly List<IRule> _rules;

        public FizzBuzz(List<IRule> rules)
        {
            _rules = rules;
        }

        public static string Answer(int number)
        {

            if (number%5 == 0 && number%3 == 0)
                return "FizzBuzz";
            if (number % 5 == 0)
                return "Buzz";
            else if (number %3 == 0)
                return "Fizz";
            else
                return number.ToString();
        }
    }
}
