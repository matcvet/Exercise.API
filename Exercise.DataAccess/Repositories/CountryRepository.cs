using Exercise.DataAccess.Abstraction;
using Exercise.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Exercise.DataAccess.Repositories
{
    public class CountryRepository : IRepository<CountryDto>
    {
        private readonly ExerciseDbContext _dbContext;

        public CountryRepository(ExerciseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CountryDto entity)
        {
            _dbContext.Countries.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Countries.SingleOrDefault(x => x.Id == id);
            _dbContext.Countries.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<CountryDto> GetAll()
        {
            return _dbContext.Countries.Include(x => x.Contacts);
        }

        public CountryDto GetById(int id)
        {
            return _dbContext.Countries.SingleOrDefault(x => x.Id == id);
        }

        public CountryDto Update(CountryDto entity)
        {
            _dbContext.Countries.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
