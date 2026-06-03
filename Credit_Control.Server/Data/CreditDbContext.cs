using Credit_Control.Server.Models;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Credit_Control.Server.Data
{
    public class CreditDbContext: DbContext, IDataProtectionKeyContext
    {
        public CreditDbContext(DbContextOptions options) : base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VatScheme>().HasData(
                new VatScheme { Id = "NORMAL", DisplayName = "Normal" },
                new VatScheme { Id = "EXEMPT", DisplayName = "Exempt" },
                new VatScheme { Id = "REDUCED", DisplayName = "Reduced" },
                new VatScheme { Id = "SPECIAL", DisplayName = "Special" }
            );

            modelBuilder.Entity<ItemLine>()
            .Property(l => l.Quantity)
            .HasPrecision(18, 3);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.CustomerCode)
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .HasIndex(i => i.InvoiceNumber)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductCode)
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemLine>()
                .HasOne(i => i.Invoice)
                .WithMany(it => it.ItemLines)
                .HasForeignKey(i => i.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemLine>()
                .HasOne(p => p.Product)
                .WithMany(it => it.ItemLines)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<VatScheme> VatSchemes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ItemLine> ItemLines { get; set; }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;
    }
}
