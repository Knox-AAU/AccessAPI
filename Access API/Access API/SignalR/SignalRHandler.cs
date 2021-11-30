using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Access_API.SignalR
{
    public class SignalRHandler : Hub
    {
        List<string> connectionId = new List<string>();
        
       
        public async Task SuggesterJoin()
        {

        }

        
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendGroupMessage(string groupName, string messageTag, string message)
        {

            switch(messageTag)
            {
                case "status":
                    {
                        await Clients.Group(groupName).SendAsync("status", message);
                        break;
                    }
                case "suggestionRequest":
                    {
                        await Clients.Group(groupName).SendAsync("suggestionRequest", message);
                        break;
                    }
                case "suggestionResponse":
                    {
                        await Clients.Group(groupName).SendAsync("suggestionResponse", message);
                        break;
                    }
                default:
                    {
                        await Clients.Group(groupName).SendAsync("error", "unsupported messageTag");
                        break;
                    }
            }
        }


        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }

        public override Task OnConnectedAsync()
        {
            connectionId.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            connectionId.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }



    }
}
