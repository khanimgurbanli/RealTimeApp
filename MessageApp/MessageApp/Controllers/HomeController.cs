using MessageApp.Business;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly HubBusiness _hubBusiness;

        public HomeController(HubBusiness hubBusiness)
        {
            _hubBusiness = hubBusiness;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _hubBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}
