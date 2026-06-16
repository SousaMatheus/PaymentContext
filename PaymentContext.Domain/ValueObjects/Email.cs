using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Adress { get; set; } = string.Empty;

    public Email(string adress)
    {
        Adress = adress;
    }
}