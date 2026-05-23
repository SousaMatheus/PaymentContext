namespace PaymentContext.Domain;

public class BoletoPayment : Payment
{
    public BoletoPayment(DateTime expireDate, decimal total, decimal totalPaid, string document,
        string address, string owner, string email, string barCode, string boletoNumber) : base( expireDate,
        total, totalPaid, document, address, owner, email)
    {
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }

    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }
}