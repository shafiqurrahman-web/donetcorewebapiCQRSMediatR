namespace BBBSLI.DSS.MobileApp.Utility.Application
{
    /// <summary>
    /// Provides access to execution context information, such as user ID.
    /// </summary>
    /// <remarks>
    /// This interface defines properties for retrieving user associated with the current execution context.
    /// It also includes a property to determine if the execution context is available.
    /// </remarks>
    public interface IExecutionContextAccessor
    {
        /// <summary>
        /// Gets User detail from RBAC.
        /// </summary>
        User User { get; }

        /// <summary>
        /// Gets a value indicating whether the current execution context is available.
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// Gets permission from RBAC.
        /// </summary>
        List<string> Permissions { get; }

        /// <summary>
        /// Gets Role from RBAC.
        /// </summary>
        string RoleName { get; }

        /// <summary>
        /// Gets SfCode from Request Header.
        /// </summary>
        string CurrentSfCode { get; }
    }
}