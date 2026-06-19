using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public string FirstName { get; }
    public string LastName { get; }

    public Name(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("O nome não pode ser nulo");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("O sobrenome não pode ser nulo");

        firstName = firstName.Trim();
        lastName = lastName.Trim();

        if (firstName.Length < 3)
            throw new ArgumentException("O nome deve conter pelo menos 3 caracteres");

        if (lastName.Length < 3)
            throw new ArgumentException("O sobrenome deve conter pelo menos 3 caracteres");

        FirstName = firstName;
        LastName = lastName;
    }
}
