using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain;

public class Studant : Entity
{
    public Studant(string firstName, string lastName, string email, string document, string adress, List<Subscription> subscriptions)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Document = document;
        Adress = adress;
        Subscriptions = subscriptions;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Document { get; private set; }
    public string Adress { get; private set; }
    public IReadOnlyCollection<Subscription> Subscriptions { get; private set; }
}
