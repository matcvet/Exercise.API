using Exercise.DataModels;
using Exercise.Services.Models;

namespace Exercise.Services.MapperProfiles
{
    public static class CompanyMapperProfile
    {
        // Transfer CompanyDto to CompanyServiceModel
        public static CompanyServiceModel CompanyDtoToModel(this CompanyDto entity)
        {
            return new CompanyServiceModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Contacts = ContactMapperProfile.ContactDtoToModel(entity.Contacts)
            };
        }

        public static List<CompanyServiceModel> CompanyDtoToModel(this IEnumerable<CompanyDto> entities)
        {
            List<CompanyServiceModel> companies = new List<CompanyServiceModel>();

            foreach (CompanyDto entity in entities)
            {
                companies.Add(new CompanyServiceModel
                {
                    Id = entity.Id,
                    Name = entity.Name
                });
            }

            return companies;
        }

        // Transfer CompanyServiceModel to CompanyDto
        public static CompanyDto CompanyModelToDto(this CompanyServiceModel model)
        {
            return new CompanyDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static List<CompanyDto> CompanyModelToDto(this IEnumerable<CompanyServiceModel> models)
        {
            List<CompanyDto> companies = new List<CompanyDto>();

            foreach (CompanyServiceModel model in models)
            {
                companies.Add(new CompanyDto
                {
                    Id = model.Id,
                    Name = model.Name
                });
            }

            return companies;
        }
    }
}
