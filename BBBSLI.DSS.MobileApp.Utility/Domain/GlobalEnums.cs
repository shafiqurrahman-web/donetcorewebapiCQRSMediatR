namespace BBBSLI.DSS.MobileApp.Utility.Domain
{
    /// <summary>
    /// Contains global enumerations used in the application.
    /// </summary>
    public class GlobalEnums
    {
        /// <summary>
        /// Represents different types of audit actions.
        /// </summary>
        public enum AuditType
        {
            /// <summary>
            /// No audit action.
            /// </summary>
            None = 0,

            /// <summary>
            /// Represents an audit action for creating an entity.
            /// </summary>
            Create = 1,

            /// <summary>
            /// Represents an audit action for updating an entity.
            /// </summary>
            Update = 2,

            /// <summary>
            /// Represents an audit action for deleting an entity.
            /// </summary>
            Delete = 3,
        }

        public enum SchoolType
        {
            Inhouse = 1,
            Satellite = 2,
            Feeder = 3,
            Receiver = 4,
        }

        public enum NotificationMedium
        {
            Email = 1,
            InApp = 2
        }

        public enum NotificationStatus
        {
            Pending = 1,
            Processed = 2,
            Sent = 3,
            Seen = 4,
            Failed = 5,
        }
    }
}
