namespace Optivify.RequestResponse
{
    public class EnumerableResponse<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
