namespace PaymentContext.Domain;

public class PayPalPayment : Payment
{
    public PayPalPayment(string transactionCode, DateTime expireDate, decimal total, decimal totalPaid,
        string document, string address, string owner, string email) : base(expireDate,
        total, totalPaid, document, address, owner, email)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode { get; private set; }
}