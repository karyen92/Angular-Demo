namespace Demo.Framework.Mediators
{
    public interface IRequest<out TResponse> { }
    public interface IAsyncRequest<out TResponse> { }
    public interface INotification { }
    public interface IAsyncNotification { }
}
