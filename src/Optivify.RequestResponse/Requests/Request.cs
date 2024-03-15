using MediatR;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public abstract class Request : IRequest
{
}

public interface IDataRequest<TData>
{
    TData? Data { get; set; }
}

public abstract class Request<TData> : Request, IDataRequest<TData>
{
    public TData? Data { get; set; }

    protected Request(TData data)
    {
        this.Data = data;
    }
}

public abstract class Request<TData, TResponse> : IRequest<Result<TResponse?>>, IDataRequest<TData>
{
    public TData? Data { get; set; }
}
