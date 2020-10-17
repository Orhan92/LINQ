using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Personstatistik
{
    public class Person
    {
        public string Name;
        public int Age;
        public double Weight;
        public double Height;
    }
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var personList = new List<Person>();

            while (true)
            {
                Console.Write("Name (Press blank Enter to Exit): ");
                var name = Console.ReadLine();
                if (name == "")
                {
                    break; //jump out of the loop.
                }
                Console.Write("Age: ");
                var age = int.Parse(Console.ReadLine());
                Console.Write("Weight: ");
                var weight = double.Parse(Console.ReadLine());
                Console.Write("Height: ");
                var height = double.Parse(Console.ReadLine());
                Console.Clear();

                var p = new Person
                {
                    Name = name,
                    Age = age,
                    Weight = weight,
                    Height = height
                };

                personList.Add(p);
            }
            Console.WriteLine("Thank you for your inputs.");
            Console.WriteLine();

            var averageAge = personList.Average(p => p.Age);
            Console.WriteLine("Average: " + averageAge);

            var tallestPerson = personList.OrderByDescending(p => p.Height).Select(tallestPerson => tallestPerson.Name + ": " + tallestPerson.Height).First(); //Få in namnet på personen
            Console.WriteLine("Tallest person: " + tallestPerson);

            var highestBM = personList.OrderByDescending(p => p.Weight / (p.Height * p.Height)).Select(p => p.Name + ": " + p.Weight / (p.Height * p.Height)).First();
            Console.WriteLine("Highest BMI: " + highestBM);

            var tallerThan180 = personList.Where(p => p.Height >= 1.80).Select(p => p.Name + ": " + p.Height);
            Console.Write("1.80 or taller: ");
            Console.WriteLine(string.Join(", ", tallerThan180));

            var firstLetters = personList.Select(p => p.Name.First());
            Console.Write("First letters: ");
            Console.WriteLine(string.Join(", ", firstLetters));
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
