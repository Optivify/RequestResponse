using Optivify.RequestResponse.Responses;

namespace Optivify.RequestResponse;

public record PagedListResponse<T> : ListResponse<T>
{
    public PaginationData? Pagination { get; set; }
}
