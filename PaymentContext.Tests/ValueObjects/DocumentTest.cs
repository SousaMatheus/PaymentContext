namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTest
{
    [TestMethod]
    [DataRow("")]
    [DataRow("123")]
    [DataRow("ABC")]
    public void CNPJInvalid_ShouldReturnError(string cnpj)
    {
        
    }
    
    [TestMethod]
    [DataRow("91991312000160")]
    [DataRow("97727294000190")]
    [DataRow("31001221000108")]
    public void CNPJValid_ShouldReturnSuccess(string cnpj)
    {
        
    }
}