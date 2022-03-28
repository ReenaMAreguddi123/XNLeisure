using System;
using XNLeisure.Business;

namespace XNLeisure.Calc.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Welcome to Calculator app! ----");
            Console.WriteLine();

            string input1;
            double num1;
            do
            {
                Console.Write("Please enter first number:");
                input1 = Console.ReadLine();

            } while (!double.TryParse(input1, out num1));

            string input2;
            double num2;
            do
            {
                Console.Write("Please enter second number:");
                input2 = Console.ReadLine();

            } while (!double.TryParse(input2, out num2));

            var calculator = new Calculator();
            var sum = calculator.Add(num1, num2);

            Console.WriteLine($"---- The sum of two numbers is : {sum} ----");

        }
    }
}
