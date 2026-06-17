using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    public Student(Name name, Email email, Document document, Address address)
    {
        Name = name;
        Email = email;
        Document = document;
        Address = address;
        _subscriptions = new List<Subscription>();
        
        AddNotifications(name, email, document, address);
    }

    private IList<Subscription> _subscriptions;
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }

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