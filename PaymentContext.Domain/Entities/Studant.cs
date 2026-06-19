using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Studant : Entity
{
    public Studant(Name name, Email email, Document document, Adress adress)
    {
        Name = name;
        Email = email;
        Document = document;
        Adress = adress;
        _subscriptions = new List<Subscription>();

        AddNotifications(name, document, email, adress);
    }

    private IList<Subscription> _subscriptions;
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Document Document { get; private set; }
    public Adress Adress { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions
    {
        get { return _subscriptions.ToArray(); }
    }

    public void AddSubscription(Subscription subscription)
    {
        var hasSubscriptionActive = false;

        foreach (var sub in _subscriptions)
        {
            if (sub.IsActive)
                hasSubscriptionActive = true;
        }

        if (hasSubscriptionActive)
            AddNotification("Studant.Subscriptions", "Você já tem uma assinatura ativa");

        //alternativa
        // AddNotifications(new Contract()
        //         .Requires()
        //         .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
        //     );

        _subscriptions.Add(subscription);
    }
}