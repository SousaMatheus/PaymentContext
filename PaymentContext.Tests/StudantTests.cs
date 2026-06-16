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

        var studant = new Studant(name, "matheus@gmail.com", document, "Rua 01");
        studant.AddSubscription(subscription);
    }
}