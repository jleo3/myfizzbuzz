using Machine.Specifications;

#region ResharperDisable

// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Local

#endregion
namespace MyFizzBuzz.FizzBuzzRuleTests
{
    class FizzBuzzRuleSpec
    {
        protected static FizzBuzzRule FizzBuzzRule;

        Establish context = () =>
            {
                FizzBuzzRule = new FizzBuzzRule();
            };
    }

    [Subject(typeof (FizzBuzzRule), "Satisfying Condition For FizzBuzz")]
    class when_given_a_satisfying_condition : FizzBuzzRuleSpec
    {
        It will_return_true = () => FizzBuzzRule.Evaluate(15).ShouldBeTrue();
    }

    [Subject(typeof (FizzBuzzRule), "Unsatisfying condition for FizzBuzz")]
    class when_given_an_unsatisfactory_condition : FizzBuzzRuleSpec
    {
        It will_return_false = () => FizzBuzzRule.Evaluate(9).ShouldBeFalse();
    }
}
