namespace Shared.Interfaces
{
    public interface IBasePostRepository<in T> where T : class
    {
        // 
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}