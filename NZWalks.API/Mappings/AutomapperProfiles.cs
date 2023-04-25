using AutoMapper;
using Mapster;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles() 
        {
            //using Automapper
            CreateMap<Region, RegionDTO>().ReverseMap();

            ////using Mapster
            //TypeAdapterConfig<Region, RegionDTO>.NewConfig()
            //    .Map(dest=>dest.Code,src=>src.Code)
            //    .Map(dest => dest.Code+dest.Name, src => src.Code);
        }
    }
}
