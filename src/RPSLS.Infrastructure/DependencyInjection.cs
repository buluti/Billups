using Microsoft.Extensions.DependencyInjection;
using RPSLS.Domain.Interfaces;
using RPSLS.Infrastructure.Services;

namespace RPSLS.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddHttpClient<BoohmaGetRandomNumberService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://codechallenge.boohma.com");
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new SocketsHttpHandler
                {
                    PooledConnectionLifetime = TimeSpan.FromMinutes(5)
                };
            })
            .SetHandlerLifetime(Timeout.InfiniteTimeSpan);
            services.AddScoped<IRandomGameChoice, RandomGameChoice>();

            return services;
        }
    }
}
