using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries;

[TestClass]
public class StudentQueriesTests
{
    private IList<Student> _students = new List<Student>();

    public StudentQueriesTests()
    {
        for (int i = 0; i < 10; i++)
        {
            _students.Add(
                new Student(new Name("Aluno " + i.ToString(), "Sobrenome " + i.ToString()),  
                    new Email(i.ToString() + "@gmail.com"),
                    new Document(i.ToString()+"111111111" + i.ToString(), EDocumentType.CPF),
                    new Address(i.ToString(),  i.ToString(), i.ToString(),  i.ToString(), i.ToString(),  i.ToString(), i.ToString())));
        }
    }
    
    [TestMethod]
    public void ShouldReturnNull_WhenDocumentNotExists()
    {
        var exp = StudentQueries.GetStudentInfo("12345678910");
        var student = _students.AsQueryable().Where(exp).FirstOrDefault();
        
        Assert.IsNull(student);
    }
    
    [TestMethod]
    public void ShouldReturnStudent_WhenDocumentExists()
    {
        var exp = StudentQueries.GetStudentInfo("11111111111");
        var student = _students.AsQueryable().Where(exp).FirstOrDefault();
        
        Assert.IsNotNull(student);
    }
}