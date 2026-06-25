using Flunt.Validations;

namespace PaymentContext.Domain.Commands.Contracts;

public class CreateCreditCardSubscriptionContract : Contract<CreateCreditCardSubscriptionCommand>
{
    public CreateCreditCardSubscriptionContract(CreateCreditCardSubscriptionCommand creditCardSubsCommand)
    {
        Requires()
        .IsNotNullOrWhiteSpace(creditCardSubsCommand.FirstName, "FirstName", "Nome não pode ser vazio")
        .IsNotNullOrWhiteSpace(creditCardSubsCommand.Document, "Document", "Documento não pode ser vazio")
        .IsNotNullOrWhiteSpace(creditCardSubsCommand.Email, "Email", "Nome não pode ser vazio")
        .IsEmail(creditCardSubsCommand.Email, "Email", "Forneça um e-mail válido");
    }
}