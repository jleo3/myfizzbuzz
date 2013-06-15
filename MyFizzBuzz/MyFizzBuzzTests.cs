using Machine.Specifications;

// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Local
namespace MyFizzBuzz
{
    [Subject(typeof (FizzBuzz), "Number for number")]
    class when_given_a_number
    {
        It will_return_one = () => FizzBuzz.Answer(1).ShouldEqual("1");
        It will_return_two = () => FizzBuzz.Answer(2).ShouldEqual("2");
    }

    [Subject(typeof (FizzBuzz), "Fizz")]
    class when_given_a_number_divisible_by_3
    {
        It will_return_fizz = () => FizzBuzz.Answer(3).ShouldEqual("Fizz");
    }

    [Subject(typeof (FizzBuzz), "Buzz")]
    class when_given_a_number_divisible_by_5
    {
        It will_return_buzz = () => FizzBuzz.Answer(5).ShouldEqual("Buzz");
    }

    [Subject(typeof (FizzBuzz), "FizzBuzz")]
    class when_given_a_number_divisible_by_3_and_5
    {
        It will_return_fizz_buzz = () => FizzBuzz.Answer(15).ShouldEqual("FizzBuzz");
    }
}
