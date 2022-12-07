using Microsoft.AspNetCore.SignalR;

namespace notification_backend_api.Servicies
{
    public class NotificationsHub:Hub
    {
        //Broadcast a message to every connected user.
        public async Task BroadcastMessage(Object[] messages)
        {
            await this.Clients.All.SendAsync("message_received", messages);
        }

    }
}
