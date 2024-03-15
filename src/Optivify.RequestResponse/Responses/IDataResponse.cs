namespace Optivify.RequestResponse;

public interface IDataResponse<TData>
{
    TData? Data { get; set; }
}
