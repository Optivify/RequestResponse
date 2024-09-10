// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public record PagedListResponse<TData> : ListResponse<TData>
{
    public PaginationData? Pagination { get; set; }
}