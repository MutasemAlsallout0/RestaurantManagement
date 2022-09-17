using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestaurantManagement.ModelsViews;

#nullable disable

namespace RestaurantManagement.Models
{
    public partial class restaurantdbContext : DbContext
    {
        public byte IgnoreFilter { get; set; }  
        public restaurantdbContext()
        {
        }

        public restaurantdbContext(DbContextOptions<restaurantdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Restaurantt> Restaurants { get; set; }
        public virtual DbSet<RestaurantMenu> RestaurantMenus { get; set; }
        public virtual DbSet<RestaurantMenuCustomer> RestaurantMenuCustomers { get; set; }
        public virtual DbSet<CsvView> CsvViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MUTASEM\\SQLEXPRESS01;Database=restaurantdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CsvView>(entity =>
            {
                entity.ToTable("csvReport");
                entity.HasNoKey();
                entity.Property(e => e.RestaurantName).HasColumnType("nvarchar(250) not null");
                entity.Property(e => e.ProfitInNis).HasColumnType("float null");
                entity.Property(e => e.ProfitInUsd).HasColumnType("float null");
                entity.Property(e => e.MostPurchasedCustomer).HasColumnType("int null");
                entity.Property(e => e.NumberOfOrderedCustomer).HasColumnType("nvarchar(250) null");
                entity.Property(e => e.TheBestSellingMeal).HasColumnType("nvarchar(250) null");

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Restaurantt>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RestaurantMenu>(entity =>
            {
                entity.ToTable("RestaurantMenu");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MealName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantMenus)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantMenu_Restaurant");
            });

            modelBuilder.Entity<RestaurantMenuCustomer>(entity =>
            {
                entity.ToTable("RestaurantMenuCustomer");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RestaurantMenuCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantMenuCustomer_Customer");

                entity.HasOne(d => d.RestaurantMenu)
                    .WithMany(p => p.RestaurantMenuCustomers)
                    .HasForeignKey(d => d.RestaurantMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantMenuCustomer_RestaurantMenu");
            });

            modelBuilder.Entity<Customer>().HasQueryFilter(x => x.Archived == 0);
            modelBuilder.Entity<Restaurantt>().HasQueryFilter(x => x.Archived != 0);
            modelBuilder.Entity<RestaurantMenu>().HasQueryFilter(x => x.Archived != 0);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
