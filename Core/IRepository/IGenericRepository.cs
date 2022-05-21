namespace Lesson1.Core.IRepository
{
    public interface IGenericRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetALL();

        Task<T> GetByID(Guid id);

        Task<bool> Add(T entity);

        Task<bool>Delete(Guid id);

        Task<bool> Update(T entity);
    }
}