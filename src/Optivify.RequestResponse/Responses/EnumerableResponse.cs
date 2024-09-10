// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public record EnumerableResponse<TData> : Response<IEnumerable<TData>>;