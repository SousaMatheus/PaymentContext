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
    
    
    [TestMethod]
    public void AddSubscription_ShouldReturnSuccess()
    {
        var name = NewName();
        var document = NewDocument();
        var email = NewEmail();
        var address = NewAddress();
        var subscription = NewSubscription();

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
}