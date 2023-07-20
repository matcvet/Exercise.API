using Exercise.DataAccess.Abstraction;
using Exercise.DataModels;
using Exercise.Exceptions;
using Exercise.Services.Models;
using Exercise.Services.Interfaces;
using Exercise.Services.Validations;
using Exercise.Services.MapperProfiles;
using FluentValidation;

namespace Exercise.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IRepository<ContactDto> _contactRepository;
        private readonly ContactValidation contactValidation = new ContactValidation();

        public ContactService(IRepository<ContactDto> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        /// <summary>
        ///     Returns contact by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="ContactServiceModel"/></returns>
        /// <exception cref="ContactException"></exception>
        public ContactServiceModel GetContactById(int id)
        {
            var contact = _contactRepository.GetById(id);

            if (contact == null)
            {
                throw new ContactException("User was not found in database.");
            }

            return ContactMapperProfile.ContactDtoToModel(contact);
        }

        /// <summary>
        ///     Inserts new contact in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="int"/></returns>
        /// <exception cref="ContactException"></exception>
        public int Create(ContactServiceModel model)
        {
            //contactValidation.ValidateAndThrow(model);
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ContactException("Contact name field is required.");
            }

            var contact = ContactMapperProfile.ContactModelToDto(model);
            _contactRepository.Create(contact);
            return contact.Id;
        }

        /// <summary>
        ///     Updates contact model in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="ContactServiceModel"/></returns>
        /// <exception cref="ContactException"></exception>
        public ContactServiceModel Update(ContactServiceModel model)
        {
            var contactToUpdate = _contactRepository.GetById(model.Id);

            if (contactToUpdate == null)
            {
                throw new ContactException("User was not found in database.");
            }

            contactToUpdate.Name = model.Name;
            contactToUpdate.CountryId = model.Country.Key;
            contactToUpdate.CompanyId = model.Company.Key;

            var updatedContact = _contactRepository.Update(contactToUpdate);
            return ContactMapperProfile.ContactDtoToModel(updatedContact);
        }

        /// <summary>
        ///     Deletes contact by given id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ContactException"></exception>
        public void Delete(int id)
        {
            if (_contactRepository.GetById(id) == null)
            {
                throw new ContactException($"Contact with id: {id} does not exist in database");
            }

            _contactRepository.Delete(id);
        }

        /// <summary>
        ///     Returns list of contacts by companyId, countryId or both
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="countryId"></param>
        /// <returns><see cref="List{ContactServiceModel}"/></returns>
        /// <exception cref="ContactException"></exception>
        public List<ContactServiceModel> FilterContacts(int companyId, int countryId)
        {
            var contacts = _contactRepository.GetAll().Where(x => x.CountryId == countryId && x.CompanyId == companyId);

            if(contacts == null)
            {
                throw new ContactException("There was an error while fetching contacts list");
            }

            return ContactMapperProfile.ContactDtoToModel(contacts);
        }

        /// <summary>
        ///     Lists all contacts from database
        /// </summary>
        /// <returns><see cref="List{ContactServiceModel}"/></returns>
        public List<ContactServiceModel> GetContactsWithCompanyAndCountry()
        {
            return ContactMapperProfile.ContactDtoToModel(_contactRepository.GetAll());
        }
    }
}
