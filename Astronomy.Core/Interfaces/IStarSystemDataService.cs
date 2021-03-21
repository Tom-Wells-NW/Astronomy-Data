using System.Threading.Tasks;
using Astronomy.Core.Models;
using Astronomy.Core.Interfaces;

namespace Astronomy.Core.Interfaces
{
    public interface IStarSystemDataService
    {
        Task<IStarSystem> GetStarSystemAsync(int id);
        Task<int> GetCountOfStarsInCoordinateRangeAsync(double Xmin, double Ymin, double Zmin, double Xmax, double Ymax, double Zmax);
        Task<IStarSystemList> GetStarsInCoordinateRangeAsync(double Xmin, double Ymin, double Zmin, double Xmax, double Ymax, double Zmax);
    }
}