using System;
using Ciloci.Flee;

namespace MyFizzBuzz
{
    public class BuzzRule : IRule
    {
        private readonly IRule _fizzBuzzRule;
        private readonly string _buzzExpression;
        private readonly ExpressionContext _context;

        public BuzzRule(IRule fizzBuzzRule, string buzzExpression)
        {
            _fizzBuzzRule = fizzBuzzRule;
            _buzzExpression = buzzExpression;
            _context = new ExpressionContext();
            _context.Imports.AddType(typeof(Math));
        }

        public bool Evaluate(int i)
        {
            if (_fizzBuzzRule.Evaluate(i)) return false;
            _context.Variables["x"] = i;
            bool result;
            try
            {
                var eDynamic = _context.CompileGeneric<bool>(_buzzExpression);
                result = eDynamic.Evaluate();
            }
            catch (ExpressionCompileException)
            {
                return false;
            }

            return result;
        }
    }
}