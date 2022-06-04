using System.Text.Json.Serialization;

namespace Synchronizer.Infrastructure.Clients.Zoom.Models;

public class UserPresenceStatusPayload
{
    /// <summary>
    /// The account ID of the user's account owner.
    /// </summary>
    [JsonPropertyName("account_id")]
    public string AccountID { get; set; }
    /// <summary>
    /// Information about the user.
    /// </summary>
    [JsonPropertyName("object")]
    public UserPresenceStatus UserStatus { get; set; }
}