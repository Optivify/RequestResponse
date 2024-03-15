using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public interface IRequestDispatcher : IDisposable
{
    Task DispatchAsync(Request request);

    Task DispatchAsync<TData>(Request<TData> request);

    Task<Result<TResponse>> DispatchAsync<TData, TResponse>(Request<TData, TResponse> request);
}

public class RequestDispatcher : IRequestDispatcher
{
    private readonly IServiceScope serviceScope;

    public RequestDispatcher(IServiceScopeFactory serviceScopeFactory)
    {
        this.serviceScope = serviceScopeFactory.CreateScope();
    }

    private IMediator GetMediator()
    {
        return (IMediator)serviceScope.ServiceProvider.GetRequiredService(typeof(IMediator));
    }

    public void Dispose()
    {
        this.serviceScope.Dispose();
    }

    public Task DispatchAsync(Request request)
    {
        return this.GetMediator().Send(request);
    }

    public Task DispatchAsync<TData>(Request<TData> request)
    {
        return this.GetMediator().Send(request);
    }

    public Task<Result<TResponse>> DispatchAsync<TData, TResponse>(Request<TData, TResponse> request)
    {
        return this.GetMediator().Send(request);
    }
}
