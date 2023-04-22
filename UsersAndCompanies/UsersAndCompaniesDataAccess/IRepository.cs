using UsersAndCompaniesDataAccess.Entities;

namespace UsersAndCompaniesDataAccess
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<int> DeleteAsync(T entity);

        Task<int> DeleteAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetAsync(Guid id);

        Task<int> InsertAsync(T entity);

        Task<int> UpdateAsync(T entity);
    }
}