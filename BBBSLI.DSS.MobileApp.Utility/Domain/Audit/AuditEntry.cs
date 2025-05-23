using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using static BBBSLI.DSS.MobileApp.Utility.Domain.GlobalEnums;

namespace BBBSLI.DSS.MobileApp.Utility.Domain.Audit
{
    /// <summary>
    /// Represents an audit entry for tracking changes to entities.
    /// </summary>
    public class AuditEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditEntry"/> class with the specified <paramref name="entry"/>.
        /// </summary>
        /// <param name="entry">The entity entry to track.</param>
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        /// <summary>
        /// Gets the entity entry being tracked.
        /// </summary>
        public EntityEntry Entry { get; }

        /// <summary>
        /// Gets or sets the user ID associated with the audit entry.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the database table associated with the audit entry.
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the Entity ID associated with the audit entry.
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the SfCode associated with the audit entry.
        /// </summary>
        public string SfCode { get; set; }

        /// <summary>
        /// Gets a dictionary of key values representing the primary key of the entity.
        /// </summary>
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();

        /// <summary>
        /// Gets a dictionary of old property values before the change.
        /// </summary>
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();

        /// <summary>
        /// Gets a dictionary of new property values after the change.
        /// </summary>
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets the type of audit entry (e.g., Insert, Update, Delete).
        /// </summary>
        public AuditType AuditType { get; set; }

        /// <summary>
        /// Gets a list of names of columns that were changed during the operation.
        /// </summary>
        public List<string> ChangedColumns { get; } = new List<string>();

        /// <summary>
        /// Converts the audit entry to an <see cref="AuditTrail"/> object.
        /// </summary>
        /// <returns>An <see cref="AuditTrail"/> object representing the audit entry.</returns>
        public AuditTrail ToAudit()
        {
            var audit = new AuditTrail();
            audit.Id = Guid.NewGuid();
            audit.UserId = UserId;
            audit.Type = AuditType.ToString();
            audit.TableName = TableName;
            audit.DateTime = DateTime.Now;
            audit.EntityId = EntityId;
            audit.OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues);
            audit.AffectedColumns = ChangedColumns.Count == 0 ? null : JsonSerializer.Serialize(ChangedColumns);
            audit.SfCode = SfCode;
            return audit;
        }
    }
}
