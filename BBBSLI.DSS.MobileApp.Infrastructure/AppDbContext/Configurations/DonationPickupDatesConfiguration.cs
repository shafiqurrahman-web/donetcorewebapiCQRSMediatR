using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext.Configurations
{
    public partial class DonationPickupDatesConfiguration : IEntityTypeConfiguration<DonationPickupDates>
    {
        public void Configure(EntityTypeBuilder<DonationPickupDates> entity)
        {

            entity.HasKey(e => e.DonationPickupId);

            entity.HasOne(d => d.DateKeyNavigation)
                .WithMany(p => p.DonationPickupDates)
                .HasForeignKey(d => d.DateKey)
                .HasConstraintName("FK_DonationPickupDates_DateDimension");

            entity.HasOne(d => d.Donation)
                .WithMany(p => p.DonationPickupDates)
                .HasForeignKey(d => d.DonationId)
                .HasConstraintName("FK_DonationPickupDates_Donation");
  

    }

    }
}
