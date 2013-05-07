using System;

namespace PaySimple.Api.Types
{
    public class SupportedPaymentType
    {
        public string Name { get; set; }
        public string[] Values { get; set; }
    }
}
