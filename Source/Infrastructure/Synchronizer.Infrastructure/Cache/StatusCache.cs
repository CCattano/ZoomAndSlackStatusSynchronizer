namespace Synchronizer.Infrastructure.Cache;

public interface IStatusCache
{
    /// <summary>
    /// The status received from Zoom. Captured for logging purposes
    /// </summary>
    string ReceivedStatus { get; }

    /// <summary>
    /// Specify the value of the ReceivedStatus
    /// </summary>
    /// <param name="status"></param>
    void SetReceivedStatus(string status);
}

public class StatusCache : IStatusCache
{
    public string ReceivedStatus { get; private set; }

    public void SetReceivedStatus(string status) => ReceivedStatus = status;
}