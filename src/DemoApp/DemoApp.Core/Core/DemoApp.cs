using DemoApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Core.Core
{
    public class DemoApp : IDemoApp
    {
        private readonly IStateProvider _stateProvider;
        private readonly IBus _bus;
        private readonly IExternalApi _externalApi;
        public DemoApp(IStateProvider stateProvider, IBus bus, IExternalApi externalApi)
        {
            _stateProvider = stateProvider;
            _bus = bus;
            _externalApi = externalApi;
        }
        public async Task<ResultResponse> GetResult(ResultRequest request, CancellationToken cancellationToken)
        {
            return await _stateProvider.Get<ResultResponse>(request.Token, cancellationToken);
        }

        public async Task<InitResponse> Init(InitRequest request, CancellationToken cancellationToken)
        {
            var identifier = Guid.NewGuid().ToString();
            request.Id = identifier;

            await _stateProvider.Save(request, cancellationToken);

            await _bus.Publish(request, cancellationToken);

            return new InitResponse { Token = identifier };
        }

        public async Task Process(InitRequest request, CancellationToken cancellationToken)
        {
            var apiRequest = new ApiRequest { };
            var response = _externalApi.GetResult(apiRequest, cancellationToken);

            await _stateProvider.Save(response, cancellationToken);
        }
    }
}
