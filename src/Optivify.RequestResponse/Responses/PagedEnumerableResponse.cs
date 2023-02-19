namespace Optivify.RequestResponse
{
    public class PagedEnumerableResponse<T> : EnumerableResponse<T>
    {
        public PaginationData? Pagination { get; set; }
    }
}
