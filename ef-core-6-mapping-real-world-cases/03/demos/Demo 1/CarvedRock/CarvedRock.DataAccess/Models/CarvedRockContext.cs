using CarvedRock.DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarvedRock.DataAccess.Models
{
    public partial class CarvedRockContext : DbContext
    {
        public CarvedRockContext()
        {
        }

        public CarvedRockContext(DbContextOptions<CarvedRockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Dictionary<string, object>> Tags => Set<Dictionary<string, object>>("Tag");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .LogTo(message => Debug.WriteLine(message))
                    .EnableSensitiveDataLogging();

                optionsBuilder.UseSqlServer("Server=.;Database=CarvedRockRetail;Trusted_Connection=True;");
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SharedTypeEntity<Dictionary<string, object>>(
                   "Tag",
                   entity =>
                   {
                       entity.Property<int>("Id"); // Will be set up as primary key by convention                 
                       entity.Property<int>("CustomerId");
                       entity.Property<string>("Nickname");
                       entity.Property<int>("DiscountRate");
                   });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasAlternateKey(e => e.Username);
                entity.Property(e => e.Username).HasField("_validUsername");

                entity.Property<byte[]>("Checksum")
                    .HasComputedColumnSql("CONVERT(VARBINARY(1024),CHECKSUM([FirstName],[LastName],[UserName]))");

                entity.IndexerProperty<DateTime>("LastUpdated")
                    .HasDefaultValue(new DateTime(2020, 1, 1));

                entity.IndexerProperty<string>("ConsumerType");

                entity.OwnsOne(e => e.ShipToAddress)
                    .Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("ShipToStreet");

                entity.OwnsOne(e => e.BillToAddress)
                    .ToTable("BillToAddresses")
                    .Property(e => e.Street)
                    .IsRequired();














                //entity.Property(e => e.CustomerStatus)
                //   .HasConversion(
                //       v => v.ToString(),
                //       v => !string.IsNullOrWhiteSpace(v) ?
                //               (Status)Enum.Parse(typeof(Status), v)
                //               : Status.Pending);

                ////Can be simplified by using a pre-defined conversion
                //entity.Property(e => e.CustomerStatus)
                //   .HasConversion<string>();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasDefaultValue(100m);
                entity.Property(e => e.PriceAfterVat)
                    .HasComputedColumnSql("[UnitPrice]*1.10");
            });

            OnModelCreatingPartial(modelBuilder);
        }






        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.
                Properties<Status>()
                .HaveConversion<StatusConverter>();

            configurationBuilder.
                Properties<string>()
                .HaveConversion<ShortStringConverter>();

            base.ConfigureConventions(configurationBuilder);
        }













        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}