namespace PaySimple.Api.Types 
{

	public class Customer
	{
		public string MiddleName { get; set; }
		public string AltEmail { get; set; }
		public string AltPhone { get; set; }
		public string MobilePhone { get; set; }
		public string Fax { get; set; }
		public string Website { get; set; }
		public BillingAddress BillingAddress { get; set; }
		public bool ShippingSameAsBilling { get; set; }
		/// <summary>
		/// Not required if ShippingSameAsBilling set to true.
		/// </summary>
		public ShippingAddress ShippingAddress { get; set; }
		public string Company { get; set; }
		public string Notes { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int Id { get; set; }
		public string LastModified { get; set; }
		public string CreatedOn { get; set; }
	}

	public class BillingAddress
	{
		public string StreetAddress1 { get; set; }
		public string StreetAddress2 { get; set; }
		public string City { get; set; }
		public string StateCode { get; set; }
		public string ZipCode { get; set; }
		public string Country { get; set; }
	}

	/// <summary>
	/// Not required if ShippingSameAsBilling set to true.
	/// </summary>
	public class ShippingAddress
	{
		public string StreetAddress1 { get; set; }
		public string StreetAddress2 { get; set; }
		public string City { get; set; }
		public string StateCode { get; set; }
		public string ZipCode { get; set; }
		public string Country { get; set; }
	}

	public class AchAccount
	{
		public bool IsCheckingAccount { get; set; }
		public string RoutingNumber { get; set; }
		public string AccountNumber { get; set; }
		public string BankName { get; set; }
		public int? CustomerId { get; set; }
		public bool IsDefault { get; set; }
		public int Id { get; set; }
		public string LastModified { get; set; }
		public string CreatedOn { get; set; }
	}

	public class CreditCardAccount
	{
		public string BillingZipCode { get; set; }
		public string CreditCardNumber { get; set; }
		public int? CustomerId { get; set; }
		public string ExpirationDate { get; set; }
		public int Id { get; set; }
		public bool IsDefault { get; set; }
		/// <summary>
		/// Must be valid credit card issuer.
		/// </summary>
		public Issuer Issuer { get; set; }
		public string CreatedOn { get; set; }
		public string LastModified { get; set; }
	}

	/// <summary>
	/// Must be valid credit card issuer.
	/// </summary>
	public enum Issuer : int
	{
		Visa = 12,
		Master = 13,
		Amex = 14,
		Discover = 15,
	}

	/// <summary>
	/// This is a model of a new Payment object and the required data to Post the Payment.  A submitted payment object will contain more data. This is a one-time payment that will be created on the date submitted.  For a one-time future payment, see RecurringPayment.
	/// </summary>
	public class Payment
	{
		public int? AccountId { get; set; }
		public int? InvoiceId { get; set; }
		public decimal Amount { get; set; }
		public bool IsDebit { get; set; }
		public string CVV { get; set; }
		public string PaymentSubType { get; set; }
		public string InvoiceNumber { get; set; }
		public string PurchaseOrderNumber { get; set; }
		public string OrderId { get; set; }
		public string Description { get; set; }
		public int Id { get; set; }
		public string LastModified { get; set; }
		public string CreatedOn { get; set; }
	}

	public class PaymentResponse : Payment
	{
		public int? CustomerId { get; set; }
		public int? CustomerFirstName { get; set; }
		public int? CustomerLastName { get; set; }
		public int? CustomerCompany { get; set; }
		public int? ReferenceId { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		/// <summary>
		/// The status of the payment and is set by system. Any data provided will be disregarded.
		/// </summary>
		public Status Status { get; set; }
		public int? RecurringScheduleId { get; set; }
		/// <summary>
		/// The type of the Payment, ACH or Credit Card, determined by the Account Id provided and set by PaySimple when Payment was created.  This is read only.
		/// </summary>
		public PaymentType PaymentType { get; set; }
		public string ProviderAuthCode { get; set; }
		public string TraceNumber { get; set; }
		public string PaymentDate { get; set; }
		public string ReturnDate { get; set; }
		public string EstimatedSettleDate { get; set; }
		public string ActualSettledDate { get; set; }
		public string CanVoidUntil { get; set; }
	}

	/// <summary>
	/// The status of the payment and is set by system. Any data provided will be disregarded.
	/// </summary>
	public enum Status : int
	{
		/// <summary>
		/// Not currently used
		/// </summary>
		All = -1,
		/// <summary>
		/// Pending is the initial status of all Payments until PaySimple receives confirmation from the processor that the Payment was received. If a transaction is in Pending status, please contact Customer Care to determine the true status of the Payment.
		/// </summary>
		Pending = 0,
		/// <summary>
		/// Posted indicates that a Credit Card Payment was submitted. An ACH Payment updates to Posted once submitted.
		/// </summary>
		Posted = 1,
		/// <summary>
		/// Settled indicates the funds were collected for the Payment by the processor.
		/// </summary>
		Settled = 2,
		/// <summary>
		/// Failed indicates a the Payment was unsuccessful.  The ProviderAuthCode field will show a reason for the failed payment.
		/// </summary>
		Failed = 3,
		/// <summary>
		/// Not currently used
		/// </summary>
		Resubmitted = 4,
		/// <summary>
		/// Voided indicates the Payment was cancelled before it was submitted to the processor.
		/// </summary>
		Voided = 5,
		/// <summary>
		/// Reversed is the status that will show on the original Payment that was refunded to the customer.
		/// </summary>
		Reversed = 6,
		/// <summary>
		/// Not currently used
		/// </summary>
		Saved = 7,
		/// <summary>
		/// Not currently used
		/// </summary>
		Scheduled = 8,
		/// <summary>
		/// The credit transaction generated when a settled transaction is refunded or when you process a stand-alone refund. ReversePosted is the status of the refund transaction while it is in process of reversing.
		/// </summary>
		ReversePosted = 9,
		/// <summary>
		/// ChargeBack indicates a customer disputed a Payment.
		/// </summary>
		ChargeBack = 10,
		/// <summary>
		/// Not currently used
		/// </summary>
		CloseChargeBack = 11,
		/// <summary>
		/// Authorized confirms a Credit Card Payment was approved.
		/// </summary>
		Authorized = 12,
		/// <summary>
		/// Returned indicates an ACH Payment was rejected by the Customer's bank for the reason specified in the ProviderAuthCode field.
		/// </summary>
		Returned = 13,
		/// <summary>
		/// Not currently used
		/// </summary>
		ReverseChargeBack = 14,
		/// <summary>
		/// An ACH Payment returned for insufficient funds.
		/// </summary>
		ReverseNSF = 15,
		/// <summary>
		/// Not currently used
		/// </summary>
		ReverseReturn = 16,
		/// <summary>
		/// A settled refund transaction.  When funds have been deducted from the merchant's account for a RefundPosted Payment, the status changes to RefundSettled.
		/// </summary>
		RefundSettled = 17,
	}

	/// <summary>
	/// The type of the Payment, ACH or Credit Card, determined by the Account Id provided and set by PaySimple when Payment was created.  This is read only.
	/// </summary>
	public enum PaymentType : int
	{
		CC = 1,
		ACH = 2,
	}

	public class PaymentPlan
	{
		public decimal FirstPaymentAmount { get; set; }
		public string FirstPaymentDate { get; set; }
		public int? AccountId { get; set; }
		public string InvoiceNumber { get; set; }
		public string OrderId { get; set; }
		public int? TotalNumberOfPayments { get; set; }
		public decimal TotalDueAmount { get; set; }
		public string PaymentSubType { get; set; }
		public string StartDate { get; set; }
		public ScheduleStatus ScheduleStatus { get; set; }
		/// <summary>
		/// The frequency to execute the schedule.
		/// </summary>
		public ExecutionFrequencyType ExecutionFrequencyType { get; set; }
		/// <summary>
		/// The execution frequency parameter specifies the day of month for a SpecificDayOfMonth frequency or specifies day of week for Weekly or BiWeekly schedule. It is required when ExecutionFrequncyType is SpecificDayofMonth, Weekly or BiWeekly.
		/// </summary>
		public ExecutionFrequencyParameter ExecutionFrequencyParameter { get; set; }
		public string Description { get; set; }
		public int Id { get; set; }
		public string LastModified { get; set; }
		public string CreatedOn { get; set; }
	}

	public enum ScheduleStatus : int
	{
		/// <summary>
		/// The schedule is active.
		/// </summary>
		Active = 1,
		/// <summary>
		/// The schedule is paused until a specific date.
		/// </summary>
		PauseUntil = 2,
		/// <summary>
		/// The schedule is expired, or reached the specified end date.
		/// </summary>
		Expired = 3,
		/// <summary>
		/// The schedule is suspended indefinitely.
		/// </summary>
		Suspended = 4,
	}

	/// <summary>
	/// The frequency to execute the schedule.
	/// </summary>
	public enum ExecutionFrequencyType : int
	{
		Daily = 1,
		Weekly = 2,
		BiWeekly = 3,
		FirstofMonth = 4,
		SpecificDayofMonth = 5,
		LastofMonth = 6,
		Quarterly = 7,
		SemiAnnually = 8,
		Annually = 9,
	}

	/// <summary>
	/// The execution frequency parameter specifies the day of month for a SpecificDayOfMonth frequency or specifies day of week for Weekly or BiWeekly schedule. It is required when ExecutionFrequncyType is SpecificDayofMonth, Weekly or BiWeekly.
	/// </summary>
	public enum ExecutionFrequencyParameter : int
	{
		Sunday = 1,
		Monday = 2,
		Tuesday = 3,
		Wednesday = 4,
		Thursday = 5,
		Friday = 6,
		Saturday = 7,
	}

	public class PaymentPlanResponse : PaymentPlan
	{
		public int? CustomerId { get; set; }
		public int? CustomerFirstName { get; set; }
		public int? CustomerLastName { get; set; }
		public int? CustomerCompany { get; set; }
		public decimal PaymentAmount { get; set; }
		public bool FirstPaymentDone { get; set; }
		public int? NumberOfPaymentMade { get; set; }
		public decimal TotalAmountPaid { get; set; }
		public string DateOfLastPaymentMade { get; set; }
		public string PauseUntilDate { get; set; }
		public int? NumberOfPaymentsRemaining { get; set; }
		public decimal BalanceRemaining { get; set; }
		public string NextScheduleDate { get; set; }
	}

	public class RecurringPayment
	{
		public decimal PaymentAmount { get; set; }
		public decimal FirstPaymentAmount { get; set; }
		public string FirstPaymentDate { get; set; }
		public int? AccountId { get; set; }
		public string InvoiceNumber { get; set; }
		public string OrderId { get; set; }
		public string PaymentSubType { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public ScheduleStatus ScheduleStatus { get; set; }
		public ExecutionFrequencyType ExecutionFrequencyType { get; set; }
		public ExecutionFrequencyParameter ExecutionFrequencyParameter { get; set; }
		public string Description { get; set; }
		public int Id { get; set; }
		public string LastModified { get; set; }
		public string CreatedOn { get; set; }
	}

	public class RecurringPaymentResponse : RecurringPayment
	{
		public int? CustomerId { get; set; }
		public int? CustomerFirstName { get; set; }
		public int? CustomerLastName { get; set; }
		public int? CustomerCompany { get; set; }
		public bool FirstPaymentDone { get; set; }
		public int? NumberOfPaymentMade { get; set; }
		public decimal TotalAmountPaid { get; set; }
		public string DateOfLastPaymentMade { get; set; }
		public string PauseUntilDate { get; set; }
		public string NextScheduleDate { get; set; }
	}

	public class Invoice
	{
		public int? CustomerId { get; set; }
		public string InvoiceNumber { get; set; }
		public int? PaymentTermId { get; set; }
		public string PurchaseOrderNumber { get; set; }
		public string InvoiceDate { get; set; }
		public string DueDate { get; set; }
		/// <summary>
		/// Array of invoice line item objects. At least one line item is required in the array.
		/// </summary>
		public InvoiceLineItem[] InvoiceLineItems { get; set; }
		public string Description { get; set; }
		public decimal DiscountPercentage { get; set; }
		public int Id { get; set; }
		public string LastModified { get; set; }
		public string CreatedOn { get; set; }
	}

	/// <summary>
	/// Array of invoice line item objects. At least one line item is required in the array.
	/// </summary>
	public class InvoiceLineItem
	{
		public LineItem LineItem { get; set; }
		public Tax[] Taxes { get; set; }
		public decimal Quantity { get; set; }
	}

	public class LineItem
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Id { get; set; }
		public string LastModified { get; set; }
		public string CreatedOn { get; set; }
	}

	public class Tax
	{
		public string Name { get; set; }
		public decimal Value { get; set; }
		public bool IsPercentage { get; set; }
		public int Id { get; set; }
		public string LastModified { get; set; }
		public string CreatedOn { get; set; }
	}

	public class InvoiceResponse : Invoice
	{
		public int? CustomerFirstName { get; set; }
		public int? CustomerLastName { get; set; }
		public int? CustomerCompany { get; set; }
		/// <summary>
		/// Indicates current status of the invoice and is set by triggers in the system.
		/// </summary>
		public InvoiceStatus InvoiceStatus { get; set; }
		public int? DaysOverdue { get; set; }
		public string PaidInFullDate { get; set; }
		public string LastResentDate { get; set; }
		public decimal PaidAmount { get; set; }
		public decimal InvoiceAmount { get; set; }
		public string InvoiceFirstSentDate { get; set; }
		public int? ScheduleId { get; set; }
		public BillingAddress BillingAddress { get; set; }
	}

	/// <summary>
	/// Indicates current status of the invoice and is set by triggers in the system.
	/// </summary>
	public enum InvoiceStatus : int
	{
		Paid = 0,
		Unpaid = 1,
		Draft = 2,
		Cancelled = 3,
		Overdue = 4,
		PaidPartially = 5,
	}

	public class LineItemTax
	{
		public string Name { get; set; }
		public decimal Amount { get; set; }
		public bool IsPercentage { get; set; }
		public int Id { get; set; }
		public string LastModified { get; set; }
		public string CreatedOn { get; set; }
	}

	public class PaymentTerm
	{
		public string Description { get; set; }
		public int? DaysUntilPaymentDue { get; set; }
		public int Id { get; set; }
	}

	/// <summary>
	/// This is a special object to post a payment received via cash or check to an Invoice. This object need to be provided with the route /v4/invoice/{invoiceId}/externalpayment
	/// </summary>
	public class ReceivedPayment
	{
		public decimal ReceivedAmount { get; set; }
		public string Description { get; set; }
	}
}
