namespace Optivify.RequestResponse;

public record DataResponse<T> : IDataResponse<T>
{
    public T? Data { get; set; }
}
