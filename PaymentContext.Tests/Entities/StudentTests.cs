using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void Should_Create_Student()
    {
        var subscription = new Subscription(DateTime.Now.AddDays(30));
        var student = new Student("Joao", "Doidao", "", "", "", new List<Subscription>());
        
        student.AddSubscription(subscription);
        
        Assert.IsNotNull(student);
    }
}