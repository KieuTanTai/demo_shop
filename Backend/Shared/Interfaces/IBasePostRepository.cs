namespace Shared.Interfaces
{
    public interface IBasePostRepository<in T, TTypeId> where T : class
    {
        // 
        Task<TTypeId> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}