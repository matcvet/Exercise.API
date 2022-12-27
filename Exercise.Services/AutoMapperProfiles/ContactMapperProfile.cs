using Exercise.DataModels;
using Exercise.ServiceModels;

namespace Exercise.Services.AutoMapperProfiles
{
    public class ContactMapperProfile : AutoMapper.Profile
    {
        public ContactMapperProfile()
        {
            CreateMap<ContactDto, ContactServiceModel>().ReverseMap();
        }
    }
}
