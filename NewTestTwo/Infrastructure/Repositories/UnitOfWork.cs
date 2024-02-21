using NewTestTwo.DbContexts;

namespace NewTestTwo.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TournamentTrackerContext _context;

        public UnitOfWork(TournamentTrackerContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
