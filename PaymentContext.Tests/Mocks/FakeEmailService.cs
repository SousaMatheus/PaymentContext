using PaymentContext.Domain.EmailService;

namespace PaymentContext.Tests.Mocks;

public class FakeEmailService : IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {

    }
}