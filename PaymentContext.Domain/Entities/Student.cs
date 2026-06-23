using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    public Student(Name name, Email email, Document document, Address adress)
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
    public Address Adress { get; private set; }

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

        AddNotifications(new Contract<Student>()
            .Requires()
            .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
            .IsLowerOrEqualsThan(0, subscription.Payments.Count, "Subscription.Payments", "Essa assinatura não possui pagamentos")
        );

        // alternativa
        // if (hasSubscriptionActive)
        //     AddNotification("Studant.Subscriptions", "Você já tem uma assinatura ativa");

        _subscriptions.Add(subscription);
    }
}