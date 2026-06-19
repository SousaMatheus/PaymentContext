using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment : Payment
{
    public BoletoPayment(DateTime expireDate, decimal total, decimal totalPaid, Document document,
        Adress address, string owner, Email email, string barCode, string boletoNumber) : base(expireDate,
        total, totalPaid, document, address, owner, email)
    {
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }

    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }
}