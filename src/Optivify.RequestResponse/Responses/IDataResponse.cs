// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public interface IDataResponse<TData>
{
    TData? Data { get; set; }
}