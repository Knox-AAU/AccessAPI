namespace Access_API
{
    public class ProblemDetailsDTO
    {
        public ProblemDetailsDTO(string type, string title, int status, string traceId)
        {
            Type = type;
            Title = title;
            Status = status;
            TraceId = traceId;
        }

        public string Type { get; }
        public string Title { get; }
        public int Status { get; }
        public string TraceId { get; }
    }
}
