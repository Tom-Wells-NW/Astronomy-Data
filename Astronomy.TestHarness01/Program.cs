using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astronomy.Core.Interfaces;
using Astronomy.Core.Models;
using Astronomy.Data.EF;
using Astronomy.Data.EF.Data;
using Astronomy.Data.EF.Models;

namespace Astronomy.TestHarness01
{
    class Program
    {
        static StarSystemDataService _starSystemDataService;

        static async Task Main(string[] args)
        {
            _starSystemDataService = new StarSystemDataService();
            double c = 4;
            do
            {
                c = UserInputNumber("Input a number (format: X.0): ");

                Output("Starting up....");
                Output("Calling StarSystemDataService...");


                Output($"    GetCountOfStarsInCoordinateRange(-{c}, -{c}, -{c}, {c}, {c}, {c})");
                var count = await GetCountOfStarsInCoordinateRange(-c, -c, -c, c, c, c);
                Output($"Stars within range: {count}");

                Output($"    GetStarsInCoordinateRange(-{c}, -{c}, -{c}, {c}, {c}, {c})");
                var starSystems = await GetStarsInCoordinateRange(-c, -c, -c, c, c, c);

                Output(starSystems.ToMarkdownString());
                Output();
                Output();
                Output($"Done (returned {count} stars)...");
                Output();
            } while (c >= 1);
            WaitApp();
        }


        
        static async Task<IStarSystemList> GetStarsInCoordinateRange(double Xmin, double Ymin, double Zmin, double Xmax, double Ymax, double Zmax)
        {
            var result = await _starSystemDataService.GetStarsInCoordinateRangeAsync(Xmin, Ymin, Zmin, Xmax, Ymax, Zmax);
            return result;
        }


        static async Task<int> GetCountOfStarsInCoordinateRange(double Xmin, double Ymin, double Zmin, double Xmax, double Ymax, double Zmax)
        {
            var result = await _starSystemDataService.GetCountOfStarsInCoordinateRangeAsync(Xmin, Ymin, Zmin, Xmax, Ymax, Zmax);
            return result;
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
