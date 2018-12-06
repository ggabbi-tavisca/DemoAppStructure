using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Contracts
{
    public interface IStateProvider
    {
        Task<T> Get<T>(string key, CancellationToken cancellationToken);
        Task Save<T>(T obj, CancellationToken cancellationToken);
    }
}
