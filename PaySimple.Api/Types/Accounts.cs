using System;

namespace PaySimple.Api.Types
{
    public class Accounts
    {
        public AchAccount[] AchAccounts { get; set; }
        public CreditCardAccount[] CreditCardAccounts { get; set; }
    }
}
