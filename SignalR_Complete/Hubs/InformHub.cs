using Microsoft.AspNetCore.SignalR;

namespace SignalR_Complete.Hubs
{

    public interface IInformHub
    {
        public Task SendCountToClient(string group, string clientHandlerMethod);
    }

    public class InformHub : Hub
    {
        //Creates a group and assigns the connection ID to the group
        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        //Acts as server to get data from one method in a client to another method (clientHandlerMethod) in client
        public Task SendMessageToGroup(string group,string clientHandlerMethod,string message)
        {
            return Clients.Group(group).SendAsync(clientHandlerMethod, message + " [" + Context.ConnectionId + "]");
        }

        public Task SendCountToClient(string group,string clientHandlerMethod)
        {
            return Clients.Group(group).SendAsync(clientHandlerMethod, 10);
        }

    }
}
