using System;

namespace PaySimple.Parser
{
    /// <summary>
    /// The API documentation isn't 100% accurate.  This class fixes those issues.
    /// </summary>
    public class TypeFixUps
    {
        public void FixUp(Schema schema)
        {
            switch (schema.Name)
            {
                case "CreditCardAccount":
                    schema.Properties.Add(new Schema
                    {
                        Name = "BillingZipCode",
                        Type = "string"
                    });
                    break;
            }
        }
    }
}
