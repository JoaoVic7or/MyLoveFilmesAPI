using Microsoft.AspNetCore.SignalR;

namespace MyLoveFilmes.Core.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var chatRoomId = Context.GetHttpContext()?.Request.Query["chatRoomId"];

            if (!string.IsNullOrEmpty(chatRoomId))
                await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var chatRoomId = Context.GetHttpContext()?.Request.Query["chatRoomId"];

            if (!string.IsNullOrEmpty(chatRoomId))
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}

