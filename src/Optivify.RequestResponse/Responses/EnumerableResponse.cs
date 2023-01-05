namespace Optivify.RequestResponse
{
    public class EnumerableResponse<TItem>
    {
        public IEnumerable<TItem> Items { get; set; } = Enumerable.Empty<TItem>();
    }
}
