using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using RPSLS.Application.Behaviuors;

namespace RPSLS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });
            services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>(
                includeInternalTypes: true);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBeaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
            services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();
            services.Configure<RouteHandlerOptions>(o => o.ThrowOnBadRequest = true);

            return services;
        }
    }
}
