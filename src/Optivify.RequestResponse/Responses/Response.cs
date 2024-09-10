using Optivify.ServiceResult;

// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public record Response<TData> : IResponse<TData>
{
    public TData? Data { get; set; }

    public bool IsSuccess { get; set; }

    public string? Message { get; set; }

    public List<ValidationError>? ValidationErrors { get; set; }
}