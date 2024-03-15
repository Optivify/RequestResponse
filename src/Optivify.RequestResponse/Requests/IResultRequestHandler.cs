using MediatR;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public interface IResultRequestHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse?>> where TCommand : IRequest<Result<TResponse?>>
{
}