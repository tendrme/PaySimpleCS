using System;
using System.Net;

namespace PaySimple.Api.Types
{
    public class Error
    {
        public string ErrorCode { get; set; }
        public ErrorMessage[] ErrorMessages { get; set; }
    }

    public class ErrorMessage
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }

    public class PagingDetails
    {
        public int TotalItems { get; set; }
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }

    public class Meta
    {
        public string HttpStatus { get; set; }
        public string HttpStatusCode { get; set; }
        public Error Errors { get; set; }
        public PagingDetails PagingDetails { get; set; }
    }

    public interface IApiResponse<out T> where T : class
    {
        Meta Meta { get; set; }
        T Response { get; }
        HttpStatusCode Status { get; set; }
    }

    public class ApiResponse<T> : IApiResponse<T> where T : class
    {
        public Meta Meta { get; set; }
        public T Response { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
