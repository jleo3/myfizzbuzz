// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace

using Machine.Specifications;

namespace MyFizzBuzz.FizzBuzzRuleTests
{
    class FizzBuzzRuleSpec
    {
        protected static FizzBuzzRule FizzBuzzRule;

        private Establish context = () =>
            {
                FizzBuzzRule = new FizzBuzzRule();
            };
    }

    [Subject(typeof (FizzBuzzRule), "Satisfying Condition For FizzBuzz")]
    internal class when_given_a_satisfying_condition : FizzBuzzRuleSpec
    {
        private It will_return_true = () => FizzBuzzRule.Evaluate(15).ShouldBeTrue();
    }

    [Subject(typeof (FizzBuzzRule), "Unsatisfying condition for FizzBuzz")]
    internal class when_given_an_unsatisfactory_condition : FizzBuzzRuleSpec
    {
        private It will_return_false = () => FizzBuzzRule.Evaluate(9).ShouldBeFalse();
    }
}
