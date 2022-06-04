using Microsoft.AspNetCore.Mvc;
using Synchronizer.Infrastructure.Clients.Slack;
using Synchronizer.Infrastructure.Clients.Zoom.Models;

namespace Synchronizer.Web.Service.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ZoomController : ControllerBase
{
    private readonly ISlackClient _client;

    public ZoomController(ISlackClient client) => _client = client;

    [HttpPost]
    public async Task<ActionResult> Status([FromBody] UserPresenceStatusChangeEvent @event)
    {
        bool clearStatus = @event.EventPayload.UserStatus.PresenceStatus != "In_Meeting";
        await _client.SetStatus(clearStatus);
        return Ok();
    }
}