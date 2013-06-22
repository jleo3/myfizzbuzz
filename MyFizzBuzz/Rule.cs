using System;
using System.Collections.Generic;
using Ciloci.Flee;

namespace MyFizzBuzz
{
    public class Rule : IRule
    {
        private readonly List<string> _expressions;
        private readonly ExpressionContext _context;

        public Rule(List<string> expressions)
        {
            _expressions = expressions;
            _context = new ExpressionContext();
            _context.Imports.AddType(typeof(Math));
        }

        public bool Evaluate(int i)
        {
            foreach (var expression in _expressions)
            {
                _context.Variables["x"] = i;
                try
                {
                    var eDynamic = _context.CompileGeneric<bool>(expression);
                    var result = eDynamic.Evaluate();
                    if (!result) return false;
                }
                catch (ExpressionCompileException)
                {
                    return false;
                }
            }
            return true;
        }
    }
}