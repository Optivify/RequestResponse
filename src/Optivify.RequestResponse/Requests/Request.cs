using MediatR;

namespace Optivify.RequestResponse
{
    public abstract class Request : IRequest
    {
    }


    public interface IRequestData<TData>
    {
        TData? Data { get; set; }
    }

    public abstract class Request<TData> : Request, IRequest, IRequestData<TData>
    {
        public TData ?Data { get; set; }

        protected Request(TData data)
        {
            this.Data = data;
        }
    }
}