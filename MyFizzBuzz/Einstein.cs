using System;

namespace MyFizzBuzz
{
    class Einstein
    {
        static void Main(string[] args)
        {
            var fizzBuzzRule = new FizzBuzzRule();
            var fizzRule = new FizzRule(fizzBuzzRule);
            var buzzRule = new BuzzRule(fizzBuzzRule);

            var myFizzBuzz = new MyFizzBuzz(fizzRule, buzzRule, fizzBuzzRule);

            Console.WriteLine("Gimme a number, Einstein!");
            var number = Convert.ToInt32(Console.ReadLine());

            var next = number;
            Console.WriteLine("here's your number");
            Console.Read();
            Console.WriteLine("Next 3:");
            Console.WriteLine(myFizzBuzz.Answer(number) + ", " + myFizzBuzz.Answer(number + 1) + ", " + myFizzBuzz.Answer(number + 2));
            Console.ReadLine();
        }
    }
}
