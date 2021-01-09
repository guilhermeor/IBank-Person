using MediatR;

namespace Person.Application.Mediators
{
    public interface IBaseHandler<T, K> : IRequestHandler<T, K> where T : IRequest<K>
    {
    }
}
