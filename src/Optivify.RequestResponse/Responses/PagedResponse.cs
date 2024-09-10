// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public record PagedResponse<TData> : EnumerableResponse<TData>
{
    public PaginationData? Pagination { get; init; }
}
