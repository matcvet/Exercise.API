using Exercise.DataAccess.Abstraction;
using Exercise.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Exercise.DataAccess.Repositories
{
    public class CompanyRepository : IRepository<CompanyDto>
    {
        private readonly ExerciseDbContext _dbContext;

        public CompanyRepository(ExerciseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CompanyDto entity)
        {
            _dbContext.Companies.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Companies.SingleOrDefault(x => x.Id == id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
        public IEnumerable<CompanyDto> GetAll()
        {
            return _dbContext.Companies.Include(x => x.Contacts);
        }

        public CompanyDto GetById(int id)
        {
            return _dbContext.Companies.SingleOrDefault(x => x.Id == id);
        }

        public CompanyDto Update(CompanyDto entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
