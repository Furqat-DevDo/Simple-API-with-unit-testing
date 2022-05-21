using Lesson1.Core.IRepository;
using Lesson1.Data;
using Lesson1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson1.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext _dbcontext, ILogger _logger) :
        base(_dbcontext, _logger){}

        public override async Task<IEnumerable<User>> GetALL()
        {
            try
            {
                return await dbset.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return new List<User>();
            }
        }

        public override async Task<bool> Update(User entity)
        {
           try
           {
                var exist = await dbset.FirstOrDefaultAsync(p=>p.ID == entity.ID);
                if(exist==null)
                {
                    await dbset.AddAsync(entity);
                    return true;
                }
                exist.Age=entity.Age;
                exist.Email=entity.Email;
                exist.Name=entity.Name;
                exist.LastName=entity.LastName;
                return true;
           }
           catch (System.Exception ex)
           {
                logger.LogError(ex.Message);
                return false;
           }
        }

        public override async Task<bool> Delete(Guid id)
        {
           try
           {
                var exists = await dbset.FirstOrDefaultAsync(p=>p.ID == id);
                if(exists==null)
                {
                    return false;
                }
                dbset.Remove(exists);
                return true;
           }
           catch (System.Exception ex)
           {
                logger.LogError(ex.Message);
                return false;
           }
        }

    }
}