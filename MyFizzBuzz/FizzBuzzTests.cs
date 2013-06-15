﻿using System.Collections.Generic;
using Machine.Specifications;

// ReSharper disable InconsistentNaming 
// ReSharper disable CheckNamespace
namespace MyFizzBuzz
{
    [Subject(typeof (FizzBuzz), "Number for number")]
    internal class when_given_a_number
    {
        private It will_return_one = () => FizzBuzz.Answer(1).ShouldEqual("1");
        private It will_return_two = () => FizzBuzz.Answer(2).ShouldEqual("2");
    }

    [Subject(typeof (FizzBuzz), "Fizz")]
    internal class when_number_satisfies_fizz_rule
    {
        protected static FizzBuzz FizzBuzz;
        protected static FizzRule FizzRule;

        private Establish context = () =>
            {
                FizzRule = new FizzRule();
                FizzBuzz = new FizzBuzz(new List<IRule> {FizzRule});
            };
        private It will_return_fizz = () => FizzBuzz.Answer(3).ShouldEqual("Fizz");
    }

    [Subject(typeof (FizzBuzz), "Buzz")]
    internal class when_given_a_number_divisible_by_5
    {
        private It will_return_buzz = () => FizzBuzz.Answer(5).ShouldEqual("Buzz");
    }

    [Subject(typeof (FizzBuzz), "FizzBuzz")]
    internal class when_given_a_number_divisible_by_3_and_5
    {
        private It will_return_fizz_buzz = () => FizzBuzz.Answer(15).ShouldEqual("FizzBuzz");
    }
}