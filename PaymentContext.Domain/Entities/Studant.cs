using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain;

public class Studant : Entity
{
    public Studant(string firstName, string lastName, string email, string document, string adress)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Document = document;
        Adress = adress;
        _subscriptions  = new List<Subscription>();
    }

    private IList<Subscription> _subscriptions;
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Document { get; private set; }
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