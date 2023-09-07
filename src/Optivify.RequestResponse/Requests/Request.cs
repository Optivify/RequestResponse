using MediatR;

namespace Optivify.RequestResponse;

public abstract record Request : IRequest;

public abstract record Request<TData> : Request, IRequest, IDataRequest<TData>
{
    public TData? Data { get; init; }

    protected Request(TData data)
    {
        this.Data = data;
    }
}