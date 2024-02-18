using Microsoft.EntityFrameworkCore;
using RPSLS.Persistence;

namespace RPSLS.Api.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var dbContext = scope.ServiceProvider.
                GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
