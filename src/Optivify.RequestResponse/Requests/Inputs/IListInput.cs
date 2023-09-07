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
}