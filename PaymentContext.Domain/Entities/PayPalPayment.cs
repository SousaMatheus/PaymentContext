using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PayPalPayment : Payment
{
    public PayPalPayment(string transactionCode, DateTime expireDate, decimal total, decimal totalPaid,
        Document document, Address address, string owner, string email) : base(expireDate,
        total, totalPaid, document, address, owner, email)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode { get; private set; }
}