namespace NewTestTwo.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
    }
}
