using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    public CreditCardPayment(string cardHolderName, string lastNumbers, string lastTransactionNumber,
        DateTime expireDate, decimal total, decimal totalPaid, Document document, Address address, string owner,
        string email) : base(expireDate, total, totalPaid, document, address, owner, email)
    {
        CardHolderName = cardHolderName;
        LastNumbers = lastNumbers;
        LastTransactionNumber = lastTransactionNumber;
    }

    public string CardHolderName { get; private set; }
    public string LastNumbers { get; private set; }
    public string LastTransactionNumber { get; private set; }
}