﻿using CarvedRock.DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

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

        public virtual DbSet<ClothesItem> ClothesItems { get; set; } = null!;
        public virtual DbSet<MagazineItem> MagazineItems { get; set; } = null!;
        public virtual DbSet<DriedFoodItem> DriedFoodItems { get; set; } = null!;
        public virtual DbSet<CannedFoodItem> CannedFoodItems { get; set; } = null!;

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Dictionary<string, object>> Tags => Set<Dictionary<string, object>>("Tag");
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;
        public virtual DbSet<ItemOrder> ItemOrders { get; set; } = null!;

        public virtual IQueryable<CustomerOrder> GetCustomerOrdersByCustomerId(int customerId)
            => FromExpression(() => GetCustomerOrdersByCustomerId(customerId));

        public virtual IQueryable<StatusOverview> GetStatusOverview()
            => FromExpression(() => GetStatusOverview());

        public virtual int GetTotalInvoiceAmountByOrderId(int orderId)
            => throw new NotSupportedException();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .LogTo(message => Debug.WriteLine(message))
                    .EnableSensitiveDataLogging();

                // Når der skal laves nye videor til 7.0, så se på denne side for at forklare, at vi tilføjer TrustServerCertificate=True:
                // https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-7.0/breaking-changes
                optionsBuilder.UseSqlServer("Server=.;Database=CarvedRockRetail;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDbFunction(typeof(CarvedRockContext).GetMethod(nameof(GetCustomerOrdersByCustomerId),
                                                                   new[] { typeof(int) }))
                .HasName("GetCustomerOrdersByCustomerId");

            modelBuilder.Entity<StatusOverview>().ToView("StatusOverview");
            modelBuilder
                .HasDbFunction(typeof(CarvedRockContext).GetMethod(nameof(GetStatusOverview)))
                .HasName("GetStatusOverview");

            modelBuilder
                .HasDbFunction(typeof(CarvedRockContext).GetMethod(nameof(GetTotalInvoiceAmountByOrderId),
                                                                   new[] { typeof(int) }))
                .HasName("GetTotalInvoiceAmountByOrderId");

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(22,2)");
                entity.Property(e => e.UnitPriceAfterVAT).HasColumnType("decimal(22,2)");
                entity.ToView("CustomerOrdersView");
            });

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
                    .IsRequired();

                entity.OwnsOne(e => e.BillToAddress)
                    .Property(e => e.Street)
                    .IsRequired();

                entity.HasIndex(e => new { e.FirstName, e.LastName });
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Name);
            });

            modelBuilder.Entity<ItemOrder>(entity =>
            {
                entity.HasOne(e => e.Item)
                    .WithMany(e => e.ItemOrders)
                    .HasForeignKey(e => e.ItemsId);

                entity.HasOne(e => e.Order)
                    .WithMany(e => e.ItemOrders)
                    .HasForeignKey(e => e.OrdersId);

                entity.HasKey(io => new { io.ItemsId, io.OrdersId });

                entity.Property(io => io.OrderDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.ToTable("ItemOrder");
            });

            /* TABLE-PER-HIERARCHY */
            //entity.HasDiscriminator<string>("ItemType")
            //    .HasValue<Item>("UncategorizedItem");

            //entity.Property("ItemType")
            //    .HasDefaultValue("UncategorizedItem");

            /* TABLE-PER-TYPE */
            //entity.ToTable("Items");
            //entity.UseTptMappingStrategy();

            /* TABLE-PER-CONCRETE-TYPE */
            //entity.UseTpcMappingStrategy();

            //entity.ToTable("Items");
            //entity.Property(e => e.Id).UseIdentityColumn(1, 1);




            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasDefaultValue(100m);
                entity.Property(e => e.PriceAfterVat)
                    .HasComputedColumnSql("[UnitPrice]*1.10");

                entity.HasDiscriminator<string>("ItemType")
                    .HasValue<Item>("UncategorizedItem");

                entity.Property("ItemType")
                    .HasDefaultValue("UncategorizedItem");
            });

            modelBuilder.Entity<DriedFoodItem>()
                .Property(e => e.ProductionDate)
                .HasColumnName("ProductionDate")
                .IsSparse();

            modelBuilder.Entity<CannedFoodItem>()
                .Property(e => e.ProductionDate)
                .HasColumnName("ProductionDate")
                .IsSparse();

            modelBuilder
                .Entity<CannedFoodItem>()
                .Property(e => e.CanningMaterial)
                .HasConversion<CanningMaterialConverter>();

            modelBuilder
                .Entity<MagazineItem>()
                .Property(e => e.PublicationFrequency)
                .HasConversion<PublicationFrequencyConverter>();

            modelBuilder
                .Entity<ClothesItem>()
                .Property(e => e.Fabric)
                .HasConversion<ClothesFabricConverter>();










            /* TABLE-PER-CONCRETE-TYPE */
            //modelBuilder.Entity<CannedFoodItem>()
            //    .ToTable("CannedFoodItems",
            //        tb => tb.Property(e => e.Id).UseIdentityColumn(10000));

            //modelBuilder.Entity<DriedFoodItem>()
            //    .ToTable("DriedFoodItems",
            //        tb => tb.Property(e => e.Id).UseIdentityColumn(20000));

            //modelBuilder.Entity<MagazineItem>()
            //    .ToTable("MagazineItems",
            //        tb => tb.Property(e => e.Id).UseIdentityColumn(30000));

            //modelBuilder
            //    .Entity<ClothesItem>()
            //    .ToTable("ClothesItems",
            //        tb => tb.Property(e => e.Id).UseIdentityColumn(40000));

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