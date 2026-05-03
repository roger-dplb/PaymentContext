using PaymentContext.Domain.Errors;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

public class EmailTests
{
    [Theory]
    [InlineData("user@example.com")]
    [InlineData("first.last@example.com")]
    [InlineData("user+tag@example.com")]
    [InlineData("user@sub.example.com")]
    [InlineData("user@example.co.uk")]
    [InlineData("USER@EXAMPLE.COM")]
    public void Create_WithValidEmail_ShouldReturnSuccess(string input)
    {
        var result = Email.Create(input);

        Assert.False(result.IsError);
        Assert.Equal(input, result.Value.Address);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithNullOrWhitespace_ShouldReturnRequiredError(string? input)
    {
        var result = Email.Create(input!);

        Assert.True(result.IsError);
        Assert.Single(result.Errors);
        Assert.Contains(EmailErrors.Required, result.Errors);
    }

    [Theory]
    [InlineData("noatsign.example.com")]      // sem @
    [InlineData("@example.com")]              // @ sem usuário
    [InlineData("user@")]                     // sem domínio
    [InlineData("user@example")]              // sem TLD
    [InlineData("user@@example.com")]         // dois @
    [InlineData("user @example.com")]         // espaço no usuário
    [InlineData("user@exa mple.com")]         // espaço no domínio
    [InlineData("user@.com")]                 // domínio inválido
    public void Create_WithInvalidFormat_ShouldReturnInvalidError(string input)
    {
        var result = Email.Create(input);

        Assert.True(result.IsError);
        Assert.Single(result.Errors);
        Assert.Contains(EmailErrors.Invalid, result.Errors);
    }

    [Fact]
    public void Equality_TwoEmailsWithSameAddress_ShouldBeEqual()
    {
        // Arrange
        var first = Email.Create("user@example.com");
        var second = Email.Create("user@example.com");

        // Act / Assert
        Assert.Equal(first.Value, second.Value);
        Assert.True(first.Value == second.Value);
    }

    [Fact]
    public void Equality_TwoEmailsWithDifferentAddress_ShouldNotBeEqual()
    {
        // Arrange
        var first = Email.Create("user1@example.com");
        var second = Email.Create("user2@example.com");

        // Act / Assert
        Assert.NotEqual(first.Value, second.Value);
        Assert.False(first.Value == second.Value);
    }
}
