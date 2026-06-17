using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Name(string firstName, string lastName)
    {
        if(string.IsNullOrEmpty(firstName))
            AddNotification("Name.FirstName", "O nome é obrigatório");
        
        if (firstName.Length < 3)
            throw new Exception("O nome deve conter mais de 3 caracteres");

        if (lastName.Length < 3)
            throw new Exception("O sobrenome deve conter mais de 3 caracteres");
        
        FirstName = firstName;
        LastName = lastName;
    }
}
