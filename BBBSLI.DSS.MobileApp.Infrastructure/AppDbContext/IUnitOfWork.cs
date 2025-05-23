using Microsoft.EntityFrameworkCore;

namespace BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Generic repository/dbset to avoid accessing db context directly.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Entity.</returns>
        DbSet<T> Repository<T>() where T : class;

        /// <summary>
        /// Update only fields that required.
        /// </summary>
        /// <param name="oldValues"></param>
        /// <param name="newValues"></param>
        void Patch(object oldValues, object newValues);

        /// <summary>
        /// Apply soft delete to set IsActive = false and IsDeleted = true.
        /// </summary>
        /// <param name="entity">Table.</param>
        void SoftDelete(object entity);

        /// <summary>
        /// Apply changes in DB.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="internalCommandId"></param>
        /// <returns></returns>
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}