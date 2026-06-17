using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public abstract class Payment
{
    protected Payment(DateTime expireDate, decimal total, decimal totalPaid, Document document, Address address,
        string owner, string email)
    {
        Number = Guid.NewGuid().ToString("N").Substring(0, 12).ToUpper();
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Document = document;
        Address = address;
        Owner = owner;
        Email = email;
    }

    public string Number { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public string Owner { get; private set; }
    public string Email { get; private set; }
}