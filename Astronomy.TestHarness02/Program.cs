using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Astronomy.Core.Models;

namespace Astronomy.TestHarness02
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static string staticPath = "https://localhost:44375/api/StarSystems?Xmin=-2&Ymin=-2&Zmin=-2&Xmax=2&Ymax=2&Zmax=2";
        static string variablePath = "https://localhost:44375/api/StarSystems?Xmin=-{0}&Ymin=-{0}&Zmin=-{0}&Xmax={0}&Ymax={0}&Zmax={0}";
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
        };


        static async Task Main(string[] args)
        {

            double c = 4;
            do
            {
                Output("Starting up....");
                Output("Calling WebAPI...");

                c = UserInputNumber("Input a number (format: X.0): ");
                var url = BuildUrl(variablePath, c);
                Output($"    {url}");
                string? data = await CallStarSystems(url);

                Output("    Deserialize Data...");
                var starSystemList = DeserializeData(data);
                Output();
                Output();
                Output("Results:");
                Output();
                Output(starSystemList.ToMarkdownString() ?? "No data returned");


                Output();
                Output();
                Output($"Done (returned {starSystemList.Count} stars)...");
                Output();
                Output();
            } while (c >= 1);
            Output();
            Output();
            WaitApp();
        }

        private static StarSystemList DeserializeData(string json)
        {
            var result = new StarSystemList();
            var rows = JsonSerializer.Deserialize<List<StarSystem>>(json, options);
            result.AddRange(rows);
            return result;
        }



        private static async Task<string?> CallStarSystems()
        {
            HttpResponseMessage response = await client.GetAsync(staticPath);
            
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return data;
            }

            return null;
        }

        public static string BuildUrl(string formattedPath, double distanceConstant)
        {
            var result = string.Format(formattedPath, distanceConstant);
            return result;
        }

        private static async Task<string?> CallStarSystems(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return data;
            }

            return null;
        }

        static double UserInputNumber(string message = null)
        {
            Console.Write(message);
            var userInput = Console.ReadLine();
            var result = double.Parse(userInput);
            return result;
        }

        static void Output(string message = null)
        {
            Console.WriteLine(message);
        }

        static void WaitApp()
        {
            Console.WriteLine("Press <enter/return> key to exit this application...");
            Console.ReadLine();
        }
    }
}
