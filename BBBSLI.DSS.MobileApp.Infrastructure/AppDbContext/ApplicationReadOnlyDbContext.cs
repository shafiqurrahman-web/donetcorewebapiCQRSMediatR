using Microsoft.EntityFrameworkCore;

namespace BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext
{
    public class ApplicationReadOnlyDbContext : AppDbContextMobile
    {
        public ApplicationReadOnlyDbContext(DbContextOptions<AppDbContextMobile> options)
            : base(options)
        {
        }
    }
}