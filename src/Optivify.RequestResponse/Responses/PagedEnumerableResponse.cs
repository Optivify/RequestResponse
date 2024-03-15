namespace Optivify.RequestResponse;

public class PagedEnumerableResponse<TData> : EnumerableResponse<TData>
{
    public PaginationData? Pagination { get; set; }
}
