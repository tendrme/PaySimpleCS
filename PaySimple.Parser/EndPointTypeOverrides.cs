using System;
using System.Collections.Generic;

namespace PaySimple.Parser
{
    /// <summary>
    /// Some types we cannot faithfully deduce simply by sniffing the URI.
    /// This class allows us to inject the correct type gotten from the schema.
    /// </summary>
    public class EndPointTypeOverrides
    {
        // The last slug of the, or the entire, URI may be used as the key.
        static Dictionary<string, string> _overrides =
            new Dictionary<string, string>
        {
            { "ach", "AchAccount" },
            { "defaultach", "AchAccount" },
            { "creditcard", "CreditCardAccount" },
            { "defaultcreditcard", "CreditCardAccount" },
            { "invoicelineitem", "LineItem" },
            { "reverse", "PaymentResponse" },
            { "/v4/payment/{paymentId}/void", "PaymentResponse" },
            { "/v4/invoice/number", "InvoiceNumber" },
            { "actions", "Action" },
            { "send", "GenericResponse" },
            { "externalpayment", "ExternalPayment" },
            { "markpaid", "GenericResponse" },
            { "markunpaid", "GenericResponse" },
            { "marksent", "GenericResponse" },
            { "cancel", "GenericResponse" },
            { "pause", "GenericResponse" },
            { "suspend", "GenericResponse" },
            { "resume", "GenericResponse" },
            { "supported", "PaymentType[]" }
        };

        public string GetOverride(params string[] typeNameHints)
        {
            var found = default(string);
            foreach (var hint in typeNameHints)
            {
                if (_overrides.TryGetValue(hint, out found))
                    break;
            }
            return found;
        }
    }
}
