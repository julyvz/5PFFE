using System;

namespace _1ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] tokens = input.Split(">>>");
                switch (tokens[0])
                {
                    case "Contains":
                        if (rawKey.Contains(tokens[1]))
                        {
                            Console.WriteLine($"{rawKey} contains {tokens[1]}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        int startIdx = int.Parse(tokens[2]);
                        int endIdx = int.Parse(tokens[3]);
                        int count = endIdx - startIdx;
                        string piece = rawKey.Substring(startIdx, count);
                        rawKey = rawKey.Remove(startIdx, count);
                        if (tokens[1] == "Upper")
                        {
                            piece = piece.ToUpper();
                        }
                        else
                        {
                            piece = piece.ToLower();
                        }
                        rawKey = rawKey.Insert(startIdx, piece);
                        Console.WriteLine(rawKey);
                        break;
                    case "Slice":
                        startIdx = int.Parse(tokens[1]);
                        endIdx = int.Parse(tokens[2]);
                        count = endIdx - startIdx;
                        rawKey = rawKey.Remove(startIdx, count);
                        Console.WriteLine(rawKey);
                        break;

                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}
