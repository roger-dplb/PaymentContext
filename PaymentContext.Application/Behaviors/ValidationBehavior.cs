using ErrorOr;
using FluentValidation;
using MediatR;

namespace PaymentContext.Application.Behaviors;

/// <summary>
/// Pipeline behavior do MediatR que executa todos os FluentValidation validators
/// registrados para o request antes de chamar o handler. Se o request implementa
/// IErrorOr, retorna os erros como Validation; caso contrário, lança ValidationException.
/// </summary>
public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        => _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next(cancellationToken);
        }

        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure is not null)
            .ToList();

        if (failures.Count == 0)
        {
            return await next(cancellationToken);
        }

        // Se TResponse é ErrorOr<T>, retornamos os erros sem lançar exception
        if (typeof(TResponse).IsGenericType &&
            typeof(TResponse).GetGenericTypeDefinition() == typeof(ErrorOr<>))
        {
            var errors = failures
                .Select(f => Error.Validation(f.PropertyName, f.ErrorMessage))
                .ToList();

            // Usa reflection pra construir o ErrorOr<T>.From(errors)
            var fromMethod = typeof(ErrorOr<>)
                .MakeGenericType(typeof(TResponse).GetGenericArguments()[0])
                .GetMethod("op_Implicit", new[] { typeof(List<Error>) });

            return (TResponse)fromMethod!.Invoke(null, [errors])!;
        }

        // Fallback — lança exception se TResponse não for ErrorOr
        throw new ValidationException(failures);
    }
}
