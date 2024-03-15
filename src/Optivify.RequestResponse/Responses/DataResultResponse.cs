using Optivify.ServiceResult;

namespace Optivify.RequestResponse.Responses;

public class DataResultResponse<T> : IDataResultResponse<T>
{
    public bool IsSuccess { get; set; }

    public T? Data { get; set; }

    public List<ValidationError>? ValidationErrors { get; set; }
}
