using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PaymentContext.Application.Behaviors;

namespace PaymentContext.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        // Registra todos os IRequestHandler<,> do assembly
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        // Registra todos os AbstractValidator<T> do assembly
        services.AddValidatorsFromAssembly(assembly);

        // Plugga o ValidationBehavior no pipeline (roda antes de qualquer Handler)
        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        return services;
    }
}
