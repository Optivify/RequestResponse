using MediatR;
using Optivify.ServiceResult;

// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public interface IResultRequestHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse?>> where TCommand : IRequest<Result<TResponse?>>
{
}