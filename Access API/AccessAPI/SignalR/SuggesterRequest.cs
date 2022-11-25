namespace Access_API.SignalR
{
    public class SuggesterRequest
    {
        public string Sentence { get; set; } = null!;
        public string OrderBy { get; set; } = null!;
        public int MaxResults { get; set; }
    }
}
