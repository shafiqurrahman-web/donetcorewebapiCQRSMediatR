namespace BBBSLI.DSS.MobileApp.Utility.Domain.Mappings
{
    using Mapster;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Provides utility methods for mapping and adapting objects using the Mapster library.
    /// </summary>
    public static class DSSMapper
    {
        /// <summary>
        /// Maps and projects a queryable entity to a destination type.
        /// </summary>
        /// <typeparam name="T">The destination type.</typeparam>
        /// <param name="entity">The queryable entity to be projected.</param>
        /// <returns>A projected queryable of the destination type.</returns>
        public static IQueryable<T> To<T>(this IQueryable entity)
            where T : class
        {
            return entity.ProjectToType<T>();
        }

        /// <summary>
        /// Maps and projects a DbSet to a destination type.
        /// </summary>
        /// <typeparam name="T">The destination type.</typeparam>
        /// <param name="entity">The DbSet to be projected.</param>
        /// <returns>A projected queryable of the destination type.</returns>
        public static IQueryable<T> To<T>(this DbSet<T> entity)
            where T : class
        {
            return entity.ProjectToType<T>();
        }

        /// <summary>
        /// Maps an object to a destination type.
        /// </summary>
        /// <typeparam name="TDestination">The destination type.</typeparam>
        /// <param name="source">The source object to be mapped.</param>
        /// <returns>The mapped object of the destination type.</returns>
        public static TDestination MapTo<TDestination>(this object source)
        {
            return source.Adapt<TDestination>();
        }
    }
}
