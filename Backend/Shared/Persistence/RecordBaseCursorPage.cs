namespace Shared.Persistence
{
    public sealed record RecordBaseCursorPage<T>(
        IReadOnlyList<T> Items,
        Guid? NextCursor,
        bool IsHasMore);
}