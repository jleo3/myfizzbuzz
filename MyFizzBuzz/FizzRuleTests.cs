// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace

using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;

namespace MyFizzBuzz
{
    class FizzRuleSpec : WithFakes

    {
        protected static FizzRule FizzRule;
        protected static IRule FizzBuzzRule;

        private Establish context = () =>
            {
                FizzBuzzRule = An<IRule>();
                FizzRule = new FizzRule(FizzBuzzRule);
            };
    }

    [Subject(typeof (FizzRule), "Satisfying Condition For Fizz")]
    internal class when_given_a_satisfying_condition : FizzRuleSpec
    {
        private It will_return_true = () => FizzRule.Evaluate(3).ShouldBeTrue();
    }

    [Subject(typeof (FizzRule), "Unsatisfying condition for fizz")]
    internal class when_given_an_unsatisfactory_condition : FizzRuleSpec
    {
        private It will_return_false = () => FizzRule.Evaluate(2).ShouldBeFalse();
    }

    [Subject(typeof (FizzRule), "Conflicts with FizzBuzz rule")]
    internal class when_satisfactory_condition_conflicts_with_fizz_buzz : FizzRuleSpec
    {
        private Establish context = () =>
            {
                FizzBuzzRule.WhenToldTo(x => x.Evaluate(Arg<int>.Is.Anything)).Return(true);
                FizzRule = new FizzRule(FizzBuzzRule);
            };

        private It will_return_false = () => FizzRule.Evaluate(15).ShouldBeFalse();
    }
}
