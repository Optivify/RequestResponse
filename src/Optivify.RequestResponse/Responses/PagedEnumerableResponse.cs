namespace Optivify.RequestResponse;

public record PagedEnumerableResponse<TData> : EnumerableResponse<TData>
{
    public PaginationData? Pagination { get; init; }
}
