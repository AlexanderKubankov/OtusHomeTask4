using Microsoft.EntityFrameworkCore;

namespace Api.Data.Migrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dataContext = new DataContextFactory().CreateDbContext(args);
            dataContext.Database.Migrate();
        }
    }
}
