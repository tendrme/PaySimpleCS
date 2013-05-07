using System;

namespace PaySimple.Api.Types
{
    public class ExternalPayment
    {
        public decimal ReceivedAmount { get; set; }
        public string Description { get; set; }
    }
}
