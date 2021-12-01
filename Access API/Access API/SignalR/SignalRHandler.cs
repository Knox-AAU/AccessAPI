using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Access_API.SignalR
{

    class Request
    {
        public string Sentence { get; set; }
        public string OrderBy { get; set; }
        public int MaxResults { get; set; }

        public Request()
        {
            Sentence = "Hvem er ....";
            OrderBy = "ASC";
            MaxResults = 5;
        }
    }
    class Response
    {
        public int ResultLength { get; set; }
        public List<Result> Results { get; set; }
        public Response()
        {
            ResultLength = 5;
            Results = new List<Result>() { 
                new Result(){Sentence ="hvem", Score = 3.5f },
                new Result(){Sentence ="hvem er", Score = 3.4f },
                new Result(){Sentence ="hvem er ikke", Score = 3.0f },
                new Result(){Sentence ="hvem er ?", Score = 2.9f },
                new Result(){Sentence ="hvem hvorfor?", Score = 2.5f }};
        }
    }

    class Result
    {
        public string Sentence { get; set; }
        public float Score { get; set; }
    }



    public class SignalRHandler : Hub
    {
        //List<string> connectionId = new List<string>();
        string suggestorClientId = string.Empty;
        string test = "";

        public async Task SuggesterJoin()
        {
            suggestorClientId = Context.ConnectionId;
        }
        
        //public async Task SendMessage(string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", message);
        //}

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
                        string s = JsonConvert.SerializeObject(new Response());
                        await Clients.Group(groupName).SendAsync("suggestionResponse", s);
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

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            Debug.WriteLine($"Suggestor joined group: {groupName}");
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            Debug.WriteLine($"Suggestor left group: {groupName}");
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Client(suggestorClientId).SendAsync("JoinGroup", groupName);
            Debug.WriteLine($"Added {Context.ConnectionId} to group: {groupName}");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Client(suggestorClientId).SendAsync("LeaveGroup", groupName);
            Debug.WriteLine($"Remove {Context.ConnectionId} from group: {groupName}");
        }

        public override Task OnConnectedAsync()
        {
            Debug.WriteLine($"Client {Context.ConnectionId} join the HUB");
            AddToGroup(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Debug.WriteLine($"Client {Context.ConnectionId} left the HUB");
            RemoveFromGroup(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
