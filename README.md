PaySimple C#
============

.Net bindings for the v4 PaySimple API

This is a work in progress.  Almost the entire v4 API is bound with only the "New" and "Lookup" endpoints missing.  The binding is entirely generated from PaySimple's API spec along with some smart guessing done by the parser.  There are a few known bugs due to misdocumentation from PaySimple, and some limitations due to the binding's incompleteness, but this should go far to get you accomplishing most actions available from PaySimple.

__Quick Start__
```C#
using Ps = PaySimple.Api;
using Eps = PaySimple.Api.EndPoints;

// Start your request with newing up the appropriate endpoint.
var newPayment = new Eps.Payment.NewPayment
{
  Content = new Ps.Types.Payment
  {
    // These are the REST parameters.
    AccountId = 368937,
    Amount = 100
  }
};

// Fire it off (see App.config for setting UserName and Secret).
var request = new Ps.Request();
// All the metadata and appropriate goodness is returned in the response object.
var response = request.Execute(newPayment);
```

TODO: note limitations + work-arounds.

[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/tendrme/PaySimpleCS/trend.png)](https://bitdeli.com/free "Bitdeli Badge")
