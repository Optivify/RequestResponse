namespace Optivify.RequestResponse
{
    public class ListResponse<T>
    {
        public IList<T> Items { get; set; } = new List<T>();
    }
}
