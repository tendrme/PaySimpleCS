using System;
using System.Linq;

using PaySimple.Api.Types;

namespace PaySimple.Api
{
    public class PaySimpleException<T> : Exception where T : class
    {
        readonly ApiResponse<T> _response;

        public PaySimpleException(ApiResponse<T> response)
        {
            _response = response;
        }

        public ErrorMessage[] Messages
        {
            get { return _response.Meta.Errors.ErrorMessages; }
        }
    }
}
