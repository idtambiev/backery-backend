using Bakery.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bakery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BunController : ControllerBase
    {
        private readonly IBunService _service;

        public BunController(IBunService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllBuns()
        {
            return Ok();
        }

        [HttpGet]
        [Route("create-new-buns")]
        public async Task<IActionResult> CreateNewBuns([FromQuery]int count)
        {
            return Ok();
        }
    }
}
