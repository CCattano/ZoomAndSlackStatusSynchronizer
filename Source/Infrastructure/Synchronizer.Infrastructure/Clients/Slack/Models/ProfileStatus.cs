using System.Text.Json.Serialization;

namespace Synchronizer.Infrastructure.Clients.Slack.Models;

public class ProfileStatus
{
    /// <summary>
    /// The text to be displayed as a user's status
    /// </summary>
    [JsonPropertyName("status_text")]
    public string StatusText { get; set; }

    /// <summary>
    /// An emoji to be displayed with the status
    /// </summary>
    [JsonPropertyName("status_emoji")]
    public string StatusEmoji { get; set; }

    /// <summary>
    /// When the status should expire in seconds
    /// </summary>
    [JsonPropertyName("status_expiration")]
    public int StatusExpiration { get; set; }
}