using System.Diagnostics.CodeAnalysis;
using MediatR;
using Optivify.ServiceResult;

// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public abstract record Request : IRequest;

public interface IDataRequest<TData>
{
    [NotNullIfNotNull(nameof(Data))]
    TData? Data { get; init; }
}

public abstract record Request<TData> : Request, IDataRequest<TData>
{
    [NotNullIfNotNull(nameof(Data))]
    public TData? Data { get; init; }

    protected Request(TData data)
    {
        Data = data;
    }
}

public abstract record Request<TData, TResponse> : IRequest<Result<TResponse?>>, IDataRequest<TData>
{
    [NotNullIfNotNull(nameof(Data))]
    public TData? Data { get; init; }
}