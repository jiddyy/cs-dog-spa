using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Gagoya
{
    class Program
    {
        static Dictionary<string, Dictionary<string, Dog>> loadServices()
        {
            string services = File.ReadAllText(@"./services.json");
            return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dog>>>(services);
        }
        static string GetUserService(Dictionary<string, Dictionary<string, Dog>> menu)
        {
            Console.WriteLine("Welcome to the Dog Spa! Here are our services:");
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    Console.WriteLine($"{services.Value.Name}: ${services.Value.Price}");
                }
            }
            Console.WriteLine("What would you like today? ");
            string usersService = Console.ReadLine();
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    if (services.Value.Name == usersService)
                    {
                        return usersService;
                    }
                }
            }
            return "Gagoya";
        }
        static decimal GetPriceOfService(Dictionary<string, Dictionary<string, Dog>> menu, string usersService)
        {
            foreach (var service in menu)
            {
                foreach (var services in service.Value)
                {
                    if (services.Value.Name == usersService)
                    {
                        return services.Value.Price;
                    }
                }
            }
            return 0.00M;
        }
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, Dog>> menu = loadServices();
            string usersService = GetUserService(menu);
            Console.WriteLine($"{usersService}, awesome!");
            decimal priceOfService = GetPriceOfService(menu, usersService);
            Console.WriteLine($"Total: ${priceOfService}.");
            Console.WriteLine("Come back in about 20 minutes.");
        }
    }
}