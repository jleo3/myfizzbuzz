using System;

namespace MyFizzBuzz
{
    class Einstein
    {
        static void Main()
        {
            var myFizzBuzz = CreateMyFizzMuzz();

            Console.WriteLine("Gimme a number, Einstein!");
            var number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Next 3:");
            Console.WriteLine(myFizzBuzz.Answer(number) + ", " 
                + myFizzBuzz.Answer(number + 1) + ", " 
                + myFizzBuzz.Answer(number + 2));
            Console.ReadKey();
        }

        private static MyFizzBuzz CreateMyFizzMuzz()
        {
            var fizzBuzzRule = new FizzBuzzRule();
            var fizzRule = new FizzRule(fizzBuzzRule);
            var buzzRule = new BuzzRule(fizzBuzzRule);
            var myFizzBuzz = new MyFizzBuzz(fizzBuzzRule, fizzRule, buzzRule);
            return myFizzBuzz;
        }
    }
}
