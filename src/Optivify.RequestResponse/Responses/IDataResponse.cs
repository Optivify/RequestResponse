namespace Optivify.RequestResponse.Responses;

public interface IDataResponse<T>
{
    T? Data { get; set; }
}
