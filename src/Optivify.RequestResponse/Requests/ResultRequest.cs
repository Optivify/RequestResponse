using MediatR;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse
{
    public abstract class ResultRequest<TData> : IRequest<Result>
    {
        public TData? Data { get; set; }
    }

    public abstract class ResultRequest<TData, TResponse> : IRequest<Result<TResponse>>
    {
        public TData? Data { get; set; }
    }
}
