namespace Identity.Interfaces.IRepository
{
    public interface IBaseAssociativeRepository<T, in TTypeId> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<T?> GetByIdAsync(TTypeId firstForeignId, TTypeId secondForeignId,
            CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(TTypeId firstForeignId, TTypeId secondForeignId,
            CancellationToken cancellationToken = default);

        Task<int> AddAsync(List<T> entities, CancellationToken cancellationToken = default);

        Task<int> DeleteByFirstForeignIdAsync(TTypeId firstForeignId, CancellationToken cancellationToken = default);
        Task<int> DeleteBySecondForeignIdAsync(TTypeId secondForeignId, CancellationToken cancellationToken = default);
        Task<int> DeleteAsync(TTypeId firstForeignId, TTypeId secondForeignId, CancellationToken cancellationToken = default);
    }
}