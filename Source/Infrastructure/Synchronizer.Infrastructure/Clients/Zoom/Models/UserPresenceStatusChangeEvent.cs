using System.Text.Json.Serialization;

namespace Synchronizer.Infrastructure.Clients.Zoom.Models;

public class UserPresenceStatusChangeEvent
{
    /// <summary>
    /// The name of the event.
    /// </summary>
    [JsonPropertyName("event")]
    public string EventName { get; set; }
    /// <summary>
    /// A timestamp at which the event occurred.
    /// </summary>
    [JsonPropertyName("event_ts")]
    public long EventDateTimeTicks { get; set; }
    /// <summary>
    /// Payload data for the event
    /// </summary>
    [JsonPropertyName("payload")]
    public UserPresenceStatusPayload EventPayload { get; set; }
}