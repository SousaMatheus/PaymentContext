using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public sealed class StudantTests
{
    [TestMethod]
    public void AdicionarSubscription()
    {
        var subscription = new Subscription(null);
        var name = new Name("Matheus", "Sousa");
        var document = new Document("12345678910", Domain.Enuns.EDocumentType.CPF);
        var email = new Email("matheus@gmail.com");
        var address = new Adress("Rua 01", "100", "Jd. Europa", "Sorocaba", "SP", "Brasil", "99999999");

        var studant = new Studant(name, email, document, address);
        studant.AddSubscription(subscription);
    }
}