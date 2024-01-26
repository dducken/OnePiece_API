using Core.Application.Common.Interfaces;
using Core.Domain.Models;


namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed;
        
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<Character> Characters => new GenericRepository<Character>(_dbContext);
        public IGenericRepository<Pirate> Pirates => new GenericRepository<Pirate>(_dbContext);
        public IGenericRepository<Fruit> Fruits => new GenericRepository<Fruit>(_dbContext);
        public IGenericRepository<Rol> Roles => new GenericRepository<Rol>(_dbContext);
 
        
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private void Dispose(bool disposing)
        {
            if(!_disposed)
                if(disposing)
                    _dbContext.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}