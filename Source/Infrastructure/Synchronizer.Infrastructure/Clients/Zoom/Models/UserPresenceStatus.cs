using System.Text.Json.Serialization;

namespace Synchronizer.Infrastructure.Clients.Zoom.Models;

public class UserPresenceStatus
{
    /// <summary>
    /// The date and time at which the user's presence status was updated.
    /// </summary>
    [JsonPropertyName("date_time")]
    public DateTime StatusChangeDateTime { get; set; }
    /// <summary>
    /// The user's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }
    /// <summary>
    /// The user's ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string UserID { get; set; }
    /// <summary>
    /// Enum: "Available" "Away" "Do_Not_Disturb" "In_Meeting" "Presenting" "On_Phone_Call" "In_Calendar_Event"
    /// The user's presence status
    /// </summary>
    [JsonPropertyName("presence_status")]
    public string PresenceStatus { get; set; }
}