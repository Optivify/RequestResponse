namespace Optivify.RequestResponse
{
    public class PagedListResponse<TItem> : EnumerableResponse<TItem>
    {
        public PaginationData? Pagination { get; set; }
    }
}
