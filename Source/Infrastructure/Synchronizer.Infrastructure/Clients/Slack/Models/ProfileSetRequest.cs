using System.Text.Json.Serialization;

namespace Synchronizer.Infrastructure.Clients.Slack.Models;

public class ProfileSetRequest
{
    /// <summary>
    /// Collection of key:value pairs presented as a URL-encoded JSON hash
    /// </summary>
    [JsonPropertyName("profile")]
    public ProfileStatus ProfileStatus { get; set; }
}