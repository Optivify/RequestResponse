using Optivify.RequestResponse;

namespace Optivify.RequestResponse;

public record EnumerableResponse<T> : DataResponse<IEnumerable<T>>;
