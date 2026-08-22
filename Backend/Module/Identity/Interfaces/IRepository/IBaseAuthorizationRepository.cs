using Shared.Interfaces;

namespace Identity.Interfaces.IRepository
{
    public interface IBaseAuthorizationRepository<T, TTypeId> : IBaseReadRepository<T>, IBasePostRepository<T, TTypeId>
        where T : class
    {
        Task<IReadOnlyList<T>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetByDescriptionAsync(string description, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetByActiveStatus(bool isActive, CancellationToken cancellationToken = default);
    }
}