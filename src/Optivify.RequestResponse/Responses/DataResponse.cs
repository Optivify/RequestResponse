namespace Optivify.RequestResponse;

public class DataResponse<TData> : IDataResponse<TData>
{
    public TData? Data { get; set; }
}
