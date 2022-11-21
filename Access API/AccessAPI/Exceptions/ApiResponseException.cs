using System;

namespace Access_API.Exceptions
{
    public class ApiResponseException : Exception
    {
        public ApiResponseException(ProblemDetailsDTO errorResponse)
        {
            ErrorResponse = errorResponse;
        }

        public ProblemDetailsDTO ErrorResponse { get; }
    }
}
