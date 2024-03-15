namespace Optivify.RequestResponse;

public record PaginationData
{
    public int Page { get; init; }

    public int ItemsPerPage { get; init; }

    public long TotalCount { get; init; }

    public int TotalPages
    {
        get
        {
            if (ItemsPerPage <= 0)
            {
                return 1;
            }

            return (int)Math.Ceiling((double)TotalCount / ItemsPerPage);
        }
    }

    public bool HasPreviousPage => Page > 1;

    public bool HasNextPage => Page < TotalPages;
}
