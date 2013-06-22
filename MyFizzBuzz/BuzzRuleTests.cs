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

        Establish context = () => FizzBuzzRule = An<IRule>();
    }

    [Subject("Traditional FizzBuzz rules")]
    class ModuloExpSetup : BuzzRuleSpec
    {
        protected static string ModuloBuzzExp = "x % 5 = 0";
 
        Establish context = () => BuzzRule = new BuzzRule(FizzBuzzRule, ModuloBuzzExp);
         
    }

    class when_given_a_satisfying_condition : BuzzRuleSpec
    {
        It will_return_true = () => BuzzRule.Evaluate(5).ShouldBeTrue();
    }

    class when_given_an_unsatisfactory_condition : BuzzRuleSpec
    {
        It will_return_false = () => BuzzRule.Evaluate(2).ShouldBeFalse();
    }


    [Subject("Square Expression")]
    class SquareExpSetup : BuzzRuleSpec
    {
        protected static string SquareBuzzExp = "x * x % 3 = 0";
 
        Establish context = () => BuzzRule = new BuzzRule(FizzBuzzRule, SquareBuzzExp);
        
    }

    class when_given_a_satisfying_square_condition : SquareExpSetup
    {
        It will_return_true = () => BuzzRule.Evaluate(9).ShouldBeTrue();
    }

    class when_given_an_unsatisfying_square_condition : SquareExpSetup
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

    [Subject(typeof (BuzzRule), "Invalid Expression")]
    class when_evaluating_an_invalid_expression : BuzzRuleSpec
    {
        protected static string ModuloBuzzExp = "x BLARGH 5 = 0";
 
        Establish context = () => BuzzRule = new BuzzRule(FizzBuzzRule, ModuloBuzzExp);

        private It will_return_faluse = () => BuzzRule.Evaluate(11).ShouldBeFalse();
    }
}
