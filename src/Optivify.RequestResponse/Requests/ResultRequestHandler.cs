using MediatR;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse
{
    public abstract class ResultRequestHandler<TCommand, TResponse> : IResultRequestHandler<TCommand, TResponse?> where TCommand : IRequest<Result<TResponse?>>
    {
        public abstract Task<Result<TResponse?>> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
