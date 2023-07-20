using Exercise.DataModels;
using Exercise.Services.Models;

namespace Exercise.Services.MapperProfiles
{
    public static class CountryMapperProfile
    {
        // Transfer CountryDto to CountryServiceModel
        public static CountryServiceModel CountryDtoToModel(this CountryDto entity)
        {
            return new CountryServiceModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Contacts = ContactMapperProfile.ContactDtoToModel(entity.Contacts),
            };
        }

        public static List<CountryServiceModel> CountryDtoToModel(this IEnumerable<CountryDto> entities)
        {
            List<CountryServiceModel> countries = new List<CountryServiceModel>();

            foreach (CountryDto entity in entities)
            {
                countries.Add(new CountryServiceModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Contacts = ContactMapperProfile.ContactDtoToModel(entity.Contacts),
                });
            }

            return countries;
        }

        // Transfer CountryServiceModel to CountryDto
        public static CountryDto CountryModelToDto(this CountryServiceModel model)
        {
            return new CountryDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static List<CountryDto> CountryModelToDto(this IEnumerable<CountryServiceModel> models)
        {
            List<CountryDto> countries = new List<CountryDto>();

            foreach (CountryServiceModel model in models)
            {
                countries.Add(new CountryDto
                {
                    Id = model.Id,
                    Name = model.Name
                });
            }

            return countries;
        }
    }
}
