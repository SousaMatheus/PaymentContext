using PaymentContext.Domain;

namespace PaymentContext.Tests;

[TestClass]
public sealed class StudantTests
{
    [TestMethod]
    public void AdicionarSubscription()
    {
        var subscription = new Subscription(null);
        var studant = new Studant("Matheus", "Sousa", "matheus@gmail.com", "12345678910", "Rua 01");
        studant.AddSubscription(subscription);  
    }
}