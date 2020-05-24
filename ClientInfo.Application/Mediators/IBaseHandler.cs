using MediatR;

namespace ClientInfo.Application.Mediators
{
    public interface IBaseHandler<T, K> : IRequestHandler<T, K> where T : IRequest<K>
    {
    }
}
