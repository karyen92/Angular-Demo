using System.Threading.Tasks;

namespace Demo.Framework.Mediators
{
    public interface IMediator
    {
        TResponse Send<TResponse>(IRequest<TResponse> request);
        Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request);
        void Publish<TNotification>(TNotification notification) where TNotification : INotification;
        Task PublishAsync<TNotification>(TNotification notification) where TNotification : IAsyncNotification;
    }
}
