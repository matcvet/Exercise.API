using Exercise.ServiceModels;

namespace Exercise.Services.Abstraction
{
    public interface ICountryService
    {
        /// <summary>
        ///     Returns country model by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="CountryServiceModel"/></returns>
        CountryServiceModel GetCountryById(int id);

        /// <summary>
        ///     Returns lists of countries
        /// </summary>
        /// <returns><see cref="List{CountryServiceModel}"/></returns>
        List<CountryServiceModel> GetAllCountries();

        /// <summary>
        ///     Inserts new country model in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="int"/></returns>
        int Create(CountryServiceModel model);

        /// <summary>
        ///     Update country model in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="CountryServiceModel"/></returns>
        CountryServiceModel Update(CountryServiceModel model);

        /// <summary>
        ///     Deletes country model from database
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
