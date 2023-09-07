namespace Optivify.RequestResponse;

public record PagedEnumerableResponse<T> : EnumerableResponse<T>
{
    public PaginationData? Pagination { get; set; }
}
