using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Synchronizer.Infrastructure.Clients.Slack.Models;

namespace Synchronizer.Infrastructure.Clients.Slack;

public interface ISlackClient
{
    Task SetStatus(bool clearStatus);
}

public class SlackClient : ISlackClient
{
    public async Task SetStatus(bool clearStatus)
    {
        using HttpClient client = new();
        client.BaseAddress = new Uri("https://slack.com");
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "oauth_token_goes_here");
        ProfileSetRequest request = new()
        {
            ProfileStatus = new ProfileStatus
            {
                StatusText = clearStatus ? string.Empty : "In Zoom Meeting",
                StatusEmoji = clearStatus ? string.Empty : ":zoom:",
                StatusExpiration = Convert.ToInt32(clearStatus)
            }
        };
        using StringContent payload = new(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        await client.PostAsync(Endpoints.SetProfile, payload);
    }
    
    private struct Endpoints
    {
        public const string SetProfile = "api/users.profile.set";
    }
}