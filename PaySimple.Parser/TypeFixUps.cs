using System;
using System.Linq;
using System.Collections.Generic;

namespace PaySimple.Parser
{
    /// <summary>
    /// The API documentation isn't 100% accurate.  This class fixes those issues.
    /// </summary>
    public class TypeFixUps
    {
        public void FixUp(Schema schema)
        {
            var fixUps = default(List<Schema>);
            switch (schema.Name)
            {
                case "CreditCardAccount":
                    fixUps = CreditCardAccountFixUp();
                    break;

                case "PaymentResponse":
                    fixUps = PaymentResponseFixUp();
                    break;
            }

            if (fixUps != null)
            {
                foreach (var fixUp in fixUps)
                {
                    var prop = schema
                        .Properties
                        .Select((x, i) => new { Name = x.Name, Idx = i })
                        .SingleOrDefault(x => x.Name == fixUp.Name);
                    if (prop != null)
                        schema.Properties[prop.Idx] = fixUp;
                    else
                        schema.Properties.Add(fixUp);
                }
            }
        }

        static List<Schema> CreditCardAccountFixUp()
        {
            return new List<Schema>
            {
                new Schema
                {
                    Name = "BillingZipCode",
                    Type = "string"
                }
            };
        }

        static List<Schema> PaymentResponseFixUp()
        {
            return new List<Schema>
            {
                new Schema
                {
                    Name = "CustomerFirstName",
                    Type = "string"
                },
                new Schema
                {
                    Name = "CustomerLastName",
                    Type = "string"
                },
                new Schema
                {
                    Name = "CustomerCompany",
                    Type = "string"
                },
                new Schema
                {
                    Name = "Latitude",
                    Type = "decimal?"
                },
                new Schema
                {
                    Name = "Longitude",
                    Type = "decimal?"
                }
            };
        }
    }
}
