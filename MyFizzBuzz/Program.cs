// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace

using System.Globalization;
using Machine.Specifications;

namespace MyFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [SubjectAttribute(typeof (FizzBuzz), "Number for number")]
    internal class when_given_a_number
    {
        private It will_return_one = () => FizzBuzz.Answer(1).ShouldEqual("1");
        private It will_return_two = () => FizzBuzz.Answer(2).ShouldEqual("2");
    }

    [Subject(typeof (FizzBuzz), "Fizz")]
    internal class when_given_a_number_divisible_by_3
    {
        private It will_return_fizz = () => FizzBuzz.Answer(3).ShouldEqual("Fizz");
    }

    [Subject(typeof (FizzBuzz), "Buzz")]
    internal class when_given_a_number_divisible_by_5
    {
        private It will_return_buzz = () => FizzBuzz.Answer(5).ShouldEqual("Buzz");
    }

    [Subject(typeof (FizzBuzz), "FizzBuzz")]
    internal class when_given_a_number_divisible_by_3_and_5
    {
        private It will_return_fizz_buzz = () => FizzBuzz.Answer(15).ShouldEqual("FizzBuzz");
    }

    internal class FizzBuzz
    {
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
