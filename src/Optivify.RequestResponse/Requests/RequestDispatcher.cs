using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Optivify.ServiceResult;

// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public interface IRequestDispatcher : IDisposable
{
    Task DispatchAsync(Request request);

    Task DispatchAsync<TData>(Request<TData> request);

    Task<Result<TResponse?>> DispatchAsync<TData, TResponse>(Request<TData, TResponse> request);
}

public class RequestDispatcher : IRequestDispatcher
{
    private readonly IServiceScope _serviceScope;

    public RequestDispatcher(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScope = serviceScopeFactory.CreateScope();
    }

    private IMediator GetMediator()
    {
        return (IMediator)_serviceScope.ServiceProvider.GetRequiredService(typeof(IMediator));
    }

    public void Dispose()
    {
        _serviceScope.Dispose();
    }

    public Task DispatchAsync(Request request)
    {
        return GetMediator().Send(request);
    }

    public Task DispatchAsync<TData>(Request<TData> request)
    {
        return GetMediator().Send(request);
    }

    public Task<Result<TResponse?>> DispatchAsync<TData, TResponse>(Request<TData, TResponse> request)
    {
        return GetMediator().Send(request);
    }
}