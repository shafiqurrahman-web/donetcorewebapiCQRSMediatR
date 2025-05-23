using System.Data;

namespace BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext
{
    public interface IReadonlyDbContext
    {
        /// <summary>
        /// Fetch table as IQueryable to process further.
        /// </summary>
        /// <typeparam name="T">Table.</typeparam>
        /// <returns>IQueryable.<T></returns>
        IQueryable<T> Query<T>()
            where T : class;

        /// <summary>
        /// Open db connection.
        /// </summary>
        /// <returns>IDbConnection.</returns>
        IDbConnection GetOpenConnection();
    }
}