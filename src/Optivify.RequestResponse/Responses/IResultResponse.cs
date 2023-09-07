using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public interface IResultResponse
{
    bool IsSuccess { get; set; }

    List<ValidationError>? ValidationErrors { get; set; }
}
