namespace Optivify.RequestResponse.Responses;

public class DataResponse<T> : IDataResponse<T>
{
    public T? Data { get; set; }
}
