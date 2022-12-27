namespace Exercise.DataAccess.Abstraction
{
    public interface IRepository<T>
    {
        T GetById(int id);
        int Create(T entity);
        T Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
