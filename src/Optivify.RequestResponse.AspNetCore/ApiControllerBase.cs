using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Optivify.ServiceResult;

namespace Optivify.RequestResponse.AspNetCore
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IRequestDispatcher? requestDispatcher;

        protected IRequestDispatcher RequestDispatcher
        {
            get
            {
                if (this.requestDispatcher is null)
                {
                    this.requestDispatcher = base.HttpContext.RequestServices.GetRequiredService<IRequestDispatcher>();
                    base.HttpContext.Response.RegisterForDispose(this.requestDispatcher);
                }

                return this.requestDispatcher;
            }
        }

        protected Task DispatchAsync(Request request)
        {
            return this.RequestDispatcher.DispatchAsync(request);
        }

        protected Task DispatchAsync<TData>(Request<TData> request)
        {
            return this.RequestDispatcher.DispatchAsync(request);
        }

        protected Task<Result> DispatchAsync<TData>(ResultRequest<TData> request)
        {
            return this.RequestDispatcher.DispatchAsync(request);
        }

        protected Task<Result<TResponse>> DispatchAsync<TData, TResponse>(ResultRequest<TData, TResponse> request)
        {
            return this.RequestDispatcher.DispatchAsync(request);
        }
    }
}