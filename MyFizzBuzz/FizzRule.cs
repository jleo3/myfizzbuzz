namespace MyFizzBuzz
{
    public class FizzRule : IRule
    {
        private readonly IRule _fizzBuzzRule;

        public FizzRule(IRule fizzBuzzRule)
        {
            _fizzBuzzRule = fizzBuzzRule;
        }

        public bool Evaluate(int i)
        {
            if (_fizzBuzzRule.Evaluate(i)) return false;
            return i%3 == 0;
        }
    }

    public interface IRule
    {
        bool Evaluate(int i);
    }
}