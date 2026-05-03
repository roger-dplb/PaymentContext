using FluentValidation.TestHelper;
using PaymentContext.Application.Commands;
using PaymentContext.Application.Validators;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Tests.Validators;

public class CreateBoletoPaymentCommandValidatorTests
{
    private readonly CreateBoletoPaymentCommandValidator _validator = new();

    private static CreateBoletoPaymentCommand BuildValidCommand() => new(
        PayerDocumentNumber: "12345678901",
        PayerDocumentType: EDocumentType.Cpf,
        PayerEmail: "joao@example.com",
        Street: "Rua A",
        AddressNumber: "100",
        Neighborhood: "Centro",
        City: "São Paulo",
        State: "SP",
        Country: "BR",
        ZipCode: "01310-100",
        Payer: "João Silva",
        PaidDate: new DateTime(2026, 5, 1),
        ExpireDate: new DateTime(2026, 6, 1),
        Total: 100m,
        TotalPaid: 100m,
        BarCode: "1234567890");

    [Fact]
    public void Validator_WithValidCommand_ShouldNotHaveErrors()
    {
        var command = BuildValidCommand();

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void Validator_WithEmptyPayerEmail_ShouldHaveError()
    {
        var command = BuildValidCommand() with { PayerEmail = "" };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.PayerEmail);
    }

    [Fact]
    public void Validator_WithNegativeTotal_ShouldHaveError()
    {
        var command = BuildValidCommand() with { Total = -1m };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.Total);
    }

    [Fact]
    public void Validator_WithExpireDateBeforePaidDate_ShouldHaveError()
    {
        var command = BuildValidCommand() with
        {
            PaidDate = new DateTime(2026, 6, 1),
            ExpireDate = new DateTime(2026, 5, 1)
        };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.ExpireDate);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Validator_WithEmptyBarCode_ShouldHaveError(string barCode)
    {
        var command = BuildValidCommand() with { BarCode = barCode };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.BarCode);
    }
}
