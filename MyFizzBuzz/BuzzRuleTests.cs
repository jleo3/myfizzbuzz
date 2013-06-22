using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;

#region ResharperDisable
// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Local
#endregion
namespace MyFizzBuzz.BuzzRuleTests
{
    class BuzzRuleSpec : WithFakes

    {
        protected static BuzzRule BuzzRule;
        protected static IRule FizzBuzzRule;

        Establish context = () =>
            {
                FizzBuzzRule = An<IRule>();
                BuzzRule = new BuzzRule(FizzBuzzRule, "x % 5 = 0");
            };
    }

    [Subject(typeof (BuzzRule), "Square rule")]
    class when_given_a_satisfying_square_condition : WithFakes
    {
        protected static BuzzRule BuzzRule;
        protected static string BuzzExpression = "x * x % 3 = 0";
        protected static IRule FizzBuzzRule;

        Establish context = () =>
            {
                FizzBuzzRule = An<IRule>();
                BuzzRule = new BuzzRule(FizzBuzzRule, BuzzExpression);
            };
        It will_return_true = () => BuzzRule.Evaluate(9).ShouldBeTrue();
    }

    [Subject(typeof (BuzzRule), "Satisfying Condition For Buzz")]
    class when_given_a_satisfying_condition : BuzzRuleSpec
    {
        It will_return_true = () => BuzzRule.Evaluate(5).ShouldBeTrue();
    }

    [Subject(typeof (BuzzRule), "Unsatisfying condition for fizz")]
    class when_given_an_unsatisfactory_condition : BuzzRuleSpec
    {
        It will_return_false = () => BuzzRule.Evaluate(2).ShouldBeFalse();
    }

    [Subject(typeof (BuzzRule), "Conflicts with BuzzBuzz rule")]
    class when_satisfactory_condition_conflicts_with_fizz_buzz : BuzzRuleSpec
    {
        Establish context = () =>
            {
                FizzBuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(true);
                BuzzRule = new BuzzRule(FizzBuzzRule, "x % 5 = 0");
            };

        It will_return_false = () => BuzzRule.Evaluate(15).ShouldBeFalse();
    }
}
