using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nummerstatistik
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var numbers = new List<int>();

            Console.WriteLine("mata in siffror, tryck en blank enter för att avsluta.");

            bool done = true;
            while (done)
            {
                var input = Console.ReadLine();
                if (input == "")
                {
                    done = false;
                }
                else
                {
                    var num = int.Parse(input);
                    numbers.Add(num);
                }
            }

            var sumNumbers = numbers.Sum(); //Sum of numbers 
            Console.WriteLine("Sum: " + sumNumbers);

            var largestNumbers = numbers.Max(); //Largest numbers
            Console.WriteLine("Largest: " + largestNumbers);

            var smallestNumbers = numbers.Min(); //Smallest numbers
            Console.WriteLine("Smallest: " + smallestNumbers);

            var averageNumbers = numbers.Average(); //Average number
            Console.WriteLine("Average: " + averageNumbers);

            var tenOrHigher = numbers.Where(x => x >= 10); //10 or higher in numbers
            Console.Write("10 or higher: ");
            Console.WriteLine(string.Join(", ", tenOrHigher));

            var betweenTenAndTwenty = numbers.Where(x => x >= 10 && x <= 20); //Between 10 and 20 in numbers
            Console.Write("Between 10 and 20: ");
            Console.WriteLine(string.Join(", ", betweenTenAndTwenty));

            var sumBetweeenTenAndTwenty = numbers.Where(x => x >= 10 && x <= 20).Sum(); //Sum of numbers between 10 and 20 in numbers
            Console.WriteLine("Sum between 10 and 20: " + sumBetweeenTenAndTwenty);

            var squares = numbers.Select(x => x * x); //Squares of numbers in numbers
            Console.Write("Squares: ");
            Console.WriteLine(string.Join(", ", squares));

            var orderBy = numbers.OrderBy(x => x); //Ordering numbers in numbers
            Console.Write("Ordered: ");
            Console.WriteLine(string.Join(", ", orderBy));
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            Assert.AreEqual("Hello!", console.Output);
        }
    }
}
