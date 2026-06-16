using PaymentContext.Domain.Enuns;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public string Number { get; private set; }
    public EDocumentType DocumentType { get; private set; }

    public Document(string number, EDocumentType eDocumentType)
    {
        Number = number;
        DocumentType = eDocumentType;
    }
}