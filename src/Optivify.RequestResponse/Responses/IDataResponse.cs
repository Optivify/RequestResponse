namespace Optivify.RequestResponse;

public interface IDataResponse<T>
{
    T? Data { get; set; }
}
