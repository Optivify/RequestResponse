namespace Optivify.RequestResponse;

public interface IDataRequest<TData>
{
    TData? Data { get; }
}
