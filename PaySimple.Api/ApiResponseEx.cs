using System;
using System.Net;

using PaySimple.Api.Types;

namespace PaySimple.Api
{
    public static class ApiResponseEx
    {
        public static void ThrowIfError<T>(this ApiResponse<T> response)
            where T : class
        {
            if (response.Meta.Errors != null)
                throw new PaySimpleException<T>(response);
        }
    }
}
