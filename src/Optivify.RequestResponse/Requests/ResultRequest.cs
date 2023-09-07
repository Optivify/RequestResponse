namespace Optivify.RequestResponse;

public abstract record ResultRequest<TData> : IResultRequest<TData>
{
    public TData? Data { get; init; }
}

public abstract record ResultRequest<TData, TResponse> : IResultRequest<TData, TResponse>
{
    public TData? Data { get; init; }
}
