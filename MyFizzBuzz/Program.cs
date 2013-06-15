namespace MyFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class MyFizzBuzz
    {
        private readonly IRule _fizzBuzzRule;
        private readonly IRule _fizzRule;
        private readonly IRule _buzzRule;

        public MyFizzBuzz(IRule fizzBuzzRule, IRule fizzRule, IRule buzzRule)
        {
            _fizzBuzzRule = fizzBuzzRule;
            _fizzRule = fizzRule;
            _buzzRule = buzzRule;
        }

        public string Answer(int number)
        {
            if (_fizzBuzzRule.Evaluate(number)) return "FizzBuzz";
            if (_fizzRule.Evaluate(number)) return "Fizz";
            if (_buzzRule.Evaluate(number)) return "Buzz";
            return number.ToString();
        }
    }
}
