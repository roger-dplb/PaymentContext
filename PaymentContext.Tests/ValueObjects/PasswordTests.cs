using PaymentContext.Domain.Errors;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

public class PasswordTests
{
    [Fact]
    public void Create_WithEmptyValue_ShouldReturnRequiredError()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = Password.Create(input);

        // Assert
        Assert.True(result.IsError);
        Assert.Single(result.Errors);
        Assert.Contains(PasswordErrors.Required, result.Errors);
    }
}
