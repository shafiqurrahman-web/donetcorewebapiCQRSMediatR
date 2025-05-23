using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext.Configurations
{
    public partial class PickupScheduleConfiguration : IEntityTypeConfiguration<PickupSchedule>
    {
        public void Configure(EntityTypeBuilder<PickupSchedule> entity)
        {

            entity.HasKey(e => e.ScheduleId)
                     .HasName("PK_PickupScheduleId");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_sname())");

            entity.Property(e => e.CurrentCount).HasDefaultValueSql("((0))");

            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.NoPickup).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.DateKeyNavigation)
                .WithMany(p => p.PickupSchedule)
                .HasForeignKey(d => d.DateKey)
                .HasConstraintName("FK_PickupSchedule_DateDimension");

            entity.HasOne(d => d.PickupRouteType)
                .WithMany(p => p.PickupSchedule)
                .HasForeignKey(d => d.PickupRouteTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PickupSch__Picku__538D5813");

            entity.HasOne(d => d.Route)
                .WithMany(p => p.PickupSchedule)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PickupSch__Route__54817C4C");

        }

    }
}
