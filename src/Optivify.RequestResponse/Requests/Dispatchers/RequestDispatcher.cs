using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public class RequestDispatcher : IRequestDispatcher
{
    private readonly IServiceScope serviceScope;

    private bool disposed = false;

    public RequestDispatcher(IServiceScopeFactory serviceScopeFactory)
    {
        this.serviceScope = serviceScopeFactory.CreateScope();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~RequestDispatcher()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                this.serviceScope.Dispose();
            }

            disposed = true;
        }
    }

    private IMediator GetMediator()
    {
        return (IMediator)this.serviceScope.ServiceProvider.GetRequiredService(typeof(IMediator));
    }

    public Task DispatchAsync(Request request)
    {
        return this.GetMediator().Send(request);
    }

    public Task DispatchAsync<TData>(Request<TData> request)
    {
        return this.GetMediator().Send(request);
    }

    public Task<Result> DispatchAsync<TData>(ResultRequest<TData> request)
    {
        return this.GetMediator().Send(request);
    }

    public Task<Result<TResponse?>> DispatchAsync<TData, TResponse>(ResultRequest<TData, TResponse> request)
    {
        return this.GetMediator().Send(request);
    }
}
