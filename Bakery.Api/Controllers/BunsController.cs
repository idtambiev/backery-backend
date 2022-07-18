using Bakery.Api.SignalR;
using Bakery.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Bakery.Api.Controllers
{
    [Route("api/buns")]
    [ApiController]
    public class BunsController : ControllerBase
    {
        private readonly IBunService _service;
        private readonly IHubContext<BunsHub> _hub;
        private readonly TimerManager _timer;

        public BunsController(IBunService service, IHubContext<BunsHub> hub, TimerManager timer)
        {
            _service = service;
            _hub = hub;
            _timer = timer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBuns()
        {
            var result = await _service.GetAll();
            if (!_timer.IsTimerStarted)
                _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("TransferChartData", result));
            return Ok(new { Message = "Request Completed" });
        }

        [HttpGet]
        [Route("create-new-buns")]
        public async Task<IActionResult> CreateNewBuns([FromQuery] int count)
        {
            var result = await _service.CreateNewBuns(count);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
