using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Contracts
{
    public interface IDemoService
    {
        Task<InitResponse> Init(InitRequest request, CancellationToken cancellationToken);
        Task<ResultResponse> GetResult(ResultRequest request, CancellationToken cancellationToken);
    }
}
