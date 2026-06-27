using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTest
{
    [TestMethod]
    public void ShouldReturnError_WhenDocumentExists()
    {
        var fakeStudentRepository = new FakeStudentRepository();
        var fakeEmailService = new FakeEmailService();
        var handler = new SubscriptionHandler(fakeStudentRepository, fakeEmailService);

        var command = new CreateBoletoSubscriptionCommand();

        command.FirstName = "Bruce";
        command.LastName = "Wayne";
        command.Document = "99999999999";
        command.Email = "batman@dc.com";

        command.BarCode = "123123456";
        command.BoletoNumber = "1234567890";
        command.PayerNumber = "";
        command.PaymentDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddDays(30);
        command.Total = 1000;
        command.TotalPaid = 1000;
        command.PayerDocument = "123123123";
        command.PayerDocumentType = Domain.Enuns.EDocumentType.CPF;
        command.PayerEmail = "batman@dc.com";

        command.Adress = "Rua do batman";
        command.Street = "Park Drive";
        command.Number = "224";
        command.Neighborhood = "Wayne";
        command.City = "Gotham";
        command.State = "Nova Jersey";
        command.Country = "US";
        command.ZipCode = "12399999";

        handler.Handle(command);

        Assert.IsFalse(handler.IsValid);
    }
}