using System.Collections.Generic;
using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;

// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace
namespace MyFizzBuzz
{
    class MyFizzBuzzSpec : WithFakes
    {
        protected static IRule FizzBuzzRule;
        protected static IRule FizzRule;
        protected static IRule BuzzRule;
        protected static MyFizzBuzz MyFizzBuzz;

        private Establish context = () =>
            {
                FizzBuzzRule = An<IRule>();
                FizzRule = An<IRule>();
                BuzzRule = An<IRule>();
                MyFizzBuzz = new MyFizzBuzz(FizzBuzzRule, FizzRule, BuzzRule);
            };
    }

    [Subject(typeof (MyFizzBuzz), "Number for number")]
    internal class when_the_rules_return_false : MyFizzBuzzSpec
    {
        private Establish context = () =>
            {
                FizzBuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(false);
                FizzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(false);
                BuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(false);
            };

        private It will_return_one = () => MyFizzBuzz.Answer(1).ShouldEqual("1");
        private It will_return_two = () => MyFizzBuzz.Answer(2).ShouldEqual("2");
    }

    [Subject(typeof (MyFizzBuzz), "Fizz")]
    internal class when_number_satisfies_fizz_rule : MyFizzBuzzSpec
    {
        private Establish context = () => FizzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(true);

        private It will_return_fizz = () => MyFizzBuzz.Answer(3).ShouldEqual("Fizz");
    }

    [Subject(typeof (MyFizzBuzz), "Buzz")]
    internal class when_a_number_satisfies_buzz_rule : MyFizzBuzzSpec
    {
        private Establish context = () => BuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(true);

        private It will_return_buzz = () => MyFizzBuzz.Answer(5).ShouldEqual("Buzz");
    }

    [Subject(typeof (MyFizzBuzz), "MyFizzBuzz")]
    internal class when_a_number_satisfies_fizzbuzz_rule : MyFizzBuzzSpec
    {
        private Establish context = () => FizzBuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(true);

        private It will_return_fizz_buzz = () => MyFizzBuzz.Answer(15).ShouldEqual("FizzBuzz");
    }
}
