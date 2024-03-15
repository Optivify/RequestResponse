namespace Optivify.RequestResponse;

public record EnumerableResponse<TData> : DataResponse<IEnumerable<TData>>
{
}
