using ErrorOr;
using PaymentContext.Common.ValueObjects;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Errors;

namespace PaymentContext.Domain.ValueObjects;

public sealed record Document : ValueObject
{
    public string Number { get; }
    public EDocumentType Type { get; }

    private Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;
    }

    public static ErrorOr<Document> Create(string number, EDocumentType type)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            return DocumentErrors.Required;
        }

        var digits = new string(number.Where(char.IsDigit).ToArray());

        return type switch
        {
            EDocumentType.Cpf when digits.Length != 11 => DocumentErrors.InvalidCpf,
            EDocumentType.Cnpj when digits.Length != 14 => DocumentErrors.InvalidCnpj,
            _ => new Document(digits, type)
        };
    }
}
