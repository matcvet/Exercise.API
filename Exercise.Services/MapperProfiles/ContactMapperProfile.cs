using Exercise.DataModels;
using Exercise.Services.Models;

namespace Exercise.Services.MapperProfiles
{
    public static class ContactMapperProfile
    {

        // Map ContactDto to ContactServiceModel
        public static ContactServiceModel ContactDtoToModel(this ContactDto entity)
        {
            return new ContactServiceModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Company = new KeyValuePair<int, string>(entity.Company.Id, entity.Company.Name),
                Country = new KeyValuePair<int, string>(entity.Country.Id, entity.Country.Name),
            };
        }

        public static List<ContactServiceModel> ContactDtoToModel(this IEnumerable<ContactDto> entities)
        {
            List<ContactServiceModel> contacts = new List<ContactServiceModel>();

            foreach (ContactDto entity in entities)
            {
                contacts.Add(new ContactServiceModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Company = new KeyValuePair<int, string>(entity.Company.Id, entity.Company.Name),
                    Country = new KeyValuePair<int, string>(entity.Country.Id, entity.Country.Name),
                });
            }

            return contacts;
        }

        // Map ContactServiceModel to ContactDto
        public static ContactDto ContactModelToDto(this ContactServiceModel model)
        {
            return new ContactDto
            {
                Id = model.Id,
                Name = model.Name,
                CompanyId = model.Company.Key,
                CountryId = model.Company.Key
            };
        }

        public static List<ContactDto> ContactModelToDto(this List<ContactServiceModel> models)
        {
            var contacts = new List<ContactDto>();

            foreach (var contact in models)
            {
                contacts.Add(new ContactDto
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    CompanyId = contact.Company.Key,
                    CountryId = contact.Company.Key
                });
            }

            return contacts;
        }
    }
}
