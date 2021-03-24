using System;
using System.Text.RegularExpressions;

namespace _2EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";

            MatchCollection numbers = Regex.Matches(input, @"\d");
            long coolThresholdSum = 1;
            foreach (Match item in numbers)
            {
                coolThresholdSum *= int.Parse(item.Value);
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");

            MatchCollection emojis = Regex.Matches(input, pattern);

            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            foreach (Match emoji in emojis)
            {
                string name = emoji.Groups["emoji"].Value;
                int coolness = 0;
                foreach (var letter in name)
                {
                    coolness += letter;
                }
                if (coolness > coolThresholdSum)
                {
                    Console.WriteLine(emoji);
                }
            }
        }
    }
}
