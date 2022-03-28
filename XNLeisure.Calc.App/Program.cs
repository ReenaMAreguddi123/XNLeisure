using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using XNLeisure.Business;

namespace XNLeisure.Calc.App
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            while (true)
            {
                RunCalculator(host.Services);

                Console.WriteLine();
                Console.WriteLine("Do you want to continue(y/n)?");
                var input = Console.ReadLine();

                if (input != "y")
                    break;
            }

            return host.RunAsync();
        }

        private static void RunCalculator(IServiceProvider services)
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

            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var calculator = provider.GetRequiredService<ICalculator>();
            var sum = calculator.Add(num1, num2);

            Console.WriteLine();
            Console.WriteLine($"---- The sum of two numbers is : {sum} ----");
            Console.WriteLine();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<ICalculator, Calculator>());
                       
        }
    }
}
