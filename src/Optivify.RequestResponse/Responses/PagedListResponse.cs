namespace Optivify.RequestResponse;

public class PagedListResponse<T> : ListResponse<T>
{
    public PaginationData? Pagination { get; set; }
}
