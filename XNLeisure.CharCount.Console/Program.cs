using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using XNLeisure.Business;

namespace XNLeisure.CharCount.App
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            while (true)
            {
                RunCharacterCount(host.Services);

                Console.WriteLine();
                Console.WriteLine("Do you want to continue(y/n)?");
                var input = Console.ReadLine();

                if (input != "y")
                    break;
            }

            return host.RunAsync();
        }

        private static void RunCharacterCount(IServiceProvider services)
        {
            Console.WriteLine();
            Console.WriteLine("---- Welcome to character count app! ----");
            Console.WriteLine();

            string sentence;
            do
            {
                Console.Write("Please enter a sentence/number:");
                sentence = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(sentence));


            string lookFor;
            do
            {
                Console.Write("Please enter a character to count:");
                lookFor = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(lookFor) || lookFor.Length > 1);

            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var characterCount = provider.GetRequiredService<ICharacterCount>();
            var count = characterCount.Count(sentence, Convert.ToChar(lookFor));

            Console.WriteLine($"---- Found {count} occurrences of character '{lookFor}' ----");
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<ICharacterCount, CharacterCount>());

        }
    }
}
