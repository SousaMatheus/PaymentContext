using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands;

[TestClass]
public class BoletoSubscriptionCommandTest
{
    [TestMethod]
    [DataRow("")]

    public void BoletoInvalid_ShouldReturnError(string nome)
    {
        var boletoCommand = new CreateBoletoSubscriptionCommand();
        boletoCommand.FirstName = nome;

        boletoCommand.Validate();

        Assert.IsFalse(boletoCommand.IsValid);
    }
}