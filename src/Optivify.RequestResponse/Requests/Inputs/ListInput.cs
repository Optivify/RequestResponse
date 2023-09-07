using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Optivify.RequestResponse;

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
    public virtual int Skip
    {
        get { return this.ItemsPerPage * (this.Page - 1); }
    }

    [NotMapped]
    [JsonIgnore]
    public virtual int Take
    {
        get { return this.ItemsPerPage; }
    }
}
