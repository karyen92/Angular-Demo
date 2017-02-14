using System.Threading.Tasks;

namespace Demo.Framework.Mediators
{
    public interface IRequestHandler<in TRequest, out TResponse>
  where TRequest : IRequest<TResponse>
    {
        TResponse Handle(TRequest message);
    }

    public interface IAsyncRequestHandler<in TRequest, TResponse>
        where TRequest : IAsyncRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest message);
    }

    public interface INotificationHandler<in TNotification>
        where TNotification : INotification
    {
        void Handle(TNotification notification);
    }

    public interface IAsyncNotificationHandler<in TNotification>
        where TNotification : IAsyncNotification
    {
        Task Handle(TNotification notification);
    }
}
