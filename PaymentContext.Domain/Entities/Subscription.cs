namespace PaymentContext.Domain;

public class Subscription
{
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool Active { get; private set; }
    public string Adress { get; private set; }
    public List<Payment> Payments { get; private set; }
}