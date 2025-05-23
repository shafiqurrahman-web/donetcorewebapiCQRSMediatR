
using BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext.Configurations;
namespace BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext
{
       
    public partial class AppDbContextMobile : DbContext
    {

        public AppDbContextMobile(DbContextOptions<AppDbContextMobile> options) : base(options)
        {
        }

        public virtual DbSet<Donation> Donation { get; set; }
        public virtual DbSet<DonationStatus> DonationStatus { get; set; }
        public virtual DbSet<DonationTransaction> DonationTransaction { get; set; }
        public virtual DbSet<DonationType> DonationType { get; set; }
        public virtual DbSet<Donor> Donor { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<PickupSchedule> PickupSchedule { get; set; }
        public virtual DbSet<DonorAddress> DonorAddress { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.ApplyConfiguration(new Configurations.DonationConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.DonationStatusConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.DonationTransactionConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.DonationTypeConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.DonorConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.RouteConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.PickupScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.DonationPickupDatesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.DonorAddressConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
    }
}
