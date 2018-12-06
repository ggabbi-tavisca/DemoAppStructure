using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Contracts
{
    public interface IBus
    {
        Task Publish<T>(T message, CancellationToken cancellationToken);
        Task Notify<T>(T message, CancellationToken cancellationToken);
    }
}
