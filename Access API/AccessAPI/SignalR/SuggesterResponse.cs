using System.Collections.Generic;

namespace Access_API.SignalR
{
    public class SuggesterResponse
    {
        public SuggesterResponse()
        {

        }

        public SuggesterResponse(List<SuggesterSentence> sentences)
        {
            ResultLength = sentences.Count;
            Results = sentences;
        }

        public int ResultLength { get; set; }
        public List<SuggesterSentence> Results { get; set; } = new();
    }
}
