using System;
using System.IO;
using NUnit.Framework;

namespace FizzBuzzApp
{
    public interface IFizzBuzzService
    {
        string PrintFizzBuzz(string n);
        //string GetFizzBuzzResult(string input);
    }
    public class FizzBuzzService : IFizzBuzzService
    {
        private static FizzBuzzService _instance;

        private FizzBuzzService() { }

        public static FizzBuzzService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FizzBuzzService();
            }
            return _instance;
        }
        public string PrintFizzBuzz(string input)
        {
            if (int.TryParse(input, out int number))
            {
                if (number % 3 == 0 && number % 5 == 0)
                {
                    return "FizzBuzz";
                }
                else if (number % 3 == 0)
                {
                    return "Fizz";
                }
                else if (number % 5 == 0)
                {
                    return "Buzz";
                }
                else
                {
                   return $"Divided {number} by 3 and divided {number} by 5";
                }
            }
            else
            {
                return "Invalid item";
            }
        }
    
}
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private IFizzBuzzService _fizzBuzzService;

        [SetUp]
        public void Setup()
        {
            _fizzBuzzService = FizzBuzzService.GetInstance();
        }

        [TestCase("1", ExpectedResult = "Divided 1 by 3 and divided 1 by 5")]
        [TestCase("3", ExpectedResult = "Fizz")]
        [TestCase("5", ExpectedResult = "Buzz")]
        [TestCase("15", ExpectedResult = "FizzBuzz")]
        [TestCase("A", ExpectedResult = "Invalid item")]
        [TestCase("23", ExpectedResult = "Divided 23 by 3 and divided 23 by 5")]
        public string FizzBuzzService_GetFizzBuzzResult_ReturnsExpectedResult(string input)
        {
            return _fizzBuzzService.PrintFizzBuzz(input);
        }
    }
    class program
{
    static void Main(string[] args)
    {

            var fizzBuzzService = FizzBuzzService.GetInstance();

            Console.WriteLine("Enter an input:");
            string input = Console.ReadLine();
           Console.WriteLine( fizzBuzzService.PrintFizzBuzz(input));
        }
}
}
