using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APPR6312_Part1_1_.Data
{
    public class DAFAppDataDbcontext : DbContext
    {
        public DAFAppDataDbcontext(DbContextOptions<DAFAppDataDbcontext> options) : base(options)
        {
         
        }
        public DAFAppDataDbcontext() { }

        public virtual DbSet<MonetaryDonation> MonetaryDonations { get; set; }
        public virtual DbSet<goodsDonation> goodsDonations { get; set; }
        public virtual DbSet<Disaster> Disasters { get; set; }
        public virtual DbSet<DonationAllocation> DonationsAllocation { get; set; }

        public virtual DbSet<DonationAllocationMonetary> DonationAllocationMonetary { get; set; }

        public virtual DbSet<Inventory> Inventory { get; set; }
        public DbSet<DisasterViewM> DisasterViews { get; set; }

        public DbSet<DiastersViewMonetrayM> diastersViewMonetrays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Your other model configurations

            modelBuilder.Entity<DonationAllocation>()
           .HasKey(da => da.AllocationId);

            modelBuilder.Entity<DonationAllocation>()
                .HasOne(dg => dg.Disaster)
                .WithMany(d => d.donationAllocations)
                .HasForeignKey(dg => dg.DisasterId);

            modelBuilder.Entity<   DonationAllocation >()
                .HasOne(dg => dg.goodsDonation)
                .WithMany()
                .HasForeignKey(dg => dg.goodDonationId);



            modelBuilder.Entity<DonationAllocationMonetary>()
          .HasKey(da => da.AllocationId);

            modelBuilder.Entity<DonationAllocationMonetary>()
                .HasOne(dg => dg.Disaster)
                .WithMany(d => d.donationAllocationMonetaries)
                .HasForeignKey(dg => dg.DisasterId);

            modelBuilder.Entity<DonationAllocationMonetary>()
                .HasOne(dg => dg.monetaryDonation)
                .WithMany()
                .HasForeignKey(dg => dg.MoneyDonationId);

            modelBuilder.Entity<Inventory>()
          .HasKey(I => I.Id);

            modelBuilder.Entity<Inventory>()
                .HasOne(dI => dI.Disaster)
                .WithMany(d => d.Inventory)
                .HasForeignKey(dI => dI.DisasterId);

            modelBuilder.Entity<DisasterViewM>().HasNoKey().ToView(null);
            modelBuilder.Entity<DiastersViewMonetrayM>().HasNoKey().ToView(null);

            base.OnModelCreating(modelBuilder);

            //The following method was taken from StackOverFlow
            // Author: LeonardoDevBack
            //Link: https://stackoverflow.com/questions/75137569/create-a-foreign-key-on-a-table-in-entity-framework-core-that-references-the-ide
        }
    }
}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO

//The following method was taken from youtube
// Author: Digtal TechJoint
//Link: https://youtu.be/ghzvSROMo_M?si=Y1YzZVwhciU1dcUm