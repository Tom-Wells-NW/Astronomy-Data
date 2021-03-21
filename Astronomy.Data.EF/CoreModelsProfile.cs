using Astronomy.Core.Models;
using Astronomy.Data.EF.Models;
using AutoMapper;

namespace Astronomy.Data.EF
{

    public class CoreModelsProfile : Profile
	{
		public CoreModelsProfile()
		{
			CreateMap<HygDatum, StarSystem>();
			// Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
		}
	}
}
