using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public abstract class Payment : Entity
{
    protected Payment(DateTime expireDate, decimal total, decimal totalPaid, Document document, Adress adress,
        string owner, Email email)
    {
        Number = Guid.NewGuid().ToString("N").Substring(0, 12).ToUpper();
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Document = document;
        Adress = adress;
        Owner = owner;
        Email = email;

        AddNotifications(new Contract<Payment>()
            .Requires()
            .IsGreaterThan(0, Total, "Payment.Total", "O total não pode ser zero")
            .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "O valor pago é menor que o valor do pagamento"));
    }

    public string Number { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public Document Document { get; private set; }
    public Adress Adress { get; private set; }
    public string Owner { get; private set; }
    public Email Email { get; private set; }
}