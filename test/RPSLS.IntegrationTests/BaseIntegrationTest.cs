using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RPSLS.Persistence;
using Xunit;

namespace RPSLS.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestsWebAppFactory>
{
    private readonly IServiceScope _scope;
    protected readonly ISender Sender;
    protected readonly ApplicationDbContext DbContext;

    protected BaseIntegrationTest(IntegrationTestsWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();

        DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}
