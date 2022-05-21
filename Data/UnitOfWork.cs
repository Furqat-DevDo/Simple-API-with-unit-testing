using Lesson1.Core.IConfiguration;
using Lesson1.Core.IRepository;
using Lesson1.Core.Repositories;

namespace Lesson1.Data
{
    public class UnitOfWork : IUnitofWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(AppDbContext context , 
                            ILoggerFactory logger)
        {
           _context= context;
           _logger= logger.CreateLogger("logs");
           Users = new UserRepository(_context,_logger);
        }
        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}