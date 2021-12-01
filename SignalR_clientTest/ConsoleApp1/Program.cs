using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set connection
            var connection = new HubConnectionBuilder()
                            .WithUrl("http://localhost:8081/suggestorHub")
                            .Build();
            //var connection = new HubConnection("http://localhost:8081/:8081/");
            ////Make proxy to hub based on hub name on server
            var myHub = connection;//.CreateHubProxy("ChatHub");
                                   //Start connection

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

         
            connection.StartAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }).Wait();

            myHub.On<string>("suggestionResponse", param =>
            {
                Response t = JsonConvert.DeserializeObject<Response>(param);
                Console.WriteLine(param);
            });


            myHub.InvokeAsync<string>("SendGroupMessage", connection.ConnectionId.ToString(), "suggestionRequest", "HELLO World").ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error calling send: {0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine(task.Result);
                    
                }
            });



            //myHub.Invoke<string>("DoSomething", "I'm doing something!!!").Wait();


            Console.Read();
            connection.StopAsync();
        }
    }
    class Response
    {
        public int ResultLength { get; set; }
        public List<Result> Results { get; set; }
        public Response()
        {
            ResultLength = 5;
            Results = new List<Result>();
        }
    }

    class Result
    {
        public string Sentence { get; set; }
        public float Score { get; set; }
    }
}
