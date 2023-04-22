using Microsoft.EntityFrameworkCore;
using UsersAndCompaniesDataAccess.Entities;

namespace UsersAndCompaniesDataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly UsersAndCompaniesContext context;
        private DbSet<T> entities;

        public Repository(UsersAndCompaniesContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await entities.ToArrayAsync();

        public async Task<T?> GetAsync(Guid id)
            => await entities.SingleOrDefaultAsync(s => s.Id == id);

        public async Task<int> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await DeleteAsync(await GetAsync(id));
        }
    }
}
