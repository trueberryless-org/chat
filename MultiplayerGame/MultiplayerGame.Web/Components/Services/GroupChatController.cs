namespace MultiplayerGame.Web.Components.Services;

public class GroupChatController : EventArgs, IDisposable, IAsyncDisposable
{
    public Guid ChatId { get; set; } = Guid.NewGuid();

    public List<Person> Chatters { get; set; } = [];

    public GroupChatStatus Status { get; set; }

    public event EventHandler UpdateClients;
    private Timer timer;

    public GroupChatController()
    {
        Status = new GroupChatStatus();

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
    public List<GroupMessage> Messages { get; set; } = [];
}

public class GroupMessage
{
    public Person Chatter { get; set; }
    public string Content { get; set; }
    public DateTime Posted { get; set; }
}

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}