using System;

namespace MyFizzBuzz
{
    class Einstein
    {
        static void Main()
        {
            var myFizzBuzz = CreateMyFizzMuzz();

            Console.WriteLine("[EINSTEIN] I am Albert Einstein, King of Drinking Games!");
            Console.WriteLine("[EINSTEIN] I challenge you to FizzBuzz!");
            Console.WriteLine("[EINSTEIN] Fizz rule: x % 3 == 0");
            Console.WriteLine("[EINSTEIN] Buzz rule: x % 5 == 0");
            Console.ReadKey();

            Console.WriteLine("[EINSTEIN] We'll take the first number from the bar...");
            var round1Num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("[EINSTEIN] What are the next 3, you little punk?");
            Console.ReadKey();
            AnswerEinstein(myFizzBuzz, round1Num);

            Console.WriteLine("[EINSTEIN] Gah! Fine, I'll drink!");
            Console.WriteLine("[EINSTEIN] Let's get another number! Drunkards, what say you?");
            var round2Num = Convert.ToInt32(Console.ReadLine());
            AnswerEinstein(myFizzBuzz, round2Num);

            Console.WriteLine("[EINSTEIN] Gah! Right again!");
            Console.ReadKey();
            Console.WriteLine("[EINSTEIN] Ok, I'm changing the rules for the next round...");
            Console.WriteLine("[EINSTEIN] Fizz rule: x * x % 2 == 0");
            Console.WriteLine("[EINSTEIN] Buzz rule: x * x % 7 == 0");
            Console.ReadKey();
            Console.WriteLine("[EINSTEIN] I need another number and another drink for my foolish little friend!");
            Console.ReadKey();
        }

        private static void AnswerEinstein(MyFizzBuzz myFizzBuzz, int number)
        {
            Console.WriteLine("[TEST_FIRST_FB] "
                              + myFizzBuzz.Answer(number + 1) + ", "
                              + myFizzBuzz.Answer(number + 2) + ", "
                              + myFizzBuzz.Answer(number + 3));
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
