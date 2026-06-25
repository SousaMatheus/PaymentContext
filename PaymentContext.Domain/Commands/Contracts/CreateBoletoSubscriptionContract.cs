using Flunt.Validations;

namespace PaymentContext.Domain.Commands.Contracts;

public class CreateBoletoSubscriptionContract : Contract<CreateBoletoSubscriptionCommand>
{
    public CreateBoletoSubscriptionContract(CreateBoletoSubscriptionCommand boletoSubsCommand)
    {
        Requires()
        .IsNotNullOrWhiteSpace(boletoSubsCommand.FirstName, "FirstName", "Nome não pode ser vazio")
        .IsNotNullOrWhiteSpace(boletoSubsCommand.Document, "Document", "Documento não pode ser vazio")
        .IsNotNullOrWhiteSpace(boletoSubsCommand.Email, "Email", "Nome não pode ser vazio")
        .IsEmail(boletoSubsCommand.Email, "Email", "Forneça um e-mail válido");
    }
}