using Optivify.ServiceResult;

// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public interface IResultResponse
{
    bool IsSuccess { get; set; }

    string? Message { get; set; }

    List<ValidationError>? ValidationErrors { get; set; }
}