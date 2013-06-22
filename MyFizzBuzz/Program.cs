namespace MyFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public static class FizzBuzz
    {
        public static string Answer(int number)
        {
            if (FizzBuzzRule(number))
                return "FizzBuzz";
            if (BuzzRule(number))
                return "Buzz";
            if (FizzRule(number))
                return "Fizz";
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
