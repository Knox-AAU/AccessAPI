using System.Collections.Generic;
using System;

namespace Access_API.SignalR
{

    class SuggestorSimulator
    {
        List<string> randomWords = new List<string>() { "hvem", "kan", "test", "NEEEJ", "Hej", "Måske" };
        public TestResponse GenerateTestResponse(TestRequest request)
        {
            TestResponse tr = new TestResponse();
            tr.ResultLength = request.MaxResults;

            for (int i = 0; i < request.MaxResults; i++)
            {
                string s = string.Empty;
                int wordCnt = new Random().Next(1, 8);

                for (int j = 0; j < wordCnt; j++)
                {
                    s += $"{randomWords[new Random().Next(0, randomWords.Count - 1)]} ";
                }
                s = s.Trim();

                tr.Results.Add(new Result() { Sentence = s, Score = (float)new Random().NextDouble() * 100 });
            }

            return tr;
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

    public class TestRequest
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
