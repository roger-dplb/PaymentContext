using ErrorOr;

namespace PaymentContext.Domain.Errors;

public static class DocumentErrors
{
    public static Error Required =>
        Error.Validation("Document.Required", "Document is required.");

    public static Error InvalidCpf =>
        Error.Validation("Document.Cpf.Invalid", "CPF must have 11 digits.");

    public static Error InvalidCnpj =>
        Error.Validation("Document.Cnpj.Invalid", "CNPJ must have 14 digits.");
}
