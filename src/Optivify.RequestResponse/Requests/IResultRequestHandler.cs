using MediatR;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public interface IResultRequestHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse?>> where TCommand : IRequest<Result<TResponse?>>
{
}
