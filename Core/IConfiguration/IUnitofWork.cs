using Lesson1.Core.IRepository;

namespace Lesson1.Core.IConfiguration
{
    public interface IUnitofWork
    {
         IUserRepository Users{ get;}

         Task CompleteAsync();
    }
}