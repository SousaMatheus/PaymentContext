using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public sealed class StudentTests
{
    [TestMethod]
    public void AdicionarSubscription()
    {
        var subscription = new Subscription(null);
        var name = new Name("Matheus", "Sousa");
        var document = new Document("12345678910", Domain.Enuns.EDocumentType.CPF);
        var email = new Email("matheus@gmail.com");
        var adress = new Address("Rua 01");

        var studant = new Student(name, email, document, adress);
        studant.AddSubscription(subscription);
    }
}