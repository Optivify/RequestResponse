namespace Optivify.RequestResponse;

public class PagedListResponse<TData> : ListResponse<TData>
{
    public PaginationData? Pagination { get; set; }
}
