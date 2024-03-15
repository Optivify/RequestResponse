using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public class Response<TData> : IResponse<TData>
{
    public TData? Data { get; set; }

    public bool IsSuccess { get; set; }

    public List<ValidationError>? ValidationErrors { get; set; }
}
