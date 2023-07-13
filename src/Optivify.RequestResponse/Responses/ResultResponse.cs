using Optivify.ServiceResult;

namespace Optivify.RequestResponse.Responses;

public class ResultResponse<T> : DataResponse<T?>, IValidationResponse
{
    public bool IsSuccess { get; set; }

    public List<ValidationError>? ValidationErrors { get; set; }
}
