using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext.Configurations
{
    public partial class DonorAddressConfiguration : IEntityTypeConfiguration<DonorAddress>
    {
        public void Configure(EntityTypeBuilder<DonorAddress> entity)
        {

            entity.HasKey(e => e.DonorAddressesId)
                     .HasName("PK_DonorAddresses");

            entity.Property(e => e.Address)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.AddressNumber).HasMaxLength(50);

            entity.Property(e => e.AddressUnit)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.CrossStreet)
                .HasMaxLength(156)
                .IsUnicode(false);

            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.HouseColor)
                .HasMaxLength(156)
                .IsUnicode(false);

            entity.Property(e => e.Instructions)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            entity.Property(e => e.Street)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.StreetAddress)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.ZipCode)
                .HasMaxLength(25)
                .IsUnicode(false);

            //entity.HasOne(d => d.AddressType)
            //    .WithMany(p => p.DonorAddress)
            //    .HasForeignKey(d => d.AddressTypeId)
            //    .HasConstraintName("FK__DonorAddr__Addre__11158940");

            //entity.HasOne(d => d.City)
            //    .WithMany(p => p.DonorAddress)
            //    .HasForeignKey(d => d.CityId)
            //    .HasConstraintName("FK__DonorAddr__CityI__1209AD79");

            //entity.HasOne(d => d.Country)
            //    .WithMany(p => p.DonorAddress)
            //    .HasForeignKey(d => d.CountryId)
            //    .HasConstraintName("FK__DonorAddr__Count__12FDD1B2");

            //entity.HasOne(d => d.State)
            //    .WithMany(p => p.DonorAddress)
            //    .HasForeignKey(d => d.StateId)
            //    .HasConstraintName("FK__DonorAddr__State__13F1F5EB");

        }

    }
}
