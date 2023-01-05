using MediatR;

namespace Optivify.RequestResponse
{
    public abstract class Request : IRequest
    {
    }

    public abstract class Request<TData> : Request, IRequest
    {
        public TData Data { get; set; }

        protected Request(TData data)
        {
            this.Data = data;
        }
    }
}