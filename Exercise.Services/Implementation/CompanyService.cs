using AutoMapper;
using Exercise.DataAccess.Abstraction;
using Exercise.DataModels;
using Exercise.Exceptions;
using Exercise.ServiceModels;
using Exercise.Services.Abstraction;

namespace Exercise.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<CompanyDto> _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(IRepository<CompanyDto> companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///     Returns company with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="CompanyServiceModel"/></returns>
        /// <exception cref="CompanyException"></exception>
        public CompanyServiceModel GetCompanyById(int id)
        {
            var company = _companyRepository.GetById(id);

            if(company == null)
            {
                throw new CompanyException($"Company with id: ${id} doesn't exist.");
            }

            return _mapper.Map<CompanyServiceModel>(company);
        }

        /// <summary>
        ///     Returns a list of all companies
        /// </summary>
        /// <returns><see cref="List{CompanyServiceModel}"/></returns>
        /// <exception cref="CompanyException"></exception>
        public List<CompanyServiceModel> GetAllCompanies()
        {
            var companies = _companyRepository.GetAll();

            if(companies == null)
            {
                throw new CompanyException("Something went wrong while fetchig all companies");
            }

            return _mapper.Map<List<CompanyServiceModel>>(companies);
        }

        /// <summary>
        ///     Inserts new company model in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="CompanyException"></exception>
        public int Create(CompanyServiceModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new CompanyException("Company name field is required.");
            }

            if(_companyRepository.GetAll().Any(x => x.Name == model.Name))
            {
                throw new CompanyException("Company already exists in database.");
            }

            _companyRepository.Create(_mapper.Map<CompanyDto>(model));
            return model.Id;
        }

        /// <summary>
        ///     Delete company model by given id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="CompanyException"></exception>
        public void Delete(int id)
        {
            if(_companyRepository.GetById(id) == null)
            {
                throw new CompanyException($"Company with id: {id} doesn't exist.");
            }

            _companyRepository.Delete(id);
        }

        /// <summary>
        ///     Update company model in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="CompanyException"></exception>
        public CompanyServiceModel Update(CompanyServiceModel model)
        {
            var companyToUpdate = _companyRepository.GetById(model.Id);

            if (companyToUpdate == null)
            {
                throw new CompanyException($"Company doesn't exist.");
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                throw new CompanyException("Country name field is required.");
            }

            companyToUpdate.Name = model.Name;

            var updatedCompany = _companyRepository.Update(companyToUpdate);
            return _mapper.Map<CompanyServiceModel>(updatedCompany);
        }
    }
}
