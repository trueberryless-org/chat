using Microsoft.AspNetCore.SignalR;

namespace MultiplayerGame.Web.Components.Services;

public class MatchmakingGroupChat
{
    public GroupChatController GroupChat { get; set; } = new GroupChatController();

    public Guid JoinGroupChat(string name, int age)
    {
        var chatterId = Guid.NewGuid();
        GroupChat.Chatters.Add(new Person() { Id = chatterId, Name = name, Age = age });
        return chatterId;
    }
}