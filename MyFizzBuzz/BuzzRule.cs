using System;
using Ciloci.Flee;
namespace MyFizzBuzz
{
    public class BuzzRule : IRule
    {
        private readonly IRule _fizzBuzzRule;
        private readonly string _buzzExpression;

        public BuzzRule(IRule fizzBuzzRule, string buzzExpression)
        {
            _fizzBuzzRule = fizzBuzzRule;
            _buzzExpression = buzzExpression;
        }

        public bool Evaluate(int i)
        {
            if (_fizzBuzzRule.Evaluate(i)) return false;
            var context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
            context.Variables["x"] = i;
            bool result;
            try
            {
                var eDynamic = context.CompileGeneric<bool>(_buzzExpression);
                result = eDynamic.Evaluate();
            }
            catch (ExpressionCompileException e)
            {
                return false;
            }

            return result;
        }
    }
}