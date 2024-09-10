// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public record DataResponse<TData> : IDataResponse<TData>
{
    public TData? Data { get; set; }
}