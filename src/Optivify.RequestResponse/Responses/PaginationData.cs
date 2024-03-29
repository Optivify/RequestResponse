﻿namespace Optivify.RequestResponse;

public class PaginationData
{
    public int Page { get; set; }

    public int ItemsPerPage { get; set; }

    public long TotalCount { get; set; }

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
