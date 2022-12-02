using System.Collections.Generic;
using System;

namespace Access_API.SignalR
{

    class SuggestorSimulator
    {
        static List<string> randomWords = new List<string>() { "hvem", "kan", "test", "NEEEJ", "Hej", "Måske" };
        public static SuggesterResponse GenerateTestResponse(SuggesterRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var sentences = new List<SuggesterSentence>();
            for (int i = 0; i < request.MaxResults; i++)
            {
                string s = string.Empty;
                float score = (float)new Random().NextDouble() * 100;
                int wordCnt = new Random().Next(1, 8);

                for (int j = 0; j < wordCnt; j++)
                {
                    s += $"{randomWords[new Random().Next(0, randomWords.Count - 1)]} ";
                }
                s = s.Trim();

                sentences.Add(new SuggesterSentence(s, score));
            }
            return new SuggesterResponse(sentences);
        }
    }
}
