using Optivify.ServiceResult;

namespace Optivify.RequestResponse.Responses;

public interface IResultResponse
{
    bool IsSuccess { get; set; }

    List<ValidationError>? ValidationErrors { get; set; }
}
