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

            Output("Starting up....");
            Output("Calling StarSystemDataService...");
            Output("    GetCountOfStarsInCoordinateRange(-5, -5, -5, 5, 5, 5)");
            var count = await GetCountOfStarsInCoordinateRange(-5, -5, -5, 5, 5, 5);
            Output("    GetStarsInCoordinateRange(-5, -5, -5, 5, 5, 5)");
            var starSystems = await GetStarsInCoordinateRange(-5, -5, -5, 5, 5, 5);
            Output("Done");
            Output();
            Output(starSystems.ToMarkdownString());
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
