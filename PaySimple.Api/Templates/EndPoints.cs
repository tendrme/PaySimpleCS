using System;

namespace PaySimple.Api.EndPoints.Customer
{
	public class GetAllCustomers : EndPoint<Types.Customer[]>
	{
		public override string RawUri
		{
			get { return "/v4/customer"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

	}

	public class GetCustomer : EndPoint<Types.Customer>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
	}

	public class GetCustomerPayments : EndPoint<Types.Payment[]>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}/payments"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
	}

	public class GetCustomerPaymentschedules : EndPoint<Types.Payment[]>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}/paymentschedules"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
	}

	public class GetCustomerInvoices : EndPoint<Types.Invoice[]>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}/invoices"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
	}

	public class GetCustomerAccountss : EndPoint<Types.Accounts[]>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}/accounts"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
	}

	public class GetCustomerAchAccounts : EndPoint<Types.AchAccount[]>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}/achaccounts"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
	}

	public class GetCustomerCreditCardAccounts : EndPoint<Types.CreditCardAccount[]>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}/creditcardaccounts"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
	}

	public class GetCustomerDefaultach : EndPoint<Types.AchAccount>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}/defaultach"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
	}

	public class GetCustomerDefaultcreditcard : EndPoint<Types.CreditCardAccount>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}/defaultcreditcard"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
	}

	public class NewCustomer : ContentEndPoint<Types.Customer>
	{
		public override string RawUri
		{
			get { return "/v4/customer"; }
		}

		public override string Method
		{
			get { return "POST"; }
		}

	}

	public class UpdateCustomer : ContentEndPoint<Types.Customer>
	{
		public override string RawUri
		{
			get { return "/v4/customer"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

	}

	public class UpdateCustomer2 : EndPoint<Types.Customer>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}/{accountId}"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
		public string AccountId
		{
			get { return GetValue<string>("accountId"); }
			set { SetValue("accountId", value); }
		}
	}

	public class DeleteCustomer : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/customer/{customerId}"; }
		}

		public override string Method
		{
			get { return "DELETE"; }
		}

		public string CustomerId
		{
			get { return GetValue<string>("customerId"); }
			set { SetValue("customerId", value); }
		}
	}

}

namespace PaySimple.Api.EndPoints.Account
{
	public class GetAccountCreditcard : EndPoint<Types.CreditCardAccount>
	{
		public override string RawUri
		{
			get { return "/v4/account/creditcard/{accountId}"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string AccountId
		{
			get { return GetValue<string>("accountId"); }
			set { SetValue("accountId", value); }
		}
	}

	public class GetAccountAch : EndPoint<Types.AchAccount>
	{
		public override string RawUri
		{
			get { return "/v4/account/ach/{accountId}"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string AccountId
		{
			get { return GetValue<string>("accountId"); }
			set { SetValue("accountId", value); }
		}
	}

	public class NewAccountCreditcard : ContentEndPoint<Types.CreditCardAccount>
	{
		public override string RawUri
		{
			get { return "/v4/account/creditcard"; }
		}

		public override string Method
		{
			get { return "POST"; }
		}

	}

	public class NewAccountAch : ContentEndPoint<Types.AchAccount>
	{
		public override string RawUri
		{
			get { return "/v4/account/ach"; }
		}

		public override string Method
		{
			get { return "POST"; }
		}

	}

	public class UpdateAccountCreditcard : ContentEndPoint<Types.CreditCardAccount>
	{
		public override string RawUri
		{
			get { return "/v4/account/creditcard"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

	}

	public class UpdateAccountAch : ContentEndPoint<Types.AchAccount>
	{
		public override string RawUri
		{
			get { return "/v4/account/ach"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

	}

	public class DeleteAccountCreditcard : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/account/creditcard/{accountId}"; }
		}

		public override string Method
		{
			get { return "DELETE"; }
		}

		public string AccountId
		{
			get { return GetValue<string>("accountId"); }
			set { SetValue("accountId", value); }
		}
	}

	public class DeleteAccountAch : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/account/ach/{accountId}"; }
		}

		public override string Method
		{
			get { return "DELETE"; }
		}

		public string AccountId
		{
			get { return GetValue<string>("accountId"); }
			set { SetValue("accountId", value); }
		}
	}

}

namespace PaySimple.Api.EndPoints.Payment
{
	public class GetAllPayments : EndPoint<Types.Payment[]>
	{
		public override string RawUri
		{
			get { return "/v4/payment"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

	}

	public class GetPayment : EndPoint<Types.Payment>
	{
		public override string RawUri
		{
			get { return "/v4/payment/{paymentId}"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string PaymentId
		{
			get { return GetValue<string>("paymentId"); }
			set { SetValue("paymentId", value); }
		}
	}

	public class NewPayment : ContentEndPoint<Types.Payment>
	{
		public override string RawUri
		{
			get { return "/v4/payment"; }
		}

		public override string Method
		{
			get { return "POST"; }
		}

	}

	public class UpdatePaymentReverse : EndPoint<Types.PaymentResponse>
	{
		public override string RawUri
		{
			get { return "/v4/payment/{paymentId}/reverse"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string PaymentId
		{
			get { return GetValue<string>("paymentId"); }
			set { SetValue("paymentId", value); }
		}
	}

	public class UpdatePaymentVoid : EndPoint<Types.PaymentResponse>
	{
		public override string RawUri
		{
			get { return "/v4/payment/{paymentId}/void"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string PaymentId
		{
			get { return GetValue<string>("paymentId"); }
			set { SetValue("paymentId", value); }
		}
	}

}

namespace PaySimple.Api.EndPoints.RecurringPayment
{
	public class GetAllRecurringPayments : EndPoint<Types.RecurringPayment[]>
	{
		public override string RawUri
		{
			get { return "/v4/recurringpayment"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

	}

	public class GetRecurringPayment : EndPoint<Types.RecurringPayment>
	{
		public override string RawUri
		{
			get { return "/v4/recurringpayment/{scheduleId}"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
	}

	public class GetPayments : EndPoint<Types.Payment[]>
	{
		public override string RawUri
		{
			get { return "/v4recurringpayment/{scheduleId}/payments"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
	}

	public class NewRecurringPayment : ContentEndPoint<Types.RecurringPayment>
	{
		public override string RawUri
		{
			get { return "/v4/recurringpayment"; }
		}

		public override string Method
		{
			get { return "POST"; }
		}

	}

	public class UpdateRecurringPayment : ContentEndPoint<Types.RecurringPayment>
	{
		public override string RawUri
		{
			get { return "/v4/recurringpayment"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

	}

	public class UpdateRecurringPaymentPause : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/recurringpayment/{scheduleId}/pause?endDate={iso8601 Date}"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
		public string EndDate
		{
			get { return GetValue<string>("endDate"); }
			set { SetValue("endDate", value); }
		}
	}

	public class UpdateRecurringPaymentSuspend : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/recurringpayment/{scheduleId}/suspend"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
	}

	public class UpdateRecurringPaymentResume : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/recurringpayment/{scheduleId}/resume"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
	}

	public class DeleteRecurringPayment : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/recurringpayment/{scheduleId}"; }
		}

		public override string Method
		{
			get { return "DELETE"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
	}

}

namespace PaySimple.Api.EndPoints.PaymentPlan
{
	public class GetAllPaymentPlans : EndPoint<Types.PaymentPlan[]>
	{
		public override string RawUri
		{
			get { return "/v4/paymentplan"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

	}

	public class GetPaymentPlan : EndPoint<Types.PaymentPlan>
	{
		public override string RawUri
		{
			get { return "/v4/paymentplan/{scheduleId}"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
	}

	public class GetPayments2 : EndPoint<Types.Payment[]>
	{
		public override string RawUri
		{
			get { return "/v4paymentplan/{scheduleId}/payments"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
	}

	public class NewPaymentPlan : ContentEndPoint<Types.PaymentPlan>
	{
		public override string RawUri
		{
			get { return "/v4/paymentplan"; }
		}

		public override string Method
		{
			get { return "POST"; }
		}

	}

	public class UpdatePaymentPlanPause : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/paymentplan/{scheduleId}/pause?endDate={iso8601 Date}"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
		public string EndDate
		{
			get { return GetValue<string>("endDate"); }
			set { SetValue("endDate", value); }
		}
	}

	public class UpdatePaymentPlanSuspend : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/paymentplan/{scheduleId}/suspend"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
	}

	public class UpdatePaymentPlanResume : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/paymentplan/{scheduleId}/resume"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
	}

	public class DeletePaymentPlan : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/paymentplan/{scheduleId}"; }
		}

		public override string Method
		{
			get { return "DELETE"; }
		}

		public string ScheduleId
		{
			get { return GetValue<string>("scheduleId"); }
			set { SetValue("scheduleId", value); }
		}
	}

}

namespace PaySimple.Api.EndPoints.Invoice
{
	public class GetAllInvoices : EndPoint<Types.Invoice[]>
	{
		public override string RawUri
		{
			get { return "/v4/invoice"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

	}

	public class GetInvoice : EndPoint<Types.Invoice>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

	public class GetInvoiceNumber : EndPoint<Types.InvoiceNumber>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/number"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

	}

	public class GetInvoicePayments : EndPoint<Types.Payment[]>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}/payments"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

	public class GetInvoiceActions : EndPoint<Types.Action[]>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}/actions"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

	public class GetInvoiceInvoicelineitems : EndPoint<Types.Invoice[]>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}/invoicelineitems"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

	public class NewInvoice : ContentEndPoint<Types.Invoice>
	{
		public override string RawUri
		{
			get { return "/v4/invoice"; }
		}

		public override string Method
		{
			get { return "POST"; }
		}

	}

	public class UpdateInvoice : ContentEndPoint<Types.Invoice>
	{
		public override string RawUri
		{
			get { return "/v4/invoice"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

	}

	public class UpdateInvoiceSend : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}/send"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

	public class UpdateInvoiceExternalpayment : EndPoint<Types.ExternalPayment>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}/externalpayment"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

	public class UpdateInvoiceMarkpaid : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}/markpaid"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

	public class UpdateInvoiceMarkunpaid : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}/markunpaid"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

	public class UpdateInvoiceMarksent : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}/marksent"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

	public class UpdateInvoiceCancel : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}/cancel"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

	public class DeleteInvoice : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/invoice/{invoiceId}"; }
		}

		public override string Method
		{
			get { return "DELETE"; }
		}

		public string InvoiceId
		{
			get { return GetValue<string>("invoiceId"); }
			set { SetValue("invoiceId", value); }
		}
	}

}

namespace PaySimple.Api.EndPoints.LineItem
{
	public class GetAllLineItems : EndPoint<Types.LineItem[]>
	{
		public override string RawUri
		{
			get { return "/v4/lineitem"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

	}

	public class GetLineItem : EndPoint<Types.LineItem>
	{
		public override string RawUri
		{
			get { return "/v4/lineitem/{lineItemId}"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string LineItemId
		{
			get { return GetValue<string>("lineItemId"); }
			set { SetValue("lineItemId", value); }
		}
	}

	public class NewLineItem : ContentEndPoint<Types.LineItem>
	{
		public override string RawUri
		{
			get { return "/v4/lineitem"; }
		}

		public override string Method
		{
			get { return "POST"; }
		}

	}

	public class UpdateLineItem : ContentEndPoint<Types.LineItem>
	{
		public override string RawUri
		{
			get { return "/v4/lineitem"; }
		}

		public override string Method
		{
			get { return "PUT"; }
		}

	}

	public class DeleteLineItem : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/lineitem/{lineItemId}"; }
		}

		public override string Method
		{
			get { return "DELETE"; }
		}

		public string LineItemId
		{
			get { return GetValue<string>("lineItemId"); }
			set { SetValue("lineItemId", value); }
		}
	}

}

namespace PaySimple.Api.EndPoints.LineItemTax
{
	public class GetAllLineItemTaxs : EndPoint<Types.LineItemTax[]>
	{
		public override string RawUri
		{
			get { return "/v4/lineitemtax"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

	}

	public class GetLineItemTax : EndPoint<Types.LineItemTax>
	{
		public override string RawUri
		{
			get { return "/v4/lineitemtax/{lineItemTaxId}"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string LineItemTaxId
		{
			get { return GetValue<string>("lineItemTaxId"); }
			set { SetValue("lineItemTaxId", value); }
		}
	}

	public class NewLineItemTax : ContentEndPoint<Types.LineItemTax>
	{
		public override string RawUri
		{
			get { return "/v4/lineitemtax"; }
		}

		public override string Method
		{
			get { return "POST"; }
		}

	}

}

namespace PaySimple.Api.EndPoints.PaymentTerm
{
	public class GetAllPaymentTerms : EndPoint<Types.PaymentTerm[]>
	{
		public override string RawUri
		{
			get { return "/v4/paymentterm"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

	}

	public class GetPaymentTerm : EndPoint<Types.PaymentTerm>
	{
		public override string RawUri
		{
			get { return "/v4/paymentterm/{paymentTermId}"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

		public string PaymentTermId
		{
			get { return GetValue<string>("paymentTermId"); }
			set { SetValue("paymentTermId", value); }
		}
	}

	public class NewPaymentTerm : ContentEndPoint<Types.PaymentTerm>
	{
		public override string RawUri
		{
			get { return "/v4/paymentterm"; }
		}

		public override string Method
		{
			get { return "POST"; }
		}

	}

	public class DeletePaymentTerm : EndPoint<Types.GenericResponse>
	{
		public override string RawUri
		{
			get { return "/v4/paymentterm/{paymentTermId}"; }
		}

		public override string Method
		{
			get { return "DELETE"; }
		}

		public string PaymentTermId
		{
			get { return GetValue<string>("paymentTermId"); }
			set { SetValue("paymentTermId", value); }
		}
	}

}

namespace PaySimple.Api.EndPoints.PaymentType
{
	public class GetPaymentTypeSupported : EndPoint<Types.PaymentType[]>
	{
		public override string RawUri
		{
			get { return "/v4/paymenttype/supported"; }
		}

		public override string Method
		{
			get { return "GET"; }
		}

	}

}


