using System.Collections.Generic;
using Machine.Fakes;
using Machine.Specifications;

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
        protected static List<string> Expressions = new List<string>();

        Cleanup after = () => Expressions.Clear();
    }

    [Subject("Traditional FizzBuzz rules")]
    class ModuloExpSetup : BuzzRuleSpec
    {
        Establish context = () =>
            {
                Expressions.Add("x % 5 = 0");
                BuzzRule = new BuzzRule(Expressions);
            };
    }

    class when_given_a_satisfying_condition : ModuloExpSetup
    {
        It will_return_true = () => BuzzRule.Evaluate(5).ShouldBeTrue();
    }

    class when_given_an_unsatisfactory_condition : ModuloExpSetup
    {
        It will_return_false = () => BuzzRule.Evaluate(2).ShouldBeFalse();
    }

    [Subject("Square Expression")]
    class SquareExpSetup : BuzzRuleSpec
    {
        Establish context = () =>
            {
                Expressions.Add("x * x % 3 = 0");
                BuzzRule = new BuzzRule(Expressions);
            };
    }

    class when_given_a_satisfying_square_condition : SquareExpSetup
    {
        It will_return_true = () => BuzzRule.Evaluate(9).ShouldBeTrue();
    }

    class when_given_an_unsatisfying_square_condition : SquareExpSetup
    {
        It will_return_false = () => BuzzRule.Evaluate(2).ShouldBeFalse();
    }

    [Subject("Satisfies two rules")]
    class when_satisfactory_condition_conflicts_with_fizz_buzz : BuzzRuleSpec
    {
        Establish context = () =>
            {
                Expressions = new List<string> { "x % 2 = 0", "x % 5 = 0" };
                BuzzRule = new BuzzRule(Expressions);
            };

        It will_return_false = () => BuzzRule.Evaluate(15).ShouldBeFalse();
    }

    [Subject(typeof (BuzzRule), "Invalid Expression")]
    class when_evaluating_an_invalid_expression : BuzzRuleSpec
    {
        Establish context = () =>
            {
                Expressions.Add("x BLARGH 3 = 0");
                BuzzRule = new BuzzRule(Expressions);
            };

        private It will_return_faluse = () => BuzzRule.Evaluate(11).ShouldBeFalse();
    }
}
