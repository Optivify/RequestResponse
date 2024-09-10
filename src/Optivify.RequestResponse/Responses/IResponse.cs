// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public interface IResponse
{
}

public interface IResponse<TData> : IDataResponse<TData>, IResultResponse, IResponse
{
}