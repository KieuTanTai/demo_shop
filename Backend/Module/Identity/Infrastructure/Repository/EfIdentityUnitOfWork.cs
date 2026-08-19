using Identity.Infrastructure.Persistence.DBContext;
using Shared.Interfaces;

namespace Identity.Infrastructure.Repository
{
    public sealed class EfIdentityUnitOfWork(IdentityDbContext context) : IUnitOfWork
    {
        private readonly IdentityDbContext _context = context;  
        
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();
    }
}