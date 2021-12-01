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
                TestResponse t = JsonConvert.DeserializeObject<TestResponse>(param);
                Console.WriteLine(param);
            });

            TestRequest tr = new TestRequest() { MaxResults = 5, OrderBy = "ASC", Sentence = "test" };
            myHub.InvokeAsync<string>("SendGroupMessage", connection.ConnectionId.ToString(), "suggestionRequestTest", JsonConvert.SerializeObject(tr)).ContinueWith(task =>
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
    class TestResponse
    {
        public int ResultLength { get; set; }
        public List<Result> Results { get; set; }
        public TestResponse()
        {
            ResultLength = 5;
            Results = new List<Result>(); //{ 
            //    new Result(){Sentence ="hvem", Score = 3.5f },
            //    new Result(){Sentence ="hvem er", Score = 3.4f },
            //    new Result(){Sentence ="hvem er ikke", Score = 3.0f },
            //    new Result(){Sentence ="hvem er ?", Score = 2.9f },
            //    new Result(){Sentence ="hvem hvorfor?", Score = 2.5f }};
        }
    }
    class Result
    {
        public string Sentence { get; set; }
        public float Score { get; set; }
    }

    class TestRequest
    {
        public string Sentence { get; set; }
        public string OrderBy { get; set; }
        public int MaxResults { get; set; }

        public TestRequest()
        {
            Sentence = "Hvem er ....";
            OrderBy = "ASC";
            MaxResults = 5;
        }
    }
}
