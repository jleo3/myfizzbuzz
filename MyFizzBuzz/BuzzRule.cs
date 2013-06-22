using System;
using Ciloci.Flee;
namespace MyFizzBuzz
{
    public class BuzzRule : IRule
    {
        private readonly IRule _fizzBuzzRule;

        public BuzzRule(IRule fizzBuzzRule)
        {
            _fizzBuzzRule = fizzBuzzRule;
        }

        public bool Evaluate(int i)
        {
            if (_fizzBuzzRule.Evaluate(i)) return false;
            var context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
            context.Variables["x"] = i;
            var eDynamic = context.CompileGeneric<bool>("x % 5 = 0");

            var result = eDynamic.Evaluate();

            return result;
        }
    }
}