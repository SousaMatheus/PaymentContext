using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Repositories;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>
{
    private readonly IStudantRepository _studantRepository;

    public SubscriptionHandler(IStudantRepository studantRepository)
    {
        _studantRepository = studantRepository;
    }
    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        //Verificar se o documento ja existe
        var documentExists = _studantRepository.DocumentExists(command.Document);
        if (documentExists)
            AddNotification("Documment", "Documento já está em uso");

        //Verificar se o email ja existe
        var emailExists = _studantRepository.EmailExists(command.Email);
        if (emailExists)
            AddNotification("Email", "Email já está em uso");
        //Gera VOs
        //Gerar entidades
        //aplicar as validações
        //salvar as informações
        //enviar email de boas vindas
        //retornar informações
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }
}