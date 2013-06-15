namespace MyFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class FizzBuzz
    {
        public static string Answer(int number)
        {
            if (FizzBuzzRule(number))
                return "FizzBuzz";
            if (BuzzRule(number))
                return "Buzz";
            else if (FizzRule(number))
                return "Fizz";
            else
                return number.ToString();
        }

        public static bool FizzBuzzRule(int number)
        {
            return (number%3 == 0 && number%5 == 0);
        }

        public static bool BuzzRule(int number)
        {
            return (number%5 == 0);
        }

        public static bool FizzRule(int number)
        {
            return (number%3 == 0);
        }
    }
}
