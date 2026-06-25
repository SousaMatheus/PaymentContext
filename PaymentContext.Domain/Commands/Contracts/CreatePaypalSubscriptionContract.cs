using Flunt.Validations;

namespace PaymentContext.Domain.Commands.Contracts;

public class CreatePaypalSubscriptionContract : Contract<CreatePayPalSubscriptionCommand>
{
    public CreatePaypalSubscriptionContract(CreatePayPalSubscriptionCommand payPalSubscriptionCommand)
    {
        Requires()
        .IsNotNullOrWhiteSpace(payPalSubscriptionCommand.FirstName, "FirstName", "Nome não pode ser vazio")
        .IsNotNullOrWhiteSpace(payPalSubscriptionCommand.Document, "FirstName", "Documento não pode ser vazio")
        .IsNotNullOrWhiteSpace(payPalSubscriptionCommand.Email, "Email", "Nome não pode ser vazio")
        .IsEmail(payPalSubscriptionCommand.Email, "Email", "Forneça um e-mail válido");
    }
}