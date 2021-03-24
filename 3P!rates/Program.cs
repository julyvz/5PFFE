using System;
using System.Linq;
using System.Collections.Generic;

namespace _3P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int[]> cities = new Dictionary<string, int[]>();
            while (input != "Sail")
            {
                string[] tokens = input.Split("||");
                string cityName = tokens[0];
                int cityPopulation = int.Parse(tokens[1]);
                int cityGold = int.Parse(tokens[2]);

                if (!cities.ContainsKey(cityName))
                {
                    cities.Add(cityName, new int[] { cityPopulation, cityGold });
                }
                else
                {
                    cities[cityName][0] += cityPopulation;
                    cities[cityName][1] += cityGold;
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split("=>");
                string command = tokens[0];
                string cityName = tokens[1];
                if (command == "Plunder")
                {
                    int cityPopulation = int.Parse(tokens[2]);
                    int cityGold = int.Parse(tokens[3]);
                    cities[cityName][0] -= cityPopulation;
                    cities[cityName][1] -= cityGold;
                    Console.WriteLine($"{cityName} plundered! {cityGold} gold stolen, {cityPopulation} citizens killed.");
                    if (cities[cityName][0] == 0 || cities[cityName][1] == 0)
                    {
                        cities.Remove(cityName);
                        Console.WriteLine($"{cityName} has been wiped off the map!");
                    }
                }
                else //Prosper
                {
                    int cityGold = int.Parse(tokens[2]);
                    if (cityGold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[cityName][1] += cityGold;
                        Console.WriteLine($"{cityGold} gold added to the city treasury. {cityName} now has {cities[cityName][1]} gold.");
                    }
                }
                input = Console.ReadLine();
            }
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var town in cities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value[0]} citizens, Gold: {town.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
