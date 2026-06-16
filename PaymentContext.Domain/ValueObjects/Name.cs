using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;

    public Name(string firstName, string lastName)
    {
        if (firstName.Length < 3)
            throw new Exception("O nome deve conter mais de 3 caracteres");

        if (lastName.Length < 3)
            throw new Exception("O sobrenome deve conter mais de 3 caracteres");
    }
}
