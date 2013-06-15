namespace MyFizzBuzz
{
    public class BuzzRule
    {
        private readonly IRule _fizzBuzzRule;

        public BuzzRule(IRule fizzBuzzRule)
        {
            _fizzBuzzRule = fizzBuzzRule;
        }

        public bool Evaluate(int i)
        {
            if (_fizzBuzzRule.Evaluate(i)) return false;
            return (i%5 == 0);
        }
    }
}