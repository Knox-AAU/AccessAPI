namespace Access_API.SignalR
{
    public class SuggesterSentence
    {
        public SuggesterSentence()
        {

        }

        public SuggesterSentence(string sentence, float score)
        {
            Sentence = sentence;
            Score = score;
        }

        public string Sentence { get; set; } = null!;
        public float Score { get; set; }
    }
}
