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
        static string path = "https://localhost:44375/api/StarSystems?Xmin=-2&Ymin=-2&Zmin=-2&Xmax=2&Ymax=2&Zmax=2";
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
        };
        static async Task Main(string[] args)
        {
            Output("Starting up....");
            Output("Calling WebAPI...");
            Output($"    {path}");

            string? data = await CallStarSystems();
            Output("    Deserialize Data...");
            var starSystemList = DeserializeData(data);
            Output();
            Output();
            Output("Results:");
            Output();
            Output(starSystemList.ToMarkdownString() ?? "No data returned");
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
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return data;
            }

            return null;
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
