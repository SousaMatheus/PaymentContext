using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Adress { get; }

    public Email(string adress)
    {
        if (string.IsNullOrWhiteSpace(adress))
            throw new ArgumentException("O email não pode ser nulo");

        adress = adress.Trim();

        if (adress.Length < 5)
            throw new ArgumentException("O email deve conter pelo menos 5 caracteres");


    }
}