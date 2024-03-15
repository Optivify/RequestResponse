using MediatR;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public abstract record Request : IRequest
{
}

public interface IDataRequest<TData>
{
    TData? Data { get; init; }
}

public abstract record Request<TData> : Request, IDataRequest<TData>
{
    public TData? Data { get; init; }

    protected Request(TData data)
    {
        this.Data = data;
    }
}

public abstract record Request<TData, TResponse> : IRequest<Result<TResponse?>>, IDataRequest<TData>
{
    public TData? Data { get; init; }
}
