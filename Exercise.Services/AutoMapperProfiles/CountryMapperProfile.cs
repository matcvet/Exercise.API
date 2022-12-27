using Exercise.DataModels;
using Exercise.ServiceModels;

namespace Exercise.Services.AutoMapperProfiles
{
    public class CountryMapperProfile : AutoMapper.Profile
    {
        public CountryMapperProfile()
        {
            CreateMap<CountryDto, CountryServiceModel>().ReverseMap();
        }
    }
}
