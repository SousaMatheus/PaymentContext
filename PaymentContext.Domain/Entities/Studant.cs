using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Studant : Entity
{
    public Studant(Name name, string email, Document document, string adress)
    {
        Name = name;
        Email = email;
        Document = document;
        Adress = adress;
        _subscriptions = new List<Subscription>();
    }

    private IList<Subscription> _subscriptions;
    public Name Name { get; private set; }
    public string Email { get; private set; }
    public Document Document { get; private set; }
    public string Adress { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions
    {
        get { return _subscriptions.ToArray(); }
    }

    public void AddSubscription(Subscription subscription)
    {
        foreach (var sub in _subscriptions)
        {
            sub.Deactivate();
        }
        _subscriptions.Add(subscription);
    }
}