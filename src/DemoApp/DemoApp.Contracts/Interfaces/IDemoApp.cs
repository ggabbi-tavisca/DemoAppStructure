using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Contracts
{
    public interface IDemoApp
    {
        Task<InitResponse> Init(InitRequest request, CancellationToken cancellationToken);
        Task<ResultResponse> GetResult(ResultRequest request, CancellationToken cancellationToken);
        Task Process(InitRequest request, CancellationToken cancellationToken);
    }
}
