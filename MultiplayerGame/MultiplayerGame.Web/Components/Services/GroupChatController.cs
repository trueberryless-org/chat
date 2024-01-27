namespace MultiplayerGame.Web.Components.Services;

public class GroupChatController : EventArgs, IDisposable, IAsyncDisposable
{
    public Guid ChatId { get; set; } = Guid.NewGuid();

    public List<Guid> Chatters { get; set; } = [];

    public ChatStatus Status { get; set; }

    public event EventHandler UpdateClients;
    private Timer timer;

    public GroupChatController()
    {
        Status = new ChatStatus();

        UpdateClients += HandleUpdateClients;
        timer = new Timer(RaiseEvent, null, 0, 500);
    }

    public void RaiseEvent(object? state)
    {
        UpdateClients.Invoke(this, this);
    }
    
    private void HandleUpdateClients(object sender, EventArgs e)
    {
        
    }

    public void Dispose()
    {
        timer.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await timer.DisposeAsync();
    }
}

public class GroupChatStatus
{
    public List<Message> Messages { get; set; } = [];
}