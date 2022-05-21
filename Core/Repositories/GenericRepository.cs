using Lesson1.Core.IRepository;
using Lesson1.Data;
using Microsoft.EntityFrameworkCore;

namespace Lesson1.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {   
        protected AppDbContext context;
        protected DbSet<T> dbset;

        protected ILogger logger;
        public GenericRepository(AppDbContext _dbcontext,
                                    ILogger _logger)
        {
            context = _dbcontext;
            logger = _logger;
            this.dbset = _dbcontext.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            await dbset.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<IEnumerable<T>> GetALL()
        {
            return await dbset.ToListAsync();
        }

        public async virtual Task<T> GetByID(Guid id)
        {
           return await dbset.FindAsync(id);
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}