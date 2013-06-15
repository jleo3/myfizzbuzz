using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;

// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace
namespace MyFizzBuzz.BuzzRuleTests
{
    class BuzzRuleSpec : WithFakes

    {
        protected static BuzzRule BuzzRule;
        protected static IRule FizzBuzzRule;

        private Establish context = () =>
            {
                FizzBuzzRule = An<IRule>();
                BuzzRule = new BuzzRule(FizzBuzzRule);
            };
    }

    [Subject(typeof (BuzzRule), "Satisfying Condition For Buzz")]
    internal class when_given_a_satisfying_condition : BuzzRuleSpec
    {
        private It will_return_true = () => BuzzRule.Evaluate(5).ShouldBeTrue();
    }

    [Subject(typeof (BuzzRule), "Unsatisfying condition for fizz")]
    internal class when_given_an_unsatisfactory_condition : BuzzRuleSpec
    {
        private It will_return_false = () => BuzzRule.Evaluate(2).ShouldBeFalse();
    }

    [Subject(typeof (BuzzRule), "Conflicts with BuzzBuzz rule")]
    internal class when_satisfactory_condition_conflicts_with_fizz_buzz : BuzzRuleSpec
    {
        private Establish context = () =>
            {
                FizzBuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(true);
                BuzzRule = new BuzzRule(FizzBuzzRule);
            };

        private It will_return_false = () => BuzzRule.Evaluate(15).ShouldBeFalse();
    }
    class BuzzRuleTests
    {
    }
}
