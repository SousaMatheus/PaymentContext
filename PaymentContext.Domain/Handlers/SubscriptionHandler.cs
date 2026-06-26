using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.EmailService;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler : Notifiable<Notification>, 
    IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreatePayPalSubscriptionCommand>,
    IHandler<CreateCreditCardSubscriptionCommand>
{
    private readonly IStudantRepository _studantRepository;
    private readonly IEmailService _emailService;

    public SubscriptionHandler(IStudantRepository studantRepository, IEmailService emailService)
    {
        _studantRepository = studantRepository;
        _emailService = emailService;
    }

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        var documentExists = _studantRepository.DocumentExists(command.Document);
        if (documentExists)
            AddNotification("Documment", "Documento já está em uso");

        var emailExists = _studantRepository.EmailExists(command.Email);
        if (emailExists)
            AddNotification("Email", "Email já está em uso");

        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, command.PayerDocumentType);
        var email = new Email(command.Email);
        var address = new Address(
            command.Street,
            command.Number,
            command.Neighborhood,
            command.City,
            command.State,
            command.Country,
            command.ZipCode);

        var subscription = new Subscription(DateTime.Now.AddDays(30), address);
        var student = new Student(name, email, document, address);
        var payment = new BoletoPayment(
            command.PaymentDate,
            command.Total,
            command.TotalPaid,
            document,
            address,
            command.PayerDocument,
            email,
            command.BarCode,
            command.Number);

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);
        
        AddNotifications(name, document, email, address, student, payment, subscription);
        
        _studantRepository.CreateSubscription(student);
        
        _emailService.SendEmail(student.Name.ToString(), "Assinatura realizada com sucesso", "Seja bem-vindo");
        
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }

    public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        var documentExists = _studantRepository.DocumentExists(command.Document);
        if (documentExists)
            AddNotification("Documment", "Documento já está em uso");

        var emailExists = _studantRepository.EmailExists(command.Email);
        if (emailExists)
            AddNotification("Email", "Email já está em uso");

        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, command.PayerDocumentType);
        var email = new Email(command.Email);
        var address = new Address(
            command.Street,
            command.Number,
            command.Neighborhood,
            command.City,
            command.State,
            command.Country,
            command.ZipCode);

        var subscription = new Subscription(DateTime.Now.AddDays(30), address);
        var student = new Student(name, email, document, address);
        var payment = new PayPalPayment(
            command.TransactionCode,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            document,
            address,
            command.PayerDocument,
            email);

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);
        
        AddNotifications(name, document, email, address, student, payment, subscription);
        
        _studantRepository.CreateSubscription(student);
        
        _emailService.SendEmail(student.Name.ToString(), "Assinatura realizada com sucesso", "Seja bem-vindo");
        
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }

    public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        var documentExists = _studantRepository.DocumentExists(command.Document);
        if (documentExists)
            AddNotification("Documment", "Documento já está em uso");

        var emailExists = _studantRepository.EmailExists(command.Email);
        if (emailExists)
            AddNotification("Email", "Email já está em uso");

        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, command.PayerDocumentType);
        var email = new Email(command.Email);
        var address = new Address(
            command.Street,
            command.Number,
            command.Neighborhood,
            command.City,
            command.State,
            command.Country,
            command.ZipCode);

        var subscription = new Subscription(DateTime.Now.AddDays(30), address);
        var student = new Student(name, email, document, address);
        var payment = new CreditCardPayment(
            command.CardHolderName,
            command.LastNumbers,
            command.LastTransactionNumber,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            document,
            address,
            command.PayerDocument,
            email);

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);
        
        AddNotifications(name, document, email, address, student, payment, subscription);
        
        _studantRepository.CreateSubscription(student);
        
        _emailService.SendEmail(student.Name.ToString(), "Assinatura realizada com sucesso", "Seja bem-vindo");
        
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }
}