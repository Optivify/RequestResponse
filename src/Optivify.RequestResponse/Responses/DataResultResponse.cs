using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public record DataResultResponse<T> : DataResponse<T?>, IResultResponse
{
    public bool IsSuccess { get; set; }

    public List<ValidationError>? ValidationErrors { get; set; }
}
