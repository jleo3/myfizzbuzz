namespace MyFizzBuzz
{
    public class FizzBuzzRule : IRule
    {
        public bool Evaluate(int i)
        {
            return (i%3 == 0 && i%5 == 0);
        }
    }
}