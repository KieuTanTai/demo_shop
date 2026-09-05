namespace Shared.Persistence.Record
{
    public sealed record RecordBaseCursorPage<T>(
        IReadOnlyList<T> Items,
        Guid? NextCursor,
        bool IsHasMore);
}