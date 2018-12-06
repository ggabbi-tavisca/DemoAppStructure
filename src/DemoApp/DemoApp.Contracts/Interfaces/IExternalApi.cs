using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Contracts
{
    public interface IExternalApi
    {
        Task<ApiResponse> GetResult(ApiRequest request, CancellationToken cancellationToken);
    }
}
