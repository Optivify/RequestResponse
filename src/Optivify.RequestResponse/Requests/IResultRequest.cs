using MediatR;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public interface IResultRequest<TData> : IRequest<Result>, IDataRequest<TData>
{
}

public interface IResultRequest<TData, TResponse> : IRequest<Result<TResponse?>>, IDataRequest<TData>
{
}
