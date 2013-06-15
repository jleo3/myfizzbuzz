using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;

#region ResharperDisable

// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Local

#endregion
namespace MyFizzBuzz
{
    class MyFizzBuzzSpec : WithFakes
    {
        protected static IRule FizzBuzzRule;
        protected static IRule FizzRule;
        protected static IRule BuzzRule;
        protected static MyFizzBuzz MyFizzBuzz;

        Establish context = () =>
            {
                FizzBuzzRule = An<IRule>();
                FizzRule = An<IRule>();
                BuzzRule = An<IRule>();
                MyFizzBuzz = new MyFizzBuzz(FizzBuzzRule, FizzRule, BuzzRule);
            };
    }

    [Subject(typeof (MyFizzBuzz), "Number for number")]
    class when_the_rules_return_false : MyFizzBuzzSpec
    {
        Establish context = () =>
            {
                FizzBuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(false);
                FizzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(false);
                BuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(false);
            };

        It will_return_one = () => MyFizzBuzz.Answer(1).ShouldEqual("1");
        It will_return_two = () => MyFizzBuzz.Answer(2).ShouldEqual("2");
    }

    [Subject(typeof (MyFizzBuzz), "Fizz")]
    class when_number_satisfies_fizz_rule : MyFizzBuzzSpec
    {
        Establish context = () => FizzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(true);

        It will_return_fizz = () => MyFizzBuzz.Answer(3).ShouldEqual("Fizz");
    }

    [Subject(typeof (MyFizzBuzz), "Buzz")]
    class when_a_number_satisfies_buzz_rule : MyFizzBuzzSpec
    {
        Establish context = () => BuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(true);

        It will_return_buzz = () => MyFizzBuzz.Answer(5).ShouldEqual("Buzz");
    }

    [Subject(typeof (MyFizzBuzz), "MyFizzBuzz")]
    class when_a_number_satisfies_fizzbuzz_rule : MyFizzBuzzSpec
    {
        Establish context = () => FizzBuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(true);

        It will_return_fizz_buzz = () => MyFizzBuzz.Answer(15).ShouldEqual("FizzBuzz");
    }
}
