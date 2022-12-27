using Exercise.DataModels;
using Exercise.ServiceModels;

namespace Exercise.Mappers
{
    public class ContactMappingProfile : AutoMapper.Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, ContactServiceModel>().ReverseMap();
        }
    }
}
