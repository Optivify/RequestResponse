using Optivify.ServiceResult;

namespace Optivify.RequestResponse.Responses;

public interface IValidationResponse
{
    bool IsSuccess { get; set; }

    List<ValidationError>? ValidationErrors { get; set; }
}
