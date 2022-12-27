using Exercise.DataModels;
using Exercise.ServiceModels;

namespace Exercise.Services.AutoMapperProfiles
{
    public class CompanyMapperProfile : AutoMapper.Profile
    {
        public CompanyMapperProfile()
        {
            CreateMap<CompanyDto, CompanyServiceModel>().ReverseMap();
        }
    }
}
