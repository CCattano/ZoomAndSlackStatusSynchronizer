using Microsoft.AspNetCore.Mvc;
using Synchronizer.Infrastructure.Cache;
using Synchronizer.Infrastructure.Clients.Slack;
using Synchronizer.Infrastructure.Clients.Zoom.Models;

namespace Synchronizer.Web.Service.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ZoomController : ControllerBase
{
    private readonly ISlackClient _client;
    private readonly IStatusCache _status;

    public ZoomController(ISlackClient client, IStatusCache status)
    {
        _client = client;
        _status = status;
    }

    [HttpPost]
    public async Task<ActionResult> Status([FromBody] UserPresenceStatusChangeEvent @event)
    {
        _status.SetReceivedStatus(@event.EventPayload.UserStatus.PresenceStatus);
        bool clearStatus = @event.EventPayload.UserStatus.PresenceStatus != "In_Meeting";
        await _client.SetStatus(clearStatus);
        return Ok();
    }
}