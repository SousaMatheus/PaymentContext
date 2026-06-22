using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Subscription : Entity
{
    private List<Payment> _payments;

    public Subscription(DateTime? expireDate, Address adress)
    {
        CreateDate = DateTime.UtcNow;
        LastUpdate = DateTime.UtcNow;
        IsActive = true;
        ExpireDate = expireDate;
        _payments = new List<Payment>();
        Address = adress;
    }

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool IsActive { get; private set; }
    public Address Address { get; private set; }

    public IReadOnlyCollection<Payment> Payments
    {
        get { return _payments.AsReadOnly(); }
    }

    public void AddPayment(Payment payment)
    {

        AddNotifications(new Contract<Subscription>()
        .Requires()
        .IsGreaterThan(DateTime.Now, payment.PaymentDate, "Subscription.Payments", "A data do pagamento deve ser futura"));

        if (IsValid)
            _payments.Add(payment);
    }
    public void Activate()
    {
        IsActive = true;
        LastUpdate = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        LastUpdate = DateTime.UtcNow;
    }
}