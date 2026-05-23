using System.Security.Principal;

namespace PaymentContext.Domain;

public abstract class Payment
{
    public string Number { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Document { get; private set; }
    public string Adress { get; private set; }
    public string Owner { get; private set; }
    public string Email { get; private set; }
}

public class BoletoPayment : Payment
{
    public string BarCode { get;private set; }
    public string BoletoNumber { get;private set; }
}

public class CreditCardPayment : Payment
{
    public string CardHolderName { get; private set; }
    public string LastNumbers { get; private set; }
    public string LastTransactionNumber { get; private set; }
}

public class PayPalPayment : Payment
{
    public string TransactionCode { get; private set; }
}