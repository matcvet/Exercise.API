using Exercise.DataAccess.Abstraction;
using Exercise.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Exercise.DataAccess.Repositories
{
    public class ContactRepository : IRepository<ContactDto>
    {
        private readonly ExerciseDbContext _dbContext;

        public ContactRepository(ExerciseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(ContactDto entity)
        {
            _dbContext.Contacts.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ContactDto> GetAll()
        {
            return _dbContext.Contacts
                .Include(x => x.Company)
                .Include(y => y.Country);
        }

        public ContactDto GetById(int id)
        {
            var contact = _dbContext.Contacts.SingleOrDefault(x => x.Id == id);
            return contact;
        }

        public ContactDto Update(ContactDto entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
