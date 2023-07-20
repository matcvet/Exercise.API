using Exercise.DataModels;
using Exercise.Services.Models;

namespace Exercise.Services.Interfaces
{
    public interface IContactService
    {
        /// <summary>
        ///     Returns contact by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="ContactServiceModel"/></returns>
        ContactServiceModel GetContactById(int id);

        /// <summary>
        ///     Inserts new contact in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="int"/></returns>
        int Create(ContactServiceModel model);

        /// <summary>
        ///     Updates contact model in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="ContactServiceModel"/></returns>
        ContactServiceModel Update(ContactServiceModel model);

        /// <summary>
        ///     Deletes contact by given id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        ///     Lists all contacts from database
        /// </summary>
        /// <returns><see cref="List{ContactServiceModel}"/></returns>
        List<ContactServiceModel> GetContactsWithCompanyAndCountry();

        /// <summary>
        ///     Returns list of contacts by companyId, countryId or both
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="countryId"></param>
        /// <returns><see cref="List{ContactServiceModel}"/></returns>
        List<ContactServiceModel> FilterContacts(int companyId, int countryId);
    }
}
