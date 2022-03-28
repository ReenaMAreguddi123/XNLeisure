using System;
using XNLeisure.Business;

namespace XNLeisure.CharCount.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Welcome to character count app! ----");
            Console.WriteLine();

            string sentence;
            do
            {
                Console.Write("Please enter a sentence:");
                sentence = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(sentence));


            string lookFor;
            do
            {
                Console.Write("Please enter a character to count:");
                lookFor = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(lookFor) || lookFor.Length > 1);

            var characterCount = new CharacterCount();
            var count = characterCount.Count(sentence, Convert.ToChar(lookFor));

            Console.WriteLine($"---- Found {count} occurrences of character '{lookFor}' ----");
        }
    }
}
