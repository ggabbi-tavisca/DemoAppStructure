using DemoApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApp.Core.Services
{
    public class DemoService : IDemoService
    {
        private readonly IDemoApp _demoApp;
        private readonly IValidator _validator;
        public DemoService(IDemoApp demoApp, IValidator validator)
        {
            _demoApp = demoApp;
            _validator = validator;
        }
        public async Task<ResultResponse> GetResult(ResultRequest request, CancellationToken cancellationToken)
        {
            return await _demoApp.GetResult(request, cancellationToken);
        }

        public async Task<InitResponse> Init(InitRequest request, CancellationToken cancellationToken)
        {
            if (_validator.Validate(request) == false)
                throw new Exception();

            return await _demoApp.Init(request, cancellationToken);
        }
    }
}
