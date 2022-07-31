using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Complete.Hubs;

namespace SignalR_Complete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        //Provide hub context to access SignalR via custom API endpoints
        private readonly IHubContext<InformHub> HubCtxt;

        public MessageController(IHubContext<InformHub> HubCtxt)
        {
            this.HubCtxt = HubCtxt;
        }

        [HttpGet("UpdateClient")]
        public async Task<IActionResult> UpdateClient(string group, string clientHandlerMethod, string msg)
        {
            await HubCtxt.Clients.Groups(group).SendAsync(clientHandlerMethod, msg);
            return Ok();
        }
    }
}
