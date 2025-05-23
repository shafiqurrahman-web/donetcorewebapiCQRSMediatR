using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext
{
    public class ReadonlyDbContext : IReadonlyDbContext
    {
        private readonly AppDbContextMobile readonlyDbContext;
        public ReadonlyDbContext(AppDbContextMobile readonlyDbContext)
        {
            this.readonlyDbContext = readonlyDbContext;
        }

        /// <inheritdoc/>
        public IQueryable<T> Query<T>()
        where T : class
        => readonlyDbContext.Set<T>().AsQueryable();

        /// <inheritdoc/>
        public IDbConnection GetOpenConnection()
            => new SqlConnection(readonlyDbContext.Database.GetConnectionString());
    }
}