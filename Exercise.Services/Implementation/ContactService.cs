using AutoMapper;
using Exercise.DataAccess.Abstraction;
using Exercise.DataModels;
using Exercise.Exceptions;
using Exercise.ServiceModels;
using Exercise.Services.Abstraction;

namespace Exercise.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IRepository<ContactDto> _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IRepository<ContactDto> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
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

            return _mapper.Map<ContactServiceModel>(contact);
        }

        /// <summary>
        ///     Inserts new contact in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="int"/></returns>
        /// <exception cref="ContactException"></exception>
        public int Create(ContactServiceModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ContactException("Contact name field is required.");
            }

            var contact = _mapper.Map<ContactDto>(model);
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
            contactToUpdate.CountryId = model.CountryId;
            contactToUpdate.CompanyId = model.CompanyId;

            var updatedContact = _contactRepository.Update(contactToUpdate);
            return _mapper.Map<ContactServiceModel>(updatedContact);
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
            var contacts = _contactRepository.GetAll();

            if(contacts == null)
            {
                throw new ContactException("There was an error while fetching contacts list");
            }

            if (companyId > 0)
            {
                contacts = contacts.Where(x => x.CompanyId == companyId);
            }

            if (countryId > 0)
            {
                contacts = contacts.Where(x => x.CountryId == countryId);
            }

            return _mapper.Map<List<ContactServiceModel>>(contacts);
        }

        /// <summary>
        ///     Lists all contacts from database
        /// </summary>
        /// <returns><see cref="List{ContactServiceModel}"/></returns>
        public List<ContactServiceModel> GetContactsWithCompanyAndCountry()
        {
            return _mapper.Map<List<ContactServiceModel>>(_contactRepository.GetAll());
        }
    }
}
