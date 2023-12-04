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
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                //entity.HasKey(e => new { e.FirstName, e.LastName });
                entity.HasAlternateKey(e => e.Username);
                entity.Property(e => e.Username).HasField("_validUsername");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Already done using attributes
                //entity.Property(e => e.Price).HasColumnType("decimal(22,2)").HasColumnName("UnitPrice");
                //entity.Property(e => e.Description).IsRequired().HasMaxLength(255);

                entity.Property(e => e.Price).HasDefaultValue(100m);
                entity.Property(e => e.PriceAfterVat).HasComputedColumnSql("[UnitPrice]*1.10");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
