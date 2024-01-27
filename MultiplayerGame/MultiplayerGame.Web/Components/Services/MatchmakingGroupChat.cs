using Microsoft.AspNetCore.SignalR;

namespace MultiplayerGame.Web.Components.Services;

public class MatchmakingGroupChat
{
    public GroupChatController GroupChat { get; set; } = new GroupChatController();

    public Guid JoinGroupChat()
    {
        var chatterId = Guid.NewGuid();
        GroupChat.Chatters.Add(chatterId);
        return chatterId;
    }
}