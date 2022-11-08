using System;

namespace Access_API.Exceptions
{
    public class SearchQueryResponseException : Exception
    {
        public SearchQueryResponseException(ProblemDetailsDTO errorResponse)
        {
            ErrorResponse = errorResponse;
        }

        public ProblemDetailsDTO ErrorResponse { get; }
    }
}
