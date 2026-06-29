using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public sealed class StudentTests
{
    private static Name NewName() => new Name("Matheus", "Sousa");
    private static Document NewDocument() => new Document("12345678910", Domain.Enuns.EDocumentType.CPF);
    private static Email NewEmail() => new Email("matheus@gmail.com");
    private static Address NewAddress() =>
        new Address("Rua 01", "100", "Jd. Europa", "Sorocaba", "SP", "Brasil", "99999999");
    private static Subscription NewSubscription() => new Subscription(null, NewAddress());
    private static BoletoPayment NewBoletoPayment() =>
        new BoletoPayment(DateTime.Now.AddDays(3), 1000.0m, 1000.0m, NewDocument(), NewAddress(), "Matheus", NewEmail(), "12341234", "12345678910");

    [TestMethod]
    public void AddSubscription_ShouldReturnSuccess()
    {
        var name = NewName();
        var document = NewDocument();
        var email = NewEmail();
        var address = NewAddress();
        var subscription = NewSubscription();
        subscription.AddPayment(NewBoletoPayment());

        var student = new Student(name, email, document, address);
        student.AddSubscription(subscription);
        
        Assert.IsTrue(student.IsValid);
    }

    [TestMethod]
    public void AddTwoSubscriptions_ShouldReturnError()
    {
        var name = NewName();
        var document = NewDocument();
        var email = NewEmail();
        var address = NewAddress();
        var subscription = NewSubscription();

        var student = new Student(name, email, document, address);
        student.AddSubscription(subscription);
        student.AddSubscription(subscription);

        Assert.IsFalse(student.IsValid);
    }

    [TestMethod]
    public void AddSubscriptionsWithNoPayment_ShouldReturnError()
    {
        var name = NewName();
        var document = NewDocument();
        var email = NewEmail();
        var address = NewAddress();
        var subscription = NewSubscription();

        var student = new Student(name, email, document, address);
        student.AddSubscription(subscription);

        Assert.IsFalse(student.IsValid);
    }

    [TestMethod]
    public void AddSubscriptionsWithBoletoPayment_ShouldReturnSuccess()
    {
        var name = NewName();
        var document = NewDocument();
        var email = NewEmail();
        var address = NewAddress();
        var subscription = NewSubscription();
        var boletoPayment = NewBoletoPayment();
        subscription.AddPayment(boletoPayment);

        var student = new Student(name, email, document, address);
        student.AddSubscription(subscription);

        Assert.IsTrue(student.IsValid);
    }
}