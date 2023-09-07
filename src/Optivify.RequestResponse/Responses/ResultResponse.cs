using Optivify.ServiceResult;

namespace Optivify.RequestResponse;

public record ResultResponse : IResultResponse
{
    public bool IsSuccess { get; set; }

    public List<ValidationError>? ValidationErrors { get; set; }
}
