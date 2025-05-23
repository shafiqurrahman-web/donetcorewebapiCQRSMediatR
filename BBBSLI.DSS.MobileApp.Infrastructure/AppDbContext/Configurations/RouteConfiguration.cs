using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext.Configurations
{
    public partial class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> entity)
        {

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.DateCreated).HasColumnType("datetime");

            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.RouteName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

        }

    }
}
