using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationService(this IServiceCollection services)
    {
        return services;
    }
}