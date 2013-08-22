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
    class RuleSpec : WithFakes
    {
        protected static Rule Rule;
        protected static List<string> Expressions = new List<string>();

        Cleanup after = () => Expressions.Clear();
    }

    [Subject("Traditional FizzBuzz rules")]
    class ModuloExpSetup : RuleSpec
    {
        Establish context = () =>
            {
                Expressions.Add("x % 5 = 0");
                Rule = new Rule(Expressions);
            };
    }

    class when_given_a_satisfying_condition : ModuloExpSetup
    {
        It will_return_true = () => Rule.Evaluate(5).ShouldBeTrue();
    }

    class when_given_an_unsatisfactory_condition : ModuloExpSetup
    {
        It will_return_false = () => Rule.Evaluate(2).ShouldBeFalse();
    }

    [Subject("Square Expression")]
    class SquareExpSetup : RuleSpec
    {
        Establish context = () =>
            {
                Expressions.Add("x * x % 3 = 0");
                Rule = new Rule(Expressions);
            };
    }

    class when_given_a_satisfying_square_condition : SquareExpSetup
    {
        It will_return_true = () => Rule.Evaluate(9).ShouldBeTrue();
    }

    class when_given_an_unsatisfying_square_condition : SquareExpSetup
    {
        It will_return_false = () => Rule.Evaluate(2).ShouldBeFalse();
    }

    [Subject("Satisfies two rules")]
    class when_two_rules_are_given : RuleSpec
    {
        Establish context = () =>
            {
                Expressions = new List<string> { "x % 2 = 0", "x % 5 = 0" };
                Rule = new Rule(Expressions);
            };

        It will_return_false = () => Rule.Evaluate(15).ShouldBeFalse();
    }

    [Subject(typeof (Rule), "Invalid Expression")]
    class when_evaluating_an_invalid_expression : RuleSpec
    {
        Establish context = () =>
            {
                Expressions.Add("x BLARGH 3 = 0");
                Rule = new Rule(Expressions);
            };

        private It will_return_faluse = () => Rule.Evaluate(11).ShouldBeFalse();
    }

  
    class when_poking_tiger_with_stick : RuleSpec
    {
        Behaves_like<when_evaluating_an_invalid_expression> foobar;
        It should_look_very_mean;
     
    }
}
