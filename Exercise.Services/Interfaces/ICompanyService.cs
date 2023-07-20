using Exercise.Services.Models;

namespace Exercise.Services.Interfaces
{
    public interface ICompanyService
    {
        /// <summary>
        ///     Gets company model by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="CompanyServiceModel"/></returns>
        CompanyServiceModel GetCompanyById(int id);

        /// <summary>
        ///     Returns a list of all companies
        /// </summary>
        /// <returns><see cref="List{CompanyServiceModel}"/></returns>
        List<CompanyServiceModel> GetAllCompanies();

        /// <summary>
        ///     Inserts new company model in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="CompanyServiceModel"/></returns>
        int Create(CompanyServiceModel model);

        /// <summary>
        ///     Update company model in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="CompanyServiceModel"/></returns>
        CompanyServiceModel Update(CompanyServiceModel model);
        
        /// <summary>
        ///     Deletes company model by given id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
