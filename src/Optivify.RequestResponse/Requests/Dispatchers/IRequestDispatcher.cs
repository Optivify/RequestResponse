using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public interface IRequestDispatcher : IDisposable
{
    Task DispatchAsync(Request request);

    Task DispatchAsync<TData>(Request<TData> request);

    Task<Result> DispatchAsync<TData>(ResultRequest<TData> request);

    Task<Result<TResponse?>> DispatchAsync<TData, TResponse>(ResultRequest<TData, TResponse> request);
}