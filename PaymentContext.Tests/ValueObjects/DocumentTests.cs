using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Errors;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

public class DocumentTests
{
    [Fact]
    public void Create_WithValidCpf_ShouldReturnSuccess()
    {
        // Arrange
        const string validCpf = "12345678901";

        // Act
        var result = Document.Create(validCpf, EDocumentType.Cpf);

        // Assert
        Assert.False(result.IsError);
        Assert.Equal(validCpf, result.Value.Number);
        Assert.Equal(EDocumentType.Cpf, result.Value.Type);
    }

    [Fact]
    public void Create_WithEmptyNumber_ShouldReturnRequiredError()
    {
        // Arrange
        const string empty = "";

        // Act
        var result = Document.Create(empty, EDocumentType.Cpf);

        // Assert
        Assert.True(result.IsError);
        Assert.Single(result.Errors);
        Assert.Contains(DocumentErrors.Required, result.Errors);
    }

    [Fact]
    public void Create_WithValidCnpjOnlyDigits_ShouldReturnSuccess()
    {
        const string validCnpj = "12345678901234";

        var result = Document.Create(validCnpj, EDocumentType.Cnpj);

        Assert.False(result.IsError);
        Assert.Equal(validCnpj, result.Value.Number);
        Assert.Equal(EDocumentType.Cnpj, result.Value.Type);
    }

    [Fact]
    public void Create_WithFormattedCnpj_ShouldNormalizeToOnlyDigits()
    {
        const string formattedCnpj = "12.345.678/9012-34";
        const string expectedDigitsOnly = "12345678901234";

        var result = Document.Create(formattedCnpj, EDocumentType.Cnpj);

        Assert.False(result.IsError);
        Assert.Equal(expectedDigitsOnly, result.Value.Number);
    }
}
