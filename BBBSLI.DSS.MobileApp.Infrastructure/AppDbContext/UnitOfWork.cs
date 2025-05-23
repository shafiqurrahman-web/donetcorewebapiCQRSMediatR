namespace BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext
{
    using BBBSLI.DSS.MobileApp.Utility.Application;
    using BBBSLI.DSS.MobileApp.Utility.Domain;
    using BBBSLI.DSS.MobileApp.Utility.Domain.Audit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using static BBBSLI.DSS.MobileApp.Utility.Domain.GlobalEnums;

    public class UnitOfWork :  IUnitOfWork
    {
        /// <summary>
        /// Audit Fields.
        /// </summary>
        private const string
            CreatedBy = "CreatedBy",
            CreatedOn = "CreatedOn",
            UpdatedBy = "UpdatedBy",
            UpdatedOn = "UpdatedOn",
            DonorCode = "DonorCode";

        DateTime _now;
        private readonly AppDbContextMobile context;
        private readonly IExecutionContextAccessor executionContextAccessor;
        private string userId = null;
        private string currentSfCode = null;

        public UnitOfWork(AppDbContextMobile context, IExecutionContextAccessor executionContextAccessor)
        {
            this.context = context;
            this.executionContextAccessor = executionContextAccessor;
            userId = this.executionContextAccessor?.User?.Id;
        }

        /// <summary>
        /// Database table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public DbSet<T> Repository<T>()
            where T : class
            => context.Set<T>();

        /// <summary>
        /// Update only fields that required.
        /// </summary>
        /// <param name="oldValues"></param>
        /// <param name="newValues"></param>
        public void Patch(object oldValues, object newValues)
        => context.Entry(oldValues).CurrentValues.SetValues(newValues);

        /// <summary>
        /// Apply soft delete to set IsActive = false and IsDeleted = true.
        /// </summary>
        /// <param name="entity">Table.</param>
        public void SoftDelete(object entity)
        => context.Entry(entity).CurrentValues.SetValues(new { IsDeleted = true, IsActive = false, UpdatedBy = userId ?? GlobalConstants.User.System, UpdatedOn = DateTime.Now });

        /// <inheritdoc/>
        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            await OnBeforeSaveChangesAsync(userId, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken);
        }

        private async Task OnBeforeSaveChangesAsync(string userId, CancellationToken cancellationToken)
        {
            currentSfCode = executionContextAccessor.CurrentSfCode;

            context.ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            _now = DateTime.Now;

            string[] auditableEntities = GlobalConstants.AuditableEntities.Entities;

            context.ChangeTracker.Entries().ToList().ForEach(entry =>
            {
                AuditEntry auditEntry = new(entry);

                if (auditableEntities.Any(e => e.Equals(entry.Entity.GetType().Name, StringComparison.OrdinalIgnoreCase))
                                      && (entry.State != EntityState.Detached || entry.State != EntityState.Unchanged))
                {
                    auditEntry.TableName = entry.Entity.GetType().Name;
                    auditEntry.UserId = userId;
                    auditEntry.SfCode = currentSfCode;
                    auditEntries.Add(auditEntry);
                }

                entry.Properties.ToList().ForEach(property =>
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.EntityId = property.CurrentValue?.ToString();
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            this.SetCreatedAuditValues(userId, auditEntry, property, propertyName);
                            if (!currentSfCode.IsNullOrBlank())
                            {
                                this.SetSfCodeValue(currentSfCode, auditEntry, property, propertyName);
                            }

                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            this.SetUpdatedAuditValues(userId, auditEntry, property, propertyName);
                            break;
                    }
                });
            });

            await SaveAuditAsync(auditEntries, cancellationToken);
        }

        private async Task SaveAuditAsync(List<AuditEntry> auditEntries, CancellationToken cancellationToken)
        {
            var auditTrails = new List<AuditTrail>();
            foreach (var auditEntry in auditEntries)
            {
                auditTrails.Add(auditEntry.ToAudit());
            }

            if (auditEntries.Any())
            {
                await context.AddRangeAsync(auditTrails, cancellationToken);
            }
        }

        private void SetCreatedAuditValues(string userId, AuditEntry auditEntry, PropertyEntry property, string propertyName)
        {
            auditEntry.AuditType = AuditType.Create;
            auditEntry.NewValues[propertyName] = property.CurrentValue;

            if (propertyName.Equals(CreatedBy, StringComparison.OrdinalIgnoreCase))
            {
                property.CurrentValue = userId;
            }

            if (propertyName.Equals(CreatedOn, StringComparison.OrdinalIgnoreCase))
            {
                property.CurrentValue = _now;
            }
        }

        private void SetSfCodeValue(string donorCode, AuditEntry auditEntry, PropertyEntry property, string propertyName)
        {
            auditEntry.AuditType = AuditType.Create;
            auditEntry.NewValues[propertyName] = property.CurrentValue;

            if (propertyName.Equals(DonorCode, StringComparison.OrdinalIgnoreCase))
            {
                property.CurrentValue = donorCode;
            }
        }

        private void SetUpdatedAuditValues(string userId, AuditEntry auditEntry, PropertyEntry property, string propertyName)
        {
            if (propertyName.Equals(CreatedBy, StringComparison.OrdinalIgnoreCase))
            {
                property.CurrentValue = property.OriginalValue;
            }

            if (propertyName.Equals(CreatedOn, StringComparison.OrdinalIgnoreCase))
            {
                property.CurrentValue = property.OriginalValue;
            }

            if (propertyName.Equals(UpdatedBy, StringComparison.OrdinalIgnoreCase))
            {
                property.CurrentValue = userId;
            }

            if (propertyName.Equals(UpdatedOn, StringComparison.OrdinalIgnoreCase))
            {
                property.CurrentValue = _now;
            }

            if (property.IsModified)
            {
                auditEntry.ChangedColumns.Add(propertyName);
                auditEntry.AuditType = AuditType.Update;
                auditEntry.OldValues[propertyName] = property.OriginalValue;
                auditEntry.NewValues[propertyName] = property.CurrentValue;
            }
        }
    }
}