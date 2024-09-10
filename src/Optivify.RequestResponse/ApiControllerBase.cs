using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public abstract class ApiControllerBase : ControllerBase
{
    protected IRequestDispatcher? _requestDispatcher;

    protected IRequestDispatcher RequestDispatcher
    {
        get
        {
            if (_requestDispatcher is null)
            {
                _requestDispatcher = HttpContext.RequestServices.GetRequiredService<IRequestDispatcher>();
                HttpContext.Response.RegisterForDispose(_requestDispatcher);
            }

            return _requestDispatcher;
        }
    }

    protected Task DispatchAsync(Request request)
    {
        return RequestDispatcher.DispatchAsync(request);
    }

    protected Task DispatchAsync<TData>(Request<TData> request)
    {
        return RequestDispatcher.DispatchAsync(request);
    }

    protected Task<Result<TResponse?>> DispatchAsync<TData, TResponse>(Request<TData, TResponse> request)
    {
        return RequestDispatcher.DispatchAsync(request);
    }
}