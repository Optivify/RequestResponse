using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Optivify.RequestResponse;

public interface IListInput
{
    string? SearchText { get; }

    int Page { get; }

    int ItemsPerPage { get; }

    string? SortBy { get; }

    bool SortDesc { get; }

    int Skip { get; }

    int Take { get; }

    PaginationData CreatePagination(long totalCount);
}

public record ListInput : IListInput
{
    public virtual string? SearchText { get; init; }

    public virtual int Page { get; init; } = 1;

    public virtual int ItemsPerPage { get; init; } = 10;

    public virtual string? SortBy { get; init; }

    public virtual bool SortDesc { get; init; }

    public virtual bool PaginationEnabled { get; init; } = true;

    [NotMapped]
    [JsonIgnore]
    public virtual int Skip => ItemsPerPage * (Page - 1);

    [NotMapped]
    [JsonIgnore]
    public virtual int Take => ItemsPerPage;

    public PaginationData CreatePagination(long totalCount) => new()
    {
        Page = Page,
        ItemsPerPage = ItemsPerPage,
        TotalCount = totalCount
    };
}
