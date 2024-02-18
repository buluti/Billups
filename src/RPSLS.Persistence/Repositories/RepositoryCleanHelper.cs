using Microsoft.EntityFrameworkCore;

namespace RPSLS.Persistence.Repositories;

public static class RepositoryCleanHelper
{
    public static void Clear<T>(this DbSet<T> dbSet) where T : class
    {
        if (dbSet.Any())
        {
            dbSet.RemoveRange(dbSet.ToList());
        }
    }
}
