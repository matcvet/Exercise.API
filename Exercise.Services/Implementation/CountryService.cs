using Exercise.DataAccess.Abstraction;
using Exercise.DataModels;
using Exercise.Exceptions;
using Exercise.Services.Models;
using Exercise.Services.Interfaces;
using Exercise.Services.MapperProfiles;

namespace Exercise.Services.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<CountryDto> _countryRepository;

        public CountryService(IRepository<CountryDto> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary>
        ///     Returns country model by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="CountryServiceModel"/></returns>
        /// <exception cref="CountryException"></exception>
        public CountryServiceModel GetCountryById(int id)
        {
            var country = _countryRepository.GetById(id);

            if(country == null)
            {
                throw new CountryException($"Country with id: {id} doesn't exist");
            }

            return CountryMapperProfile.CountryDtoToModel(country);
        }

        /// <summary>
        ///     Returns lists of countries
        /// </summary>
        /// <returns><see cref="List{CountryServiceModel}"/></returns>
        /// <exception cref="CountryException"></exception>
        public List<CountryServiceModel> GetAllCountries()
        {
            var countries = _countryRepository.GetAll();

            if(countries == null)
            {
                throw new CountryException("There was an error while fetching countries list");
            }

            return CountryMapperProfile.CountryDtoToModel(countries);
        }

        /// <summary>
        ///     Inserts new country model in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="int"/></returns>
        /// <exception cref="CountryException"></exception>
        public int Create(CountryServiceModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new CountryException("Country name field cannot be empty.");
            }

            if(_countryRepository.GetAll().Any(x => x.Name == model.Name))
            {
                throw new CountryException("Country already exists in database.");
            }

            _countryRepository.Create(CountryMapperProfile.CountryModelToDto(model));
            return model.Id;
        }

        /// <summary>
        ///     Deletes country model from database
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="CountryException"></exception>
        public void Delete(int id)
        {
            if(_countryRepository.GetById(id) == null)
            {
                throw new CountryException($"Country with id: {id} doesn't exist.");
            }

            _countryRepository.Delete(id);
        }

        /// <summary>
        ///     Update country model in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns><see cref="CountryServiceModel"/></returns>
        /// <exception cref="CountryException"></exception>
        public CountryServiceModel Update(CountryServiceModel model)
        {
            var countryToUpdate = _countryRepository.GetById(model.Id);

            if(countryToUpdate == null)
            {
                throw new CountryException($"Country with id: {model.Id} doesn't exist");
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                throw new CountryException("Country name field cannot be empty");
            }

            countryToUpdate.Name = model.Name;

            var updatedCountry = _countryRepository.Update(countryToUpdate);
            return CountryMapperProfile.CountryDtoToModel(updatedCountry);
        }
    }
}
