using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoApp.Contracts;
using System.Threading;

namespace DemoApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDemoService _demoService;
        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }
        [HttpPost][Route("init")]
        public async Task<IActionResult> Init([FromBody] InitRequest request, CancellationToken cancellationToken)
        {
            var response = await _demoService.Init(request, cancellationToken);

            return Ok(response);
        }
        [HttpPost]
        [Route("getresult")]
        public async Task<IActionResult> GetResult([FromBody] ResultRequest request, CancellationToken cancellationToken)
        {
            var response = await _demoService.GetResult(request, cancellationToken);

            return Ok(response);
        }
    }
}