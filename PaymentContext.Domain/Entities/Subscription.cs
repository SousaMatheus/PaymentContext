namespace PaymentContext.Domain.Entities;

public class Subscription
{
    private List<Payment> _payments;

    public Subscription(DateTime? expireDate)
    {
        CreateDate = DateTime.UtcNow;
        LastUpdate = DateTime.UtcNow;
        IsActive = true;
        ExpireDate = expireDate;
        _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool IsActive { get; private set; }
    public string Address { get; private set; } = string.Empty;

    public IReadOnlyCollection<Payment> Payments
    {
        get { return _payments.AsReadOnly(); }
    }

    public void AddPayment(Payment payment)
    {
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