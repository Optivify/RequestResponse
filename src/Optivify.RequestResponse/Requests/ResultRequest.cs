using MediatR;
using Optivify.RequestResponse.Requests;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse
{
    public abstract class ResultRequest<TData> : IRequest<Result>, IRequestData<TData>
    {
        public TData? Data { get; set; }
    }

    public abstract class ResultRequest<TData, TResponse> : IRequest<Result<TResponse?>>, IRequestData<TData>
    {
        public TData? Data { get; set; }
    }
}
