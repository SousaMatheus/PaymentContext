using Flunt.Validations;
using PaymentContext.Domain.Enuns;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public string Number { get; }
    public EDocumentType DocumentType { get; }

    public Document(string number, EDocumentType eDocumentType)
    {
        Number = number;
        DocumentType = eDocumentType;

        //exemplo de contract
        AddNotifications(new Contract<Document>()
            .Requires()
            .IsNotNullOrWhiteSpace(Number, "Document.Number", "O documento é obrigatório")
            .IsTrue(IsValidDocument(), "Document.Number", "Documento inválido"));
    }

    public bool IsValidDocument()
    {
        if (string.IsNullOrWhiteSpace(Number))
            return false;

        if (DocumentType == EDocumentType.CNPJ)
            return Number.Length == 14;

        if (DocumentType == EDocumentType.CPF)
            return Number.Length == 11;

        return false;
    }
}