using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astronomy.Core.Interfaces;
using Astronomy.Core.Models;
using Astronomy.Data.EF.Data;
using Astronomy.Data.EF.Models;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Astronomy.Data.EF
{
    public class StarSystemDataService : IStarSystemDataService
    {
        private MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;

        public StarSystemDataService()
        {
            InitializeAutoMapper();
        }

        private void InitializeAutoMapper()
        {
            _mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<CoreModelsProfile>();
            });
            _mapper = new Mapper(_mapperConfiguration);
        }

        private StarSystem MapToCoreModel(HygDatum star)
        {
            var result = _mapper.Map<StarSystem>(star);
            return result;
        }
        
        private StarSystemList MapToCoreModelList(List<HygDatum> stars)
        {
            var result = new StarSystemList();

            foreach (var hygDatum in stars)
            {
                result.Add(_mapper.Map<StarSystem>(hygDatum));
            }

            return result;
        }

        public async Task<IStarSystem> GetStarSystemAsync(int id)
        {
            var context = new AstronomicalDataContext();
            var query = await context.HygData.FindAsync(id);
            var star = query;
            return MapToCoreModel(star);
        }

        public async Task<int> GetCountOfStarsInCoordinateRangeAsync(double Xmin, double Ymin, double Zmin, double Xmax, double Ymax, double Zmax)
        {
            var result = new pGetCountOfStarsInCoordinateRangeResult();
            try
            {
                var context = new AstronomicalDataContext();
                var query = await context.GetProcedures().pGetCountOfStarsInCoordinateRangeAsync(Xmin, Ymin, Zmin, Xmax, Ymax, Zmax);
                result = query.FirstOrDefault();
            }
            catch
            {
                return -1;
            }
            return (result.Count.HasValue ? result.Count.Value : 0);
        }

        public async Task<IStarSystemList> GetStarsInCoordinateRangeAsync(double Xmin, double Ymin, double Zmin, double Xmax, double Ymax, double Zmax)
        {
            var context = new AstronomicalDataContext();
            var query = await context.GetProcedures().pGetStarsInCoordinateRangeAsync(Xmin, Ymin, Zmin, Xmax, Ymax, Zmax);
            var stars = query.ToList();
            return MapToCoreModelList(stars);
        }
    }
}
